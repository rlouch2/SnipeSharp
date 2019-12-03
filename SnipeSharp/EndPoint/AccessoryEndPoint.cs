using SnipeSharp.Models;

namespace SnipeSharp.EndPoint
{
    /// <summary>
    /// Provides additional methods for the Accessory endpoint.
    /// </summary>
    public sealed class AccessoryEndPoint : EndPoint<Accessory>
    {
        /// <param name="api">The Api to grab the RequestManager from.</param>
        /// <exception cref="SnipeSharp.Exceptions.MissingRequiredAttributeException">When the type parameter does not have the <see cref="PathSegmentAttribute">PathSegmentAttribute</see> attribute.</exception>
        internal AccessoryEndPoint(SnipeItApi api) : base(api) {}

        /// <summary>
        /// Get the list of accessory check outs for an accessory.
        /// </summary>
        /// <param name="accessory">The accessory to get the check-out list of.</param>
        /// <returns>A ResponseCollection list of AccessoryCheckOuts.</returns>
        public ResponseCollection<AccessoryCheckOut> GetCheckedOut(Accessory accessory)
            => Api.RequestManager.GetAll<AccessoryCheckOut>($"{EndPointInfo.BaseUri}/{accessory.Id}/checkedout").RethrowExceptionIfAny().Value;
    }
}
