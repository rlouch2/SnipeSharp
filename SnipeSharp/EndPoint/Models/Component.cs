using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// A Component.
    /// Components may be checked out to Assets.
    /// </summary>
    [PathSegment("components")]
    public sealed class Component : CommonEndPointModel
    {
        [Field("id")]
        public override int Id { get; protected set; }

        [Field("name", true, required: true)]
        public override string Name { get; set; }

        [Field("image")]
        public Uri ImageUri { get; set; }

        [Field("serial", true)]
        public string Serial { get; set; }

        [Field("location", "location_id", converter: CommonModelConverter)]
        public Location Location { get; set; }

        [Field("qty", true, required: true)]
        public int Quantity { get; set; }

        [Field("min_amt", true)]
        public int? MinimumQuantity { get; set; }

        [Field("category", "category_id", converter: CommonModelConverter, required: true)]
        public Category Category { get; set; }

        [Field("order_number", true)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// The date this Component was purchased.
        /// </summary>
        [Field("purchase_date", true, converter: DateTimeConverter)]
        public DateTime? PurchaseDate { get; set; }

        /// <summary>
        /// The cost of this Component when purchased.
        /// </summary>
        [Field("purchase_cost", true)]
        public decimal? PurchaseCost { get; set; }

        [Field("remaining")]
        public int? RemainingQuantity { get; set; }

        [Field("company", "company_id", converter: CommonModelConverter)]
        public Company Company { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        [Field("user_can_checkout")]
        public bool? UserCanCheckOut { get; set; }

        [Field("available_actions", converter: AvailableActionsConverter)]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }

    public sealed class ComponentAsset : ApiObject
    {
        [Field("assigned_pivot_id")]
        public int ComponentId { get; set; }
        
        [Field("id")]
        public int AssetId { get; set; }
        
        [Field("name")]
        public string Name { get; set; }
        
        [Field("qty")]
        public int Quantity { get; set; }

        [Field("type")]
        public string Type { get; set; }
        
        [Field("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Field("available_actions", converter: AvailableActionsConverter)]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }
}
