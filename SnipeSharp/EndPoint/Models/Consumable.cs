using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// A Consumable.
    /// Consumables may be checked out to Users, but unlike Accessories cannot be checked back in.
    /// </summary>
    [PathSegment("consumables")]
    public sealed class Consumable : CommonEndPointModel, IAvailableActions
    {
        /// <inheritdoc />
        [Field("id")]
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("name", true, required: true)]
        public override string Name { get; set; }

        /// <value>Gets the URL of the image for this consumable.</value>
        /// <remarks>Currently, this field is not fillable.</remarks>
        [Field("image")]
        public Uri ImageUri { get; private set; }

        /// <value>Gets/sets the category of the consumable.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// <para>The Category must have the CategoryType "Consumable" for the change to be realized in the API; the API won't stop you from giving anything a Category of the wrong type, though.</para>
        /// <para>This field is required.</para>
        /// </remarks>
        [Field("category", "category_id", converter: CommonModelConverter, required: true)]
        public Category Category { get; set; }

        /// <value>Gets/sets the company that owns this consumable.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("company", "company_id", converter: CommonModelConverter)]
        public Company Company { get; set; }

        /// <value>Gets/sets the item number of this consumable.</value>
        [Field("item_no", true)]
        public string ItemNumber { get; set; }

        /// <value>Gets/sets location for this consumable.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("location", "location_id", converter: CommonModelConverter)]
        public Location Location { get; set; }

        /// <value>Gets/sets the manufacturer who produced this consumable.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("manufacturer", "manufacturer_id", converter: CommonModelConverter)]
        public Manufacturer Manufacturer { get; set; }

        /// <value>Gets/sets the total quantity of this consumable.</value>
        /// <remarks>This field is required.</remarks>
        [Field("qty", true, required: true)]
        public int? Quantity { get; set; }

        /// <value>Gets/sets the minimum quantity of this consumable before an alert is raised.</value>
        [Field("min_amt")]
        public int? MinimumQuantity { get; set; }

        /// <value>Gets/sets the model number of this consumable.</value>
        [Field("model_number", true)]
        public string ModelNumber { get; set; }

        /// <value>Gets the remaining quantity of this consumable.</value>
        [Field("remaining")]
        public int? RemainingQuantity { get; private set; }

        /// <value>Gets/sets the order number associated with this consumable's purchase.</value>
        [Field("order_number", true)]
        public string OrderNumber { get; set; }

        /// <value>The cost of this Consumable when purchased.</value>
        [Field("purchase_cost", true)]
        public decimal? PurchaseCost { get; set; }

        /// <value>The date this Consumable was purchased.</value>
        [Field("purchase_date", true, converter: DateTimeConverter)]
        public DateTime? PurchaseDate { get; set; }

        /// <inheritdoc />
        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <value>Gets whether this consumable can be checked out or not.</value>
        [Field("user_can_checkout")]
        public bool? UserCanCheckOut { get; private set; }

        /// <inheritdoc />
        [Field("available_actions", converter: AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }

        /// <value>Gets/sets if this consumable is requestable or not.</value>
        [Field("requestable", true)]
        public bool? IsRequestable { get; set; }
    }
}
