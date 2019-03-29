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
    public class ObjectBinding<T> : IObjectBinding
        where T: CommonEndPointModel
    {
        /// <inheritdoc />
        public bool HasValue
            => null != Value && Value.Count > 0;

        /// <summary>Backing field for <see cref="Object"/></summary>
        private IReadOnlyList<T> _objects;

        /// <value>Gets the object retrieved by the query, or null.</value>
        public IReadOnlyList<T> Value {
            get
            {
                if(_objects == null && Error == null)
                    Resolve(null);
                return _objects;
            }
            protected set => _objects = value;
        }

        /// <summary>
        /// The internal binding query.
        /// </summary>
        internal BindingQueryUnion QueryUnion;

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
        internal ObjectBinding(string query, ApiOptionalResponse<ResponseCollection<T>> item)
        {
            Query = query;
            _objects = item.Value;
            Error = item.Exception;
        }

        /// <summary>
        /// For use with the internal From* functions.
        /// </summary>
        internal ObjectBinding(string query, ApiOptionalResponse<T> apiOptionalResponse)
        {
            Query = query;
            _objects = new T[]{ apiOptionalResponse.Value };
            Error = apiOptionalResponse.Exception;
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

        /// <summary>
        /// Resolve this instance of the object binding.
        /// </summary>
        internal virtual void Resolve(ISearchFilter filter = null)
        {
            ApiOptionalResponse<T> result;
            switch(QueryUnion.BindingType)
            {
                case BindingQueryUnion.Type.String:
                    var (type, value) = ParseQuery(QueryUnion.StringValue);
                    var endPoint = ApiHelper.Instance.GetEndPoint<T>();

                    if(type is null)
                    {
                        if(int.TryParse(value, out var id))
                            result = endPoint.GetOptional(id);
                        else
                            result = endPoint.GetOptional(value, QueryUnion.CaseSensitive, filter);
                    } else
                    {
                        switch(type)
                        {
                            case "cname":
                                QueryUnion.CaseSensitive = true;
                                goto case "iname";
                            case "name":
                            case "iname":
                                result = endPoint.GetOptional(value, QueryUnion.CaseSensitive, filter);
                                break;
                            case "id":
                                if(int.TryParse(value, out var id))
                                    result = endPoint.GetOptional(id);
                                else
                                    result = new ApiOptionalResponse<T> { Exception = new ArgumentException($"Id is not an integer: {value}", "query") };
                                break;
                            case "search":
                                try
                                {
                                    filter.Search = value;
                                    result = endPoint.FindOneOptional(filter);
                                } catch(Exception e)
                                {
                                    result = new ApiOptionalResponse<T> { Exception = e };
                                }
                                break;
                            default:
                                result = new ApiOptionalResponse<T> { Exception = new ArgumentException($"Query does not have a proper type: {type}", "query") };
                                break;
                        }
                        if(null != result.Exception)
                        {
                            try
                            {
                                filter.Search = value;
                                result = endPoint.FindOneOptional(filter);
                            } catch(Exception e)
                            {
                                result = new ApiOptionalResponse<T> { Exception = e };
                            }
                        }
                    }
                    break;
                case BindingQueryUnion.Type.Integer:
                    result = ApiHelper.Instance.GetEndPoint<T>().GetOptional(QueryUnion.IntegerValue);
                    break;
                default:
                    result = new ApiOptionalResponse<T> { Exception = new InvalidOperationException("Cannot resolve an invalid binding.") };
                    break;
            }

            Value = new T[] { result.Value };
            Error = result.Exception;
        }

        internal static ObjectBinding<T> FromId(int id)
            => new ObjectBinding<T>(id);
        internal static ObjectBinding<T> FromName(string name)
            => new ObjectBinding<T>(name, ApiHelper.Instance.GetEndPoint<T>().GetOptional(name));
    }
}
