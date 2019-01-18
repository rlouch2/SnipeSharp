using System;
using System.Collections.Generic;
using SnipeSharp.Filters;
using SnipeSharp.Models;
using SnipeSharp.PowerShell;
using SnipeSharp.Exceptions;

namespace  SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// Binds Id's, Names, and Queries to Snipe-IT API Objects in the pipeline.
    /// </summary>
    /// <typeparam name="T">The type of object being bound to.</typeparam>
    public class ObjectBinding<T>: INullObjectBinding where T: CommonEndPointModel
    {
        /// <summary>
        /// Type for binding queries.
        /// </summary>
        protected struct BindingQueryUnion
        {
            /// <summary>
            /// What type is the binding?
            /// </summary>
            internal enum Type
            {
                Invalid = 0,
                String = 1,
                Integer = 2
            }

            internal Type BindingType;
            internal string StringValue;
            internal bool CaseSensitive;
            internal int IntegerValue;

            /// <inheritdoc/>
            public override string ToString()
            {
                if(null != StringValue)
                    return StringValue;
                switch(BindingType)
                {
                    case Type.Integer:
                        return IntegerValue.ToString();
                    default:
                        return string.Empty;
                }
            }
        }

        /// <value>Gets if the object is null.</value>
        public bool IsNull => Object is null;

        /// <summary>Backing field for <see cref="Object"/></summary>
        private T _object;

        /// <value>Gets the object retrieved by the query, or null.</value>
        public T Object {
            get
            {
                if(_object == null && Error == null)
                    (_object, Error) = ResolveBinding(null);
                return _object;
            }
            protected set => _object = value;
        }

        /// <summary>
        /// The internal binding query.
        /// </summary>
        protected BindingQueryUnion QueryUnion;

        /// <value>Gets the query used.</value>
        public string Query {
            get => QueryUnion.ToString();
            protected set
                => QueryUnion = new BindingQueryUnion
                {
                    BindingType = BindingQueryUnion.Type.String,
                    StringValue = value
                };
        }

        /// <value>Gets the exception thrown during retrieval, or null.</value>
        public Exception Error { get; protected set; }

        /// <summary>
        /// Fetches a single Object by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe-IT internal Id of the object.</param>
        public ObjectBinding(int id)
        {
            QueryUnion = new BindingQueryUnion
            {
                BindingType = BindingQueryUnion.Type.Integer,
                StringValue = $"id:{id}",
                IntegerValue = id
            };
        }

        /// <summary>
        /// Fetches a single Object using a simplified query. The query is of the form "[type:]value". Valid types are: id, name, iname, cname, and search.
        /// </summary>
        /// <param name="query">A simplified query.</param>
        public ObjectBinding(string query)
        {
            QueryUnion = new BindingQueryUnion
            {
                BindingType = BindingQueryUnion.Type.String,
                StringValue = query
            };
        }

        /// <summary>
        /// Fetches an Object by name, optionally case-sensitive.
        /// </summary>
        /// <param name="name">The name of the object.</param>
        /// <param name="caseSensitive">Whether or not to be case-sensitive in the search (default false).</param>
        public ObjectBinding(string name, bool caseSensitive = false) : this(caseSensitive ? $"cname:{name}" : $"name:{name}")
        {
            QueryUnion.CaseSensitive = caseSensitive;
        }

        /// <summary>
        /// Re-fetches an object by its internal Id.
        /// </summary>
        /// <param name="object">An object.</param>
        public ObjectBinding(T @object): this(@object.Id)
        {
        }

        internal ObjectBinding()
        {
        }

        /// <summary>
        /// For use with the internal From* functions.
        /// </summary>
        internal ObjectBinding(string query, (T, Exception) item)
        {
            Query = query;
            _object = item.Item1;
            Error = item.Item2;
        }

        /// <summary>
        /// Parses a query into its type and value.
        /// </summary>
        /// <param name="query">The query to parse</param>
        /// <returns>A tupel of the type and value.</returns>
        protected static (string type, string value) ParseQuery(string query)
        {
            var index = query.IndexOf(':');
            return (index == -1) ? (null, query) : (query.Substring(0, index), query.Substring(index + 1));
        }

        internal void Resolve(ISearchFilter filter = null)
            => (_object, Error) = ResolveBinding(filter);

        /// <summary>
        /// Resolve this instance of the object binding.
        /// </summary>
        protected virtual (T, Exception) ResolveBinding(ISearchFilter filter = null)
        {
            switch(QueryUnion.BindingType)
            {
                case BindingQueryUnion.Type.String:
                    var (type, value) = ParseQuery(QueryUnion.StringValue);
                    var endPoint = ApiHelper.Instance.GetEndPoint<T>();
                    
                    if(type is null)
                    {
                        if(int.TryParse(value, out var id))
                            return endPoint.GetOrNull(id);
                        else
                            return endPoint.GetOrNull(value, QueryUnion.CaseSensitive, filter);
                    } else
                    {
                        (T Object, Exception Error) result;
                        switch(type)
                        {
                            case "cname":
                                QueryUnion.CaseSensitive = true;
                                goto case "iname";
                            case "name":
                            case "iname":
                                result = endPoint.GetOrNull(value, QueryUnion.CaseSensitive, filter);
                                break;
                            case "id":
                                if(int.TryParse(value, out var id))
                                    result = endPoint.GetOrNull(id);
                                else
                                    return (null, new ArgumentException($"Id is not an integer: {value}", "query"));
                                break;
                            case "search":
                                try
                                {
                                    filter.Search = value;
                                    result = (endPoint.FindOne(filter), null);
                                } catch(Exception e)
                                {
                                    return (null, e);
                                }
                                break;
                            default:
                                return (null, new ArgumentException($"Query does not have a proper type: {type}", "query"));
                        }
                        if(result.Object is null)
                            try
                            {
                                filter.Search = value;
                                return (endPoint.FindOne(filter), null);
                            } catch(Exception e)
                            {
                                return (null, e);
                            }
                        else
                            return result;
                    }
                case BindingQueryUnion.Type.Integer:
                    return ApiHelper.Instance.GetEndPoint<T>().GetOrNull(QueryUnion.IntegerValue);
                default:
                    return (null, new InvalidOperationException("Cannot resolve an invalid binding."));
            }
        }

        internal static ObjectBinding<T> FromId(int id)
            => new ObjectBinding<T>(id);
        internal static ObjectBinding<T> FromName(string name)
            => new ObjectBinding<T>(name, ApiHelper.Instance.GetEndPoint<T>().GetOrNull(name));
    }
}
