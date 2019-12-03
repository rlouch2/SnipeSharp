using SnipeSharp.Serialization;
using SnipeSharp.Models.Enumerations;

namespace SnipeSharp.Models
{
    /// <summary>
    /// The status of an <see cref="Asset">Asset</see>.
    /// </summary>
    /// <remarks>Yes, it's not a <see cref="StatusLabel">StatusLabel</see>, but the Id's are the same.</remarks>
    /// <seealso cref="SnipeSharp.EndPoint.StatusLabelEndPoint.FromAssetStatus(AssetStatus)" />
    /// <seealso cref="SnipeSharp.Models.StatusLabel.ToAssetStatus" />
    public sealed class AssetStatus
    {
        /// <summary>
        /// The Id of the <see cref="StatusLabel">StatusLabel</see> in the SnipeIT database.
        /// </summary>
        [Field("id")]
        public int StatusId { get; set; }

        /// <summary>
        /// The friendly name of the status.
        /// </summary>
        /// <value></value>
        [Field(DeserializeAs = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The category of statuses that this StatusLabel fits in.
        /// </summary>
        /// <remarks>This will never be <see cref="StatusType.Deployed" />.</remarks>
        [Field(DeserializeAs = "status_type")]
        public StatusType? StatusType { get; set; }

        /// <summary>
        /// The actual category of statuses an asset with this status is in.
        /// </summary>
        /// <value>For deployed assets, this will be <see cref="StatusType.Deployed" />. Otherwise, the value will be the same as <see cref="AssetStatus.StatusType" />.</value>
        [Field(DeserializeAs = "status_meta")]
        public StatusType? StatusMeta { get; set; }
    }
}
