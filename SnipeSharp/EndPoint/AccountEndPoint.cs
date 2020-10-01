using SnipeSharp.Filters;
using SnipeSharp.Models;

namespace SnipeSharp.EndPoint
{
    /// <summary>
    /// Methods for the Account endpoint.
    /// </summary>
    public sealed class AccountEndPoint
    {
        /// <summary>The API instance this endpoint is a part of.</summary>
        private readonly SnipeItApi Api;

        /// <summary>The path segment for this endpoint.</summary>
        private const string PathSegment = "account";

        /// <param name="api">The Api to grab the RequestManager from.</param>
        /// <exception cref="SnipeSharp.Exceptions.MissingRequiredAttributeException">When the type parameter does not have the <see cref="PathSegmentAttribute">PathSegmentAttribute</see> attribute.</exception>
        internal AccountEndPoint(SnipeItApi api)
        {
            Api = api;
        }

        /// <summary>
        /// Get all assets requestable by this account.
        /// </summary>
        public ResponseCollection<RequestableAsset> GetRequestableAssets(RequestableAssetSearchFilter filter = null)
            => Api.Client.GetMultiple<RequestableAsset>("account/requestable/hardware", filter).RethrowExceptionIfAny().Value;

        /// <summary>
        /// Get all assets requested by this account.
        /// </summary>
        public ResponseCollection<Request> GetRequests()
            => Api.Client.GetMultiple<Request>("account/requests").RethrowExceptionIfAny().Value;
    }
}
