using System;
using System.Collections.Generic;
using SnipeSharp.EndPoint.Filters;
using SnipeSharp.EndPoint.Models;
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
        /// <value>Gets if the object is null.</value>
        public bool IsNull => Object == null;

        /// <value>Gets the object retrieved by the query, or null.</value>
        public T Object { get; protected set; }

        /// <value>Gets the query used.</value>
        public string Query { get; protected set; }

        /// <value>Gets the exception thrown during retrieval, or null.</value>
        public Exception Error { get; protected set; }

        /// <summary>
        /// Fetches a single Object by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe-IT internal Id of the object.</param>
        public ObjectBinding(int id)
        {
            Query = $"id:{id}";
            (Object, Error) = ApiHelper.Instance.GetEndPoint<T>().GetOrNull(id);
        }

        /// <summary>
        /// Fetches a single Object using a simplified query. The query is of the form "[type:]value". Valid types are: id, name, iname, cname, and search.
        /// </summary>
        /// <param name="query">A simplified query.</param>
        public ObjectBinding(string query)
        {
            Query = query;
            var (type, value) = ParseQuery(query);
            var endPoint = ApiHelper.Instance.GetEndPoint<T>();
            if(type == null)
            {
                if(int.TryParse(value, out var id))
                    (Object, Error) = endPoint.GetOrNull(id);
                else
                    (Object, Error) = endPoint.GetOrNull(value);
            } else
            {
                switch(type)
                {
                    case "cname":
                        (Object, Error) = endPoint.GetOrNull(value, true);
                        break;
                    case "name":
                    case "iname":
                        (Object, Error) = endPoint.GetOrNull(value, false);
                        break;
                    case "id":
                        if(int.TryParse(value, out var id))
                            (Object, Error) = endPoint.GetOrNull(id);
                        else
                        {
                            Error = new ArgumentException($"Id is not an integer: {value}", nameof(query));
                            return;
                        }
                        break;
                    case "search":
                        try
                        {
                            Object = endPoint.FindOne(value);
                        } catch(Exception e)
                        {
                            Error = e;
                            return;
                        }
                        break;
                    default:
                        Error = new ArgumentException($"Query does not have a proper type: {type}", nameof(query));
                        return;
                }
                if(Object == null)
                    try
                    {
                        Object = endPoint.FindOne(value);
                    } catch(Exception e)
                    {
                        Error = e;
                    }
            }
        }

        /// <summary>
        /// Fetches an Object by name, optionally case-sensitive.
        /// </summary>
        /// <param name="name">The name of the object.</param>
        /// <param name="caseSensitive">Whether or not to be case-sensitive in the search (default false).</param>
        public ObjectBinding(string name, bool caseSensitive = false)
        {
            Query = caseSensitive ? $"cname:{name}" : $"name:{name}";
            (Object, Error) = ApiHelper.Instance.GetEndPoint<T>().GetOrNull(name, caseSensitive);
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
            Object = item.Item1;
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

        internal static ObjectBinding<T> FromId(int id)
            => new ObjectBinding<T>(id);
        internal static ObjectBinding<T> FromName(string name)
            => new ObjectBinding<T>(name, ApiHelper.Instance.GetEndPoint<T>().GetOrNull(name));
    }
}
