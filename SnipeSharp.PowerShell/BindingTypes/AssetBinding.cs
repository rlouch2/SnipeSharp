using System;
using System.Collections.Generic;
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
        /// Fetches a single Asset using a simplified query. The query is of the form "[type:]value". Valid types are: name, iname, cname, serial, tag, id, and search.
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
        internal AssetBinding(string query, ApiOptionalMultiResponse<Asset> apiOptionalResponse): base(query, apiOptionalResponse)
        {
        }

        /// <inheritdoc />
        internal override void Resolve(ISearchFilter filter = null)
        {
            if(null != _objects)
                return;
            try
            {
                var endPoint = ApiHelper.Instance.Assets;
                if(BindingType.Integer == QueryUnion.Type)
                {
                    var result = endPoint.GetOptional(QueryUnion.IntegerValue);
                    Value = result.HasValue ? new Asset[] { result.Value } : new Asset[0];
                    Error = result.Exception;
                } else if(BindingType.String == QueryUnion.Type)
                {
                    int id; // used later for parsing integers
                    ApiOptionalResponse<Asset> result;
                    ApiOptionalMultiResponse<Asset> multiResponse; // used later for retrieving by serial
                    switch(ParseQuery(QueryUnion.StringValue, out var tag, out var value))
                    {
                        case BindingQueryType.Absent:
                            // tag -> serial -> name -> id
                            result = endPoint.GetByTagOptional(value);
                            if(result.HasValue)
                                break;
                            multiResponse = endPoint.FindBySerialOptional(value);
                            if(multiResponse.HasValue)
                            {
                                Value = multiResponse.Value;
                                Error = multiResponse.Exception;
                                return;
                            }
                            result = endPoint.GetOptional(value, QueryUnion.CaseSensitive);
                            if(result.HasValue)
                                break;
                            else if(int.TryParse(value, out id))
                                result = endPoint.GetOptional(id);
                            else
                                // fall back to search as the last-ditch try.
                                goto case BindingQueryType.Search;
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
                                result = new ApiOptionalResponse<Asset> { Exception = new ArgumentException($"Id is not an integer: {value}", "query") };
                            break;
                        case BindingQueryType.Serial:
                            multiResponse = endPoint.FindBySerialOptional(value);
                            Error = multiResponse.Exception ?? new ArgumentException($"Cannot find an asset with serial number: {value}", "query");
                            Value = multiResponse.HasValue ? multiResponse.Value : (IReadOnlyList<Asset>)new Asset[0];
                            return;
                        case BindingQueryType.AssetTag:
                            result = endPoint.GetByTagOptional(value);
                            break;
                        default:
                            // by default, try searching for the whole thing
                        case BindingQueryType.Search:
                            if(null != filter)
                                filter = new SearchFilter();
                            filter.Search = value;
                            multiResponse = endPoint.FindAllOptional(filter);
                            Error = multiResponse.Exception;
                            Value = multiResponse.HasValue ? multiResponse.Value : (IReadOnlyList<Asset>)new Asset[0];
                            return;
                    }
                    Value = result.HasValue ? new Asset[] { result.Value } : new Asset[0];
                    Error = result.Exception;
                } else
                {
                    Value = new Asset[0];
                    Error = new InvalidOperationException("Cannot resolve an invalid binding.");
                }
            } catch(Exception ex)
            {
                // let later error-handling mechanisms deal with any errors we encountered.
                Value = new Asset[0];
                Error = ex;
            }
        }

        internal static AssetBinding FromTag(string tag)
            => new AssetBinding(tag, ApiHelper.Instance.Assets.GetByTagOptional(tag));
        internal static AssetBinding FromSerial(string serial)
            => new AssetBinding(serial, ApiHelper.Instance.Assets.FindBySerialOptional(serial));
    }
}
