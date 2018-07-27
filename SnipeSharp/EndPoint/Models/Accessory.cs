using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;

namespace SnipeSharp.EndPoint.Models
{
    [EndPointInformation("accessories", "")]
    public class Accessory : CommonEndPointModel
    {
        [Field("id")]
        public override long Id { get; set; }

        [Field("name")]
        public override string Name { get; set; }

        [Field("company", SerializeAs = "company_id", SerializeToId = true)]
        public Company Company { get; set; }

        [Field("manufacturer", SerializeAs =  "manufacturer_id", SerializeToId = true)]
        public Manufacturer Manufacturer { get; set; }

        [Field("supplier", SerializeAs = "supplier_id", SerializeToId = true)]
        public Supplier Supplier { get; set; }

        [Field("model_number")]
        public string ModelNumber { get; set; }

        [Field("category", SerializeAs = "category_id", SerializeToId = true)]
        public Category Category { get; set; }

        [Field("location", SerializeAs = "location_id", SerializeToId = true)]
        public Location Location { get; set; }

        [Field("qty")]
        public int Quantity { get; set; }

        [Field("purchase_date")]
        public DateTime PurchaseDate { get; set; }

        [Field("purchase_cost")]
        public decimal PurchaseCost { get; set; }

        [Field("order_number")]
        public string OrderNumber { get; set; }

        [Field("min_qty")]
        public int? MinimumQuantity { get; set; }

        [Field("remaining_qty")]
        public int? RemainingQuantity { get; set; }

        [Field("image")]
        public Uri ImageUri { get; set; }

        [Field("created_at")]
        public override DateTime CreatedAt { get; set; }

        [Field("updated_at")]
        public override DateTime UpdatedAt { get; set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }

        [Field("user_can_checkout", CanSerialize = false)]
        public bool UserCanCheckOut { get; set; }
    }

    public sealed class AccessoryCheckOut : ApiObject
    {
        //TODO
    }
}