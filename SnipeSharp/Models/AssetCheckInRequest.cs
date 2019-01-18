using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A request to disassociate an Asset from a User, Location, or other Asset.
    /// </summary>
    public sealed class AssetCheckInRequest : ApiObject
    {
        /// <value>The Asset that will be checked in.</value>
        /// <remarks>This property is not serialized, but instead used for its Id value.</remarks>
        public Asset Asset { get; private set; }

        /// <value>The new name of the Asset once it is checked out.</value>
        [Field("name", IsRequired = true)]
        public string AssetName { get; set; }

        /// <value>The note to put in the log for this check-out event.</value>
        [Field("note")]
        public string Note { get; set; }

        /// <value>The new location for the Asset; if null, then the asset's default location will be used.</value>
        [Field("location_id", Converter = CommonModelConverter)]
        public Location Location { get; set; }

        /// <value>The new status for the Asset; if null, the status will not be changed.</value>
        [Field("status_id", Converter = CommonModelConverter)]
        public StatusLabel StatusLabel { get; set; }

        /// <summary>
        /// Begins a new AssetCheckInRequest disassociating the supplied asset from its assignee.
        /// </summary>
        /// <param name="asset">The asset to check in.</param>
        public AssetCheckInRequest(Asset asset)
        {
            Asset = asset;
        }
    }
}
