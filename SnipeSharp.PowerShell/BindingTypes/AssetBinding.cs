using System;
using System.Collections.Generic;
using SnipeSharp;
using SnipeSharp.Filters;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// Used to convert an Asset identity into an Asset object.
    /// </summary>
    public sealed class AssetBinding: ObjectBinding<Asset>
    {
        /// <summary>
        /// Fetches a single Asset by its internal Id or AssetTag.
        /// </summary>
        /// <param name="id">The Snipe IT internal Id or AssetTag of an asset.</param>
        public AssetBinding(int id) : base(id.ToString())
        {
        }

        /// <summary>
        /// Fetches a single Asset using a simplified query. The query is of the form "[type:]value". Valid types are: id, name, iname, cname, serial, tag, and search.
        /// </summary>
        /// <param name="query">An Asset Tag, Serial, Name, Id, or Search for an asset.</param>
        public AssetBinding(string query) : base(query)
        {
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

        /// <inheritdoc />
        protected override (Asset, Exception) ResolveBinding(ISearchFilter filter = null)
        {
            var endPoint = ApiHelper.Instance.GetEndPoint<Asset>();
            (Asset Object, Exception Error) result;
            
            switch(QueryUnion.BindingType)
            {
                case BindingQueryUnion.Type.String:
                    var (type, value) = ParseQuery(QueryUnion.StringValue);
                    
                    if(type is null)
                    {
                        // tag -> serial -> name -> id
                        result = endPoint.GetByTagOrNull(value);
                        if(null != result.Object)
                            return result;
                        result = endPoint.GetBySerialOrNull(value);
                        if(null != result.Object)
                            return result;
                        result = endPoint.GetOrNull(value, QueryUnion.CaseSensitive);
                        if(null != result.Object)
                            return result;
                        else if(int.TryParse(value, out var id))
                            return endPoint.GetOrNull(id);
                        else
                            return (null, new ArgumentException($"Cannot find an object for query: {value}", "query"));
                    } else
                    {
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
                            case "serial":
                                result = endPoint.GetBySerialOrNull(value);
                                break;
                            case "tag":
                                result = endPoint.GetByTagOrNull(value);
                                break;
                            case "search":
                                try
                                {
                                    result = (endPoint.FindOne(value), null);
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
                                return (endPoint.FindOne(value), null);
                            } catch(Exception e)
                            {
                                return (null, e);
                            }
                        else
                            return result;
                    }
                case BindingQueryUnion.Type.Integer:
                    return endPoint.GetOrNull(QueryUnion.IntegerValue);
                default:
                    return (null, new InvalidOperationException("Cannot resolve an invalid binding."));
            }
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
