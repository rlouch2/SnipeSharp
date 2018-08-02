using SnipeSharp.Attributes;
using SnipeSharp.Common;
using SnipeSharp.JsonConverters;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using Newtonsoft.Json;

namespace SnipeSharp.Endpoints.Models
{
    // TODO: Make constructor that forces required fields
    [EndPointInformation(BaseUri: "hardware", NotFoundMessage: "Asset not found")]
    public class Asset : CommonEndpointModel
    {

        [DeserializeAs(Name = "name")]
        [SerializeAs(Name = "name")]
        public new string Name { get; set; }

        [DeserializeAs(Name = "asset_tag")]
        [SerializeAs(Name = "asset_tag")]
        [RequiredField]
        public string AssetTag { get; set; }

        [DeserializeAs(Name = "serial")]
        [SerializeAs(Name = "serial")]
        public string Serial { get; set; }

        [DeserializeAs(Name = "model")]
        [SerializeAs(Name = "model_id")]
        public Model Model { get; set; }

        [DeserializeAs(Name = "model_number")]
        [SerializeAs(Name = "model_number")]
        public string ModelNumber { get; set; }

        [DeserializeAs(Name = "status_label")]
        [SerializeAs(Name = "status_id")]
        [RequiredField]
        public StatusLabel StatusLabel { get; set; }

        [DeserializeAs(Name = "category")]
        [SerializeAs(Name = "category_id")]
        public Category Category { get; set; }

        [DeserializeAs(Name = "manufacturer")]
        [SerializeAs(Name = "manufacturer_id")]
        public Manufacturer Manufacturer { get; set; }

        [DeserializeAs(Name = "supplier")]
        [SerializeAs(Name = "supplier_id")]
        public Supplier Supplier { get; set; }

        [DeserializeAs(Name = "notes")]
        [SerializeAs(Name = "notes")]
        public string Notes { get; set; }

        [DeserializeAs(Name = "company")]
        [SerializeAs(Name = "company_id")]
        public Company Company { get; set; }

        [DeserializeAs(Name = "location")]
        [SerializeAs(Name = "location_id")]
        public Location Location { get; set; }

        [DeserializeAs(Name = "rtd_location")]
        [SerializeAs(Name = "rtd_location_id")]
        public Location RtdLocation { get; set; }

        [DeserializeAs(Name = "image")]
        public string Image { get; set; }

        [DeserializeAs(Name = "assigned_to")]
        [SerializeAs(Name = "assigned_to")]
        public User AssignedTo { get; set; }

        private string _warrantyMonths;

        [DeserializeAs(Name = "warranty_months")]
        [SerializeAs(Name = "warranty_months")]
        public string WarrantyMonths
        {
            get { return _warrantyMonths; }
            set
            {

                _warrantyMonths = (value != null) ? value.Replace(" months", "") : null;
            }
        }

        [DeserializeAs(Name = "warranty_expires")]
        public ResponseDate WarrantyExpires { get; set; }

        [DeserializeAs(Name = "deleted_at")]
        public ResponseDate DeletedAt { get; set; }

        [DeserializeAs(Name = "purchase_date")]
        [SerializeAs(Name = "purchase_date")]
        [JsonConverter(typeof(ResponseDateTimeConverter))]
        public ResponseDate PurchaseDate { get; set; }

        [DeserializeAs(Name = "expected_checkin")]
        public ResponseDate ExpectedCheckin { get; set; }

        [DeserializeAs(Name = "last_checkout")]
        [SerializeAs(Name = "last_checkout")]
        public ResponseDate LastCheckout { get; set; }

        [DeserializeAs(Name = "purchase_cost")]
        [SerializeAs(Name = "purchase_cost")]
        public string PurchaseCost { get; set; }

        [DeserializeAs(Name = "user_can_checkout")]
        public bool UserCanCheckout { get; set; }

        [DeserializeAs(Name = "order_number")]
        [SerializeAs(Name = "order_number")]
        public string OrderNumber { get; set; }

        [DeserializeAs(Name = "custom_fields")]
        [JsonConverter(typeof(CustomFieldConverter))]
        public Dictionary<string,string> CustomFields { get; set; }

        /// <summary>
        /// Loop through all properties of this model, looking for any tagged with our custom attributes that we need
        /// to send as request headers
        /// </summary>
        /// <returns>Dictionary of header values</returns>
        public override Dictionary<string, string> QueryParameters
        {
            get {
                var values = base.QueryParameters;
                foreach(var pair in CustomFields)
                    values[pair.Key] = pair.Value;
                return values;
            }
        }
    }
}
