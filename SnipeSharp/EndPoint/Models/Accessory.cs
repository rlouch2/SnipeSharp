using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// An Accessory.
    /// Accessories may be checked out to Users.
    /// </summary>
    [PathSegment("accessories")]
    public sealed class Accessory : CommonEndPointModel, IAvailableActions
    {
        /// <summary>
        /// The Id for the Accessory in Snipe-IT.
        /// </summary>
        [Field("id")]
        public override int Id { get; set; }

        /// <summary>
        /// The Name of the Accessory in Snipe-IT.
        /// </summary>
        /// <remarks>This field is required.</remarks>
        [Field("name", true, required: true)]
        public override string Name { get; set; }

        /// <summary>
        /// The Company this Accessory belongs to.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("company", "company_id", converter: CommonModelConverter)]
        public Company Company { get; set; }

        /// <summary>
        /// The Manufacturer that made this Accessory.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("manufacturer", "manufacturer_id", converter: CommonModelConverter, required: true)]
        public Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// The Supplier that sold this Accessory.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("supplier", "supplier_id", converter: CommonModelConverter)]
        public Supplier Supplier { get; set; }

        /// <summary>
        /// The ModelNumber of this Accessory.
        /// </summary>
        [Field("model_number", true)]
        public string ModelNumber { get; set; }

        /// <summary>
        /// The Category this Accessory is in.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// <para>The Category must have the CategoryType "Accessory" for the change to be realized in the API; the API won't stop you from giving anything a Category of the wrong type, though.</para>
        /// </remarks>
        [Field("category", "category_id", converter: CommonModelConverter, required: true)]
        public Category Category { get; set; }

        /// <summary>
        /// The Location this Accessory is in.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("location", "location_id", converter: CommonModelConverter)]
        public Location Location { get; set; }

        /// <summary>
        /// The total quantity of this Accessory.
        /// </summary>
        /// <remarks>This value must be greater than one.</remarks>
        [Field("qty", true, required: true)]
        public int Quantity { get; set; }

        /// <summary>
        /// The date this Accessory was purchased.
        /// </summary>
        [Field("purchase_date", true, converter: DateTimeConverter)]
        public DateTime? PurchaseDate { get; set; }

        /// <summary>
        /// The cost of this Accessory when purchased.
        /// </summary>
        [Field("purchase_cost", true)]
        public decimal? PurchaseCost { get; set; }

        /// <summary>
        /// The order number associated with this Accessory's purchase.
        /// </summary>
        /// <remarks>A single Accessory only has one OrderNumber field. Multiple orders should use multiple Accessories of the same ModelNumber, IIRC.</remarks>
        [Field("order_number", true)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// The Minimum quantity of this Accessory before an alert should pop up.
        /// </summary>
        [Field("min_qty")]
        public int? MinimumQuantity { get; set; }

        /// <summary>
        /// The quantity of this Accessory that has not yet been checked out.
        /// </summary>
        [Field("remaining_qty")]
        public int? RemainingQuantity { get; set; }

        /// <summary>
        /// The Url of the image for this Accessory in the web interface.
        /// </summary>
        [Field("image", true)]
        public Uri ImageUri { get; set; }

        /// <inheritdoc />
        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; set; }

        /// <inheritdoc />
        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; set; }

        /// <inheritdoc />
        [Field("available_actions", converter: AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }

        /// <summary>
        /// Indicates that this accessory is available to be checked out.
        /// </summary>
        [Field("user_can_checkout")]
        public bool? CanUserCheckOut { get; set; }

        /* NOT_IMPL: This field is currently not readable from the API, nor used in SnipeIT.
         * [Field(null, "requestable")]
         * public bool? IsRequestable { get; set; }
         */
    }
}
