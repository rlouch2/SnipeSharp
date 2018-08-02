using SnipeSharp.Attributes;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.Models
{
    public class AssetCheckoutRequest : IQueryParameterProvider
    {
        [SerializeAs(Name = "checkout_to_type")]
        public string CheckOutToType { get; private set; }

        [SerializeAs(Name = "assigned_asset")]
        public Asset AssignedAsset { get; private set; }

        [SerializeAs(Name = "assigned_location")]
        public Location AssignedLocation { get; set; }

        [SerializeAs(Name = "assigned_user")]
        public User AssignedUser { get; private set; }

        [SerializeAs(Name = "note")]
        public string Note { get; set; }

        [SerializeAs(Name = "expected_checkin")]
        public string ExpectedCheckIn { get; set; } // TODO: Make this a date object

        [SerializeAs(Name = "checkout_at")]
        public string CheckOutAt { get; set; }  // TODO: Make this a date object

        [SerializeAs(Name = "name")]
        public string Name { get; set; }

        public AssetCheckoutRequest(Asset asset, User user){
            AssignedAsset = asset;
            AssignedUser = user;
            CheckOutToType = "user";
        }

        public AssetCheckoutRequest(Asset asset, Location location){
            AssignedAsset = asset;
            AssignedLocation = location;
            CheckOutToType = "location";
        }

        public virtual Dictionary<string, string> QueryParameters {
            get {
                var values = new Dictionary<string, string>();
                foreach(var property in this.GetType().GetProperties())
                {
                    var serializeAttribute = property.GetCustomAttribute<SerializeAsAttribute>();
                    if(serializeAttribute == null)
                        continue;
                    var value = property.GetValue(this)?.ToString();
                    if(value != null)
                        values[serializeAttribute.Name] = value;
                }
                return values;
            }
        }
    }
}
