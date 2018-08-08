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
    public class ObjectBinding<T> where T: CommonEndPointModel
    {
        /// <value>Gets the object retrieved by the query, or null.</value>
        public T Object { get; protected set; }

        /// <value>Gets the query used.</value>
        public string Query { get; protected set; }

        /// <summary>
        /// Fetches a single Object by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe-IT internal Id of the object.</param>
        public ObjectBinding(int id)
        {
            Query = $"id:{id}";
            Object = ApiHelper.Instance.GetEndPoint<T>().GetOrNull(id).Value;
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
                    Object = endPoint.Get(id);
                else
                    Object = endPoint.Get(value);
            } else
            {
                switch(type)
                {
                    case "cname":
                        (Object, _) = endPoint.GetOrNull(value, true);
                        break;
                    case "name":
                    case "iname":
                        (Object, _) = endPoint.GetOrNull(value, false);
                        break;
                    case "id":
                        if(int.TryParse(value, out var id))
                            (Object, _) = endPoint.GetOrNull(id);
                        break;
                    case "search":
                        Object = endPoint.FindOne(value);
                        if(Object == null)
                            return;
                        break;
                    default:
                        throw new ArgumentException($"Query does not have a proper type: {type}", nameof(query));
                }
                if(Object == null)
                    Object = endPoint.FindOne(value);
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
            Object = ApiHelper.Instance.GetEndPoint<T>().Get(name, caseSensitive);
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
        /// Parses a query into its type and value.
        /// </summary>
        /// <param name="query">The query to parse</param>
        /// <returns>A tupel of the type and value.</returns>
        protected static (string type, string value) ParseQuery(string query)
        {
            var index = query.IndexOf(':');
            return (index == -1) ? (null, query) : (query.Substring(0, index), query.Substring(index + 1));
        }
    }
}
