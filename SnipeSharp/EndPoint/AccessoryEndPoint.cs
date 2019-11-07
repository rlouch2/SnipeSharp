using SnipeSharp.Models;

namespace SnipeSharp.EndPoint
{
    public sealed class AccessoryEndPoint : EndPoint<Accessory>
    {
        // TODO: docs
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
