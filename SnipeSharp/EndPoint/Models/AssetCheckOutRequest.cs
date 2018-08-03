using System;
using SnipeSharp.Serialization;

namespace SnipeSharp.EndPoint.Models
{
    public sealed class AssetCheckOutRequest : ApiObject
    {
        public Asset Asset { get; private set; }

        [Field("assigned_location", true)]
        public Location AssignedLocation { get; private set; }

        [Field("assigned_asset", true)]
        public Asset AssignedAsset { get; private set; }

        [Field("assigned_user", true)]
        public User AssignedUser { get; private set; }

        [Field("checkout_to_type", true)]
        public AssignedToType AssignedToType { get; private set; }

        [Field("checkout_at", true)]
        public DateTime? CheckOutAt { get; set; }

        [Field("expected_checkin", true)]
        public DateTime? ExpectedCheckIn { get; set; }

        [Field("note", true)]
        public string Note { get; set; }

        [Field("name", true)]
        public string AssetName { get; set; }

        public AssetCheckOutRequest(Asset asset, Location location)
        {
            Asset = asset;
            AssignedLocation = location;
            AssignedToType = AssignedToType.Location;
        }

        public AssetCheckOutRequest(Asset asset, User user)
        {
            Asset = asset;
            AssignedUser = user;
            AssignedToType = AssignedToType.User;
        }

        public AssetCheckOutRequest(Asset asset, Asset assignedAsset)
        {
            Asset = asset;
            AssignedAsset = assignedAsset;
            AssignedToType = AssignedToType.Asset;
        }
    }
}
