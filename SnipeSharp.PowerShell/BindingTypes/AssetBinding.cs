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
        internal AssetBinding(string query, ApiOptionalResponse<Asset> apiOptionalResponse): base(query, apiOptionalResponse)
        {
        }

        /// <summary>
        /// For use with the internal From* functions.
        /// </summary>
        internal AssetBinding(string query, ApiOptionalResponse<ResponseCollection<Asset>> apiOptionalResponse): base(query, apiOptionalResponse)
        {
        }

        /// <inheritdoc />
        internal override void Resolve(ISearchFilter filter = null)
        {
            var endPoint = ApiHelper.Instance.GetEndPoint<Asset>();
            ApiOptionalResponse<Asset> result;

            switch(QueryUnion.BindingType)
            {
                case BindingQueryUnion.Type.String:
                    var (type, value) = ParseQuery(QueryUnion.StringValue);

                    if(type is null)
                    {
                        // tag -> serial -> name -> id
                        result = endPoint.GetByTagOptional(value);
                        if(result.HasValue)
                            break;
                        var multiResponse = endPoint.FindBySerialOptional(value);
                        if(multiResponse.HasValue)
                        {
                            Value = multiResponse.Value;
                            Error = multiResponse.Exception;
                            return;
                        }
                        result = endPoint.GetOptional(value, QueryUnion.CaseSensitive);
                        if(result.HasValue)
                            break;
                        else if(int.TryParse(value, out var id))
                            result = endPoint.GetOptional(id);
                        else
                            result = new ApiOptionalResponse<Asset> { Exception = new ArgumentException($"Cannot find an object for query: {value}", "query") };
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
                                    result = new ApiOptionalResponse<Asset> { Exception = new ArgumentException($"Id is not an integer: {value}", "query") };
                                break;
                            case "serial":
                                var multiResponse = endPoint.FindBySerialOptional(value);
                                if(multiResponse.HasValue)
                                {
                                    Value = multiResponse.Value;
                                    Error = multiResponse.Exception;
                                    return;
                                } else
                                {
                                    result = new ApiOptionalResponse<Asset>
                                    {
                                        Value = null,
                                        Exception = multiResponse.Exception ?? new ArgumentException($"Cannot find an object with serial number: {value}", "query")
                                    };
                                }
                                break;
                            case "tag":
                                result = endPoint.GetByTagOptional(value);
                                break;
                            case "search":
                                try
                                {
                                    result = endPoint.FindOneOptional(value);
                                } catch(Exception e)
                                {
                                    result = new ApiOptionalResponse<Asset> { Exception = e };
                                }
                                break;
                            default:
                                result = new ApiOptionalResponse<Asset> { Exception = new ArgumentException($"Query does not have a proper type: {type}", "query") };
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
                                result = new ApiOptionalResponse<Asset> { Exception = e };
                            }
                        }
                    }
                    break;
                case BindingQueryUnion.Type.Integer:
                    result = endPoint.GetOptional(QueryUnion.IntegerValue);
                    break;
                default:
                    result = new ApiOptionalResponse<Asset> { Exception = new InvalidOperationException("Cannot resolve an invalid binding.") };
                    break;
            }
        }

        internal static AssetBinding FromTag(string tag)
            => new AssetBinding(tag, ApiHelper.Instance.Assets.GetByTagOptional(tag));
        internal static AssetBinding FromSerial(string serial)
            => new AssetBinding(serial, ApiHelper.Instance.Assets.FindBySerialOptional(serial));
    }
}
