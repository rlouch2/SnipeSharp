using SnipeSharp.Common;
using SnipeSharp.Attributes;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.Models
{
    [EndPointInformation(BaseUri: "accessories", NotFoundMessage: "Accessory not found")]
    public class Accessory : CommonEndpointModel
    {
        [DeserializeAs(Name = "company")]
        [SerializeAs(Name = "company_id")]
        public Company Company { get; set; }

        [DeserializeAs(Name = "manufacturer")]
        [SerializeAs(Name = "manufacturer_id")]
        public Manufacturer Manufacturer { get; set; }

        [DeserializeAs(Name = "supplier")]
        [SerializeAs(Name = "supplier_id")]
        public Supplier Supplier { get; set; }

        [DeserializeAs(Name = "model_number")]
        [SerializeAs(Name = "model_number")]
        public string ModelNumber { get; set; }        

        [DeserializeAs(Name = "category")]
        [SerializeAs(Name = "category_id")]
        [RequiredField]
        public Category Category { get; set; }

        [DeserializeAs(Name = "location")]
        [SerializeAs(Name = "location_id")]
        public Location Location { get; set; }

        [DeserializeAs(Name = "notes")]
        [SerializeAs(Name = "notes")]
        public string Notes { get; set; }

        [DeserializeAs(Name = "qty")]
        [SerializeAs(Name = "qty")]
        [RequiredField]
        public long? Quantity { get; set; }

        [DeserializeAs(Name = "purchase_date")]
        [SerializeAs(Name = "purchase_date")]
        public ResponseDate PurchaseDate { get; set; }

        [DeserializeAs(Name = "purchase_cost")]
        [SerializeAs(Name = "purchase_cost")]
        public string PurchaseCost { get; set; }

        [DeserializeAs(Name = "order_number")]
        [SerializeAs(Name = "order_number")]
        public string OrderNumber { get; set; }

        [DeserializeAs(Name = "min_qty")]
        [SerializeAs(Name = "min_qty")]
        public long? MinQty { get; set; }

        [DeserializeAs(Name = "remaining_qty")]
        public long? RemainingQty { get; set; }

        [DeserializeAs(Name = "image")]
        public string Image { get; set; }

        [DeserializeAs(Name = "user_can_checkout")]
        public bool UserCanCheckout { get; set; }
    }
}
