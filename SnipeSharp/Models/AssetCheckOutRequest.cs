using System;
using SnipeSharp.Serialization;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A request to associate an Asset with a User, Location, or other Asset.
    /// </summary>
    public sealed class AssetCheckOutRequest : ApiObject
    {
        /// <value>The Asset that will be checked out.</value>
        /// <remarks>This property is not serialized, but instead used for its Id value.</remarks>
        public Asset Asset { get; private set; }

        /// <value>The assigned object, if it is a Location.</value>
        [Field("assigned_location", Converter = CommonModelConverter)]
        public Location AssignedLocation { get; private set; }

        /// <value>The assigned object, if it is an Asset.</value>
        [Field("assigned_asset", Converter = CommonModelConverter)]
        public Asset AssignedAsset { get; private set; }

        /// <value>The assigned object, if it is a User.</value>
        [Field("assigned_user", Converter = CommonModelConverter)]
        public User AssignedUser { get; private set; }

        /// <value>What the type of the assigned object is.</value>
        [Field("checkout_to_type")]
        public AssignedToType AssignedToType { get; private set; }

        /// <value>The date the asset was checked out; if null, then the current timestamp.</value>
        [Field("checkout_at", Converter = DateTimeConverter)]
        public DateTime? CheckOutAt { get; set; }

        /// <value>The date the asset is expected to be checked back in.</value>
        [Field("expected_checkin", Converter = DateTimeConverter)]
        public DateTime? ExpectedCheckIn { get; set; }

        /// <value>The note to put in the log for this check-out event.</value>
        [Field("note")]
        public string Note { get; set; }

        /// <value>The new name of the Asset once it is checked out.</value>
        [Field("name")]
        public string AssetName { get; set; }

        /// <summary>
        /// Begins a new AssetCheckOutRequest assigning the supplied asset to the supplied location.
        /// </summary>
        /// <param name="asset">The asset to assign.</param>
        /// <param name="location">The Location to assign the asset to.</param>
        public AssetCheckOutRequest(Asset asset, Location location)
        {
            Asset = asset;
            AssignedLocation = location;
            AssignedToType = AssignedToType.Location;
        }

        /// <summary>
        /// Begins a new AssetCheckOutRequest assigning the supplied asset to the supplied user.
        /// </summary>
        /// <param name="asset">The asset to assign.</param>
        /// <param name="user">The User to assign the asset to.</param>
        public AssetCheckOutRequest(Asset asset, User user)
        {
            Asset = asset;
            AssignedUser = user;
            AssignedToType = AssignedToType.User;
        }

        /// <summary>
        /// Begins a new AssetCheckOutRequest assigning the supplied asset to another supplied asset.
        /// </summary>
        /// <param name="asset">The asset to assign.</param>
        /// <param name="assignedAsset">The asset to assign the asset to.</param>
        public AssetCheckOutRequest(Asset asset, Asset assignedAsset)
        {
            Asset = asset;
            AssignedAsset = assignedAsset;
            AssignedToType = AssignedToType.Asset;
        }
    }
}
