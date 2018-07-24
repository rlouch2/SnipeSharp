using SnipeSharp.Attributes;
using SnipeSharp.Common;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.Models
{
    [EndPointInformation(BaseUri: "licenses", NotFoundMessage: "License not found")]
    public class License : CommonEndpointModel
    {
        [DeserializeAs(Name = "company")]
        public Company Company { get; set; }

        [DeserializeAs(Name = "expiration_date")]
        public Date ExpirationDate { get; set; }

        [DeserializeAs(Name = "free_seats_count")]
        public long? FreeSeatsCount { get; set; }

        [DeserializeAs(Name = "license_email")]
        public string LicenseEmail { get; set; }

        [DeserializeAs(Name = "license_name")]
        public string LicenseName { get; set; }

        [DeserializeAs(Name = "maintained")]
        public bool Maintained { get; set; }

        [DeserializeAs(Name = "manufacturer")]
        public Manufacturer Manufacturer { get; set; }

        [DeserializeAs(Name = "notes")]
        public string Notes { get; set; }

        [DeserializeAs(Name = "order_number")]
        public string OrderNumber { get; set; }

        [DeserializeAs(Name = "product_key")]
        public string ProductKey { get; set; }

        [DeserializeAs(Name = "purchase_cost")]
        public string PurchaseCost { get; set; }

        [DeserializeAs(Name = "purchase_date")]
        public Date PurchaseDate { get; set; }

        [DeserializeAs(Name = "purchase_order")]
        public string PurchaseOrder { get; set; }

        [DeserializeAs(Name = "seats")]
        public long Seats { get; set; }

        [DeserializeAs(Name = "supplier")]
        public Company Supplier { get; set; }

        [DeserializeAs(Name = "user_can_checkout")]
        public bool UserCanCheckout { get; set; }
    }
}
