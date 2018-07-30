using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    public class Consumable : CommonEndPointModel
    {
        [Field("id")]
        public override long Id { get; set; }

        [Field("name")]
        public override string Name { get; set; }

        [Field("image")]
        public Uri ImageUri { get; set; }

        [Field("category", FieldConverter = SerializeToId)]
        public Category Category { get; set; }

        [Field("company", FieldConverter = SerializeToId)]
        public Company Company { get; set; }

        [Field("item_no")]
        public string ItemNumber { get; set; }

        [Field("location", FieldConverter = SerializeToId)]
        public Location Location { get; set; }

        [Field("manufacturer")]
        public Manufacturer Manufacturer { get; set; }

        [Field("min_amt")]
        public int? MinimumQuantity { get; set; }

        [Field("model_number")]
        public string ModelNumber { get; set; }

        [Field("remaining")]
        public int? RemainingQuantity { get; set; }

        [Field("order_number")]
        public string OrderNumber { get; set; }

        [Field("purchase_cost")]
        public decimal PurchaseCost { get; set; }

        [Field("purchase_date", FieldConverter = ExtractDateTime)]
        public DateTime? PurchaseDate { get; set; }

        [Field("qty")]
        public int? Quantity { get; set; }

        [Field("created_at")]
        public override DateTime? CreatedAt { get; set; }

        [Field("updated_at")]
        public override DateTime? UpdatedAt { get; set; }

        [Field("user_can_checkout")]
        public bool? CanUserCheckOut { get; set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }
}