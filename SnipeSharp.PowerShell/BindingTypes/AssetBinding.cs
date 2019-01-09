using System;
using System.Collections.Generic;
using SnipeSharp;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// Used to convert an Asset identity into an Asset object.
    /// </summary>
    public sealed class AssetBinding: ObjectBinding<Asset>
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
            if(type is null)
            {
                // tag -> serial -> name -> id -> no search
                (Object, Error) = endPoint.GetByTagOrNull(value);
                if(!(Object is null))
                    return;
                (Object, Error) = endPoint.GetBySerialOrNull(value);
                if(!(Object is null))
                    return;
                (Object, Error) = endPoint.GetOrNull(value);
                if(Object is null && int.TryParse(value, out var id))
                    (Object, Error) = endPoint.GetOrNull(id);
                else
                    Error = new ArgumentException($"Cannot find an object for query: {value}", nameof(query));
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
                    case "serial":
                        (Object, Error) = endPoint.GetBySerialOrNull(value);
                        break;
                    case "tag":
                        (Object, Error) = endPoint.GetByTagOrNull(value);
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
                if(Object is null)
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

        /// <summary>
        /// For use with the internal From* functions.
        /// </summary>
        internal AssetBinding(string query, (Asset, Exception) item): base(query, item)
        {
        }

        internal static AssetBinding FromTag(string tag)
            => new AssetBinding(tag, ApiHelper.Instance.Assets.GetByTagOrNull(tag));
        internal new static AssetBinding FromId(int id)
            => new AssetBinding(id);
        internal new static AssetBinding FromName(string name)
            => new AssetBinding(name, ApiHelper.Instance.Assets.GetOrNull(name));
        internal static AssetBinding FromSerial(string serial)
            => new AssetBinding(serial, ApiHelper.Instance.Assets.GetBySerialOrNull(serial));
    }
}
