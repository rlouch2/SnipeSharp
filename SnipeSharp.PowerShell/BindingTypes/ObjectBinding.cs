using System;
using System.Collections.Generic;
using SnipeSharp.Filters;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.BindingTypes
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
                    Type = BindingType.String,
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
                Type = BindingType.Integer,
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
                Type = BindingType.String,
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
        /// <param name="tag">The tag, if it is present, else null</param>
        /// <param name="value">The query, if the tag is missing, or the portion after the tag.</param>
        /// <returns>The tag type.</returns>
        protected static BindingQueryType ParseQuery(string query, out string tag, out string value)
        {
            var index = query.IndexOf(':');
            if(index == -1)
            {
                value = query;
                tag = null;
                return BindingQueryType.Absent;
            }
            value = query.Substring(index + 1);
            tag = query.Substring(0, index).ToLower();
            switch(tag)
            {
                case "cname":
                    return BindingQueryType.CaseSensitiveName;
                case "name":
                case "iname":
                    return BindingQueryType.CaseInsensitiveName;
                case "id":
                    return BindingQueryType.Id;
                case "serial":
                    return BindingQueryType.Serial;
                case "tag":
                    return BindingQueryType.AssetTag;
                case "search":
                    return BindingQueryType.Search;
                case "username":
                case "uname":
                    return BindingQueryType.UserName;
                case "email":
                    return BindingQueryType.Email;
                default:
                    value = tag;
                    return BindingQueryType.Invalid;
            }
        }

        /// <summary>
        /// Resolve this instance of the object binding.
        /// </summary>
        internal virtual void Resolve(ISearchFilter filter = null)
        {
            ApiOptionalResponse<T> result;
            switch(QueryUnion.Type)
            {
                case BindingType.Integer:
                    result = ApiHelper.Instance.GetEndPoint<T>().GetOptional(QueryUnion.IntegerValue);
                    break;
                default:
                    result = new ApiOptionalResponse<T> { Exception = new InvalidOperationException("Cannot resolve an invalid binding.") };
                    break;
                case BindingType.String:
                    var endPoint = ApiHelper.Instance.GetEndPoint<T>();
                    int id; // used later for parsing integers
                    switch(ParseQuery(QueryUnion.StringValue, out var tag, out var value))
                    {
                        case BindingQueryType.Absent:
                            if(int.TryParse(value, out id))
                                result = endPoint.GetOptional(id);
                            else
                                result = endPoint.GetOptional(value, QueryUnion.CaseSensitive, filter);
                            break;
                        case BindingQueryType.CaseSensitiveName:
                            QueryUnion.CaseSensitive = true;
                            goto case BindingQueryType.CaseInsensitiveName;
                        case BindingQueryType.CaseInsensitiveName:
                            result = endPoint.GetOptional(value, QueryUnion.CaseSensitive, filter);
                            break;
                        case BindingQueryType.Id:
                            if(int.TryParse(value, out id))
                                result = endPoint.GetOptional(id);
                            else
                                result = new ApiOptionalResponse<T> { Exception = new ArgumentException($"Id is not an integer: {value}", "query") };
                            break;
                        case BindingQueryType.Search:
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
                            result = new ApiOptionalResponse<T> { Exception = new ArgumentException($"Query does not have a proper type: {tag}", "query") };
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
