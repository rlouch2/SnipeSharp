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
    public sealed class Component : CommonEndPointModel, IAvailableActions
    {
        /// <inheritdoc />
        [Field("id")]
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("name", true, required: true)]
        public override string Name { get; set; }

        /// <value>The URL of the image for the component.</value>
        [Field("image")]
        public Uri ImageUri { get; private set; }

        /// <value>Gets/sets the serial number for the component.</value>
        [Field("serial", true)]
        public string Serial { get; set; }

        /// <value>Gets/sets the component's location.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("location", "location_id", converter: CommonModelConverter)]
        public Location Location { get; set; }

        /// <value>Gets/sets the total quantity of this component.</value>
        /// <remarks>
        /// <para>This value must be greater than or equal to one.</para>
        /// <para>This field is required.</para>
        /// </remarks>
        [Field("qty", true, required: true)]
        public int Quantity { get; set; }

        /// <value>Gets/sets the minimum quantity before an alert should pop up</value>
        [Field("min_amt", true)]
        public int? MinimumQuantity { get; set; }

        /// <value>Gets/sets the Category this Component is in.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// <para>The Category must have the CategoryType "Component" for the change to be realized in the API; the API won't stop you from giving anything a Category of the wrong type, though.</para>
        /// <para>This field is required.</para>
        /// </remarks>
        [Field("category", "category_id", converter: CommonModelConverter, required: true)]
        public Category Category { get; set; }

        /// <value>The order number associated with this Components's purchase.</value>
        [Field("order_number", true)]
        public string OrderNumber { get; set; }

        /// <value>The date this Component was purchased.</value>
        [Field("purchase_date", true, converter: DateTimeConverter)]
        public DateTime? PurchaseDate { get; set; }

        /// <value>Gets/sets the cost of this Component when purchased.</value>
        [Field("purchase_cost", true)]
        public decimal? PurchaseCost { get; set; }

        /// <value>The quantity of this Component that has not yet been checked out.</value>
        [Field("remaining")]
        public int? RemainingQuantity { get; private set; }

        /// <value>The Company this Accessory belongs to.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("company", "company_id", converter: CommonModelConverter)]
        public Company Company { get; set; }

        /// <inheritdoc />
        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <value>Indicates that this accessory is available to be checked out.</value>
        [Field("user_can_checkout")]
        public bool? UserCanCheckOut { get; private set; }

        /// <inheritdoc />
        [Field("available_actions", converter: AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }
    }
}
