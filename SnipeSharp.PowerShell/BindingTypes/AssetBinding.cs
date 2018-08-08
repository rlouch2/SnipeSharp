using System;
using System.Collections.Generic;
using SnipeSharp.EndPoint.Models;
using static SnipeSharp.EndPoint.EndPointExtensions;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// Used to convert an Asset identity into an Asset object.
    /// </summary>
    public class AssetBinding: ObjectBinding<Asset>
    {
        /// <summary>
        /// Fetches a single Asset by its internal Id.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id of an asset.</param>
        public AssetBinding(int id) : base(id)
        {
        }

        /// <summary>
        /// Fetches a single Asset using a simplified query. The query is of the form "[type:]value". Valid types are: id, name, iname, cname, serial, tag, and search.
        /// </summary>
        /// <param name="query">An Asset Tag, Serial, Name, Id, or Search for an asset.</param>
        public AssetBinding(string query)
        {
            Query = query;
            var (type, value) = ParseQuery(query);
            var endPoint = ApiHelper.Instance.GetEndPoint<Asset>();
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
                        else
                            throw new ArgumentException($"Id query is not an integer: {value}", nameof(query));
                        break;
                    case "serial":
                        (Object, _) = endPoint.GetBySerialOrNull(value);
                        break;
                    case "tag":
                        (Object, _) = endPoint.GetByTagOrNull(value);
                        break;
                    case "search":
                        Object = endPoint.FindOne(value);
                        if(Object == null)
                            throw new ArgumentException($"Query did not find an object from value: {value}", nameof(query));
                        break;
                    default:
                        throw new ArgumentException($"Query does not have a proper type: {type}", nameof(query));
                }
                if(Object == null)
                    Object = endPoint.FindOne(value);
                if(Object == null)
                    throw new ArgumentException($"Query did not find an object from value: {value}", nameof(query));
            }
        }

        /// <summary>
        /// Fetches an Asset by name, optionally case-sensitive.
        /// </summary>
        /// <param name="name">The name of the asset.</param>
        /// <param name="caseSensitive">Whether or not to be case-sensitive in the search (default false).</param>
        public AssetBinding(string name, bool caseSensitive = false): base(name, caseSensitive)
        {
        }

        /// <summary>
        /// Re-fetches an Asset by its internal Id.
        /// </summary>
        /// <param name="asset">An Asset object.</param>
        public AssetBinding(Asset asset) : base(asset)
        {
        }
    }
}