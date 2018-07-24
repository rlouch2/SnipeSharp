using SnipeSharp.Attributes;
using SnipeSharp.Common;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.Models
{
    [EndPointInformation(BaseUri: "consumables", NotFoundMessage: "Consumable not found")]
    public class Consumable : CommonEndpointModel
    {
        [DeserializeAs(Name = "category")]
        [SerializeAs(Name = "category_id")]
        [RequiredField]
        public Category Category { get; set; }

        [DeserializeAs(Name = "company")]
        [SerializeAs(Name = "company_id")]
        public Company Company { get; set; }

        [DeserializeAs(Name = "item_no")]
        [SerializeAs(Name = "item_no")]
        public string ItemNo { get; set; }

        [DeserializeAs(Name = "location")]
        [SerializeAs(Name = "location_id")]
        public Location Location { get; set; }

        [DeserializeAs(Name = "manufacturer")]
        [SerializeAs(Name = "manufacturer_id")]
        public Manufacturer Manufacturer { get; set; }

        [DeserializeAs(Name = "min_amt")]
        [SerializeAs(Name = "min_amt")]
        public long? MinAmt { get; set; }

        [DeserializeAs(Name = "model_number")]
        [SerializeAs(Name = "model_number")]
        public string ModelNumber { get; set; }

        [DeserializeAs(Name = "remaining")]
        [SerializeAs(Name = "remaining")]
        public long? Remaining { get; set; }

        [DeserializeAs(Name = "order_number")]
        [SerializeAs(Name = "order_number")]
        public string OrderNumber { get; set; }

        [DeserializeAs(Name = "purchase_cost")]
        [SerializeAs(Name = "purchase_cost")]
        public string PurchaseCost { get; set; }

        [DeserializeAs(Name = "purchase_date")]
        [SerializeAs(Name = "purchase_date")]
        public ResponseDate PurchaseDate { get; set; }

        [DeserializeAs(Name = "qty")]
        [SerializeAs(Name = "qty")]
        [RequiredField]
        public long? Quantity { get; set; }

        [DeserializeAs(Name = "user_can_checkout")]
        public bool UserCanCheckout { get; set; }
    }
}
