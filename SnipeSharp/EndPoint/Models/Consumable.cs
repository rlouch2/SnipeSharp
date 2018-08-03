using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [PathSegment("consumables")]
    public sealed class Consumable : CommonEndPointModel
    {
        [Field("id")]
        public override int Id { get; protected set; }

        [Field("name", true)]
        public override string Name { get; set; }

        [Field("image")]
        public Uri ImageUri { get; set; }

        [Field("category", "category_id", converter: CommonModelConverter)]
        public Category Category { get; set; }

        [Field("company", "company_id", converter: CommonModelConverter)]
        public Company Company { get; set; }

        [Field("item_no", true)]
        public string ItemNumber { get; set; }

        [Field("location", "location_id", converter: CommonModelConverter)]
        public Location Location { get; set; }

        [Field("manufacturer", "manufacturer_id", converter: CommonModelConverter)]
        public Manufacturer Manufacturer { get; set; }

        [Field("min_amt")]
        public int? MinimumQuantity { get; set; }

        [Field("model_number", true)]
        public string ModelNumber { get; set; }

        [Field("remaining")]
        public int? RemainingQuantity { get; set; }

        [Field("order_number", true)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// The cost of this Consumable when purchased.
        /// </summary>
        [Field("purchase_cost", true)]
        public decimal? PurchaseCost { get; set; }

        /// <summary>
        /// The date this Consumable was purchased.
        /// </summary>
        [Field("purchase_date", true, converter: DateTimeConverter)]
        public DateTime? PurchaseDate { get; set; }

        [Field("qty", true)]
        public int? Quantity { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        [Field("user_can_checkout")]
        public bool? UserCanCheckOut { get; set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }

        [Field("requestable", true)]
        public bool? IsRequestable { get; set; }
    }
}
