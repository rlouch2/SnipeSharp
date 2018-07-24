using SnipeSharp.Attributes;
using SnipeSharp.Endpoints.Models;
using System;
using System.Linq;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.EndpointHelpers
{
    public class AssetCheckoutRequest
    {
        [SerializeAs(Name = "checkout_to_type")]
        public string CheckOutToType { get; set; }

        [SerializeAs(Name = "assigned_location")]
        public Location AssignedLocation { get; set; }

        [SerializeAs(Name = "assigned_asset")]
        public Asset AssignedAsset { get; set; }

        [SerializeAs(Name = "assigned_user")]
        public User AssignedUser { get; set; }

        [SerializeAs(Name = "note")]
        public string Note { get; set; }

        [SerializeAs(Name = "expected_checkin")]
        public string ExpectedCheckIn { get; set; } // TODO: Make this a date object

        [SerializeAs(Name = "checkout_at")]
        public string CheckOutAt { get; set; }  // TODO: Make this a date object

        [SerializeAs(Name = "name")]
        public string Name { get; set; }
    }
}
