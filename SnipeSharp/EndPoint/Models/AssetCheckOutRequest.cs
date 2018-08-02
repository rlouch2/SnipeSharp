using System;
using SnipeSharp.Serialization;

namespace SnipeSharp.EndPoint.Models
{
    public sealed class AssetCheckOutRequest : ApiObject
    {
        public Asset Asset { get; private set; }

        [Field("assigned_location")]
        public Location AssignedLocation { get; private set; }

        [Field("assigned_asset")]
        public Asset AssignedAsset { get; private set; }

        [Field("assigned_user")]
        public User AssignedUser { get; private set; }

        [Field("checkout_to_type")]
        public AssignedToType CheckOutToType { get; private set; }

        [Field("checkout_at")]
        public DateTime? CheckOutAt { get; set; }

        [Field("expected_checkin")]
        public DateTime? ExpectedCheckIn { get; set; }

        [Field("note")]
        public string Note { get; set; }

        [Field("name")]
        public string AssetName { get; set; }

        public AssetCheckOutRequest(Asset asset, Location location)
        {
            Asset = asset;
            AssignedLocation = location;
            CheckOutToType = AssignedToType.Location;
        }

        public AssetCheckOutRequest(Asset asset, User user)
        {
            Asset = asset;
            AssignedUser = user;
            CheckOutToType = AssignedToType.User;
        }

        public AssetCheckOutRequest(Asset asset, Asset assignedAsset)
        {
            Asset = asset;
            AssignedAsset = assignedAsset;
            CheckOutToType = AssignedToType.Asset;
        }
    }
}