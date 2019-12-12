using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A Component.
    /// Components may be checked out to Assets.
    /// </summary>
    [PathSegment("components")]
    public sealed class Component : CommonEndPointModel, IAvailableActions, IUpdatable<Component>
    {
        /// <summary>Create a new Component object.</summary>
        public Component() { }

        /// <summary>Create a new Component object with the supplied ID, for use with updating.</summary>
        internal Component(int id)
        {
            Id = id;
        }

        /// <inheritdoc />
        [Field(DeserializeAs = "id")]
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("name", IsRequired = true)]
        public override string Name { get; set; }

        /// <value>The URL of the image for the component.</value>
        [Field(DeserializeAs = "image")]
        public Uri ImageUri { get; private set; }

        /// <value>Gets/sets the serial number for the component.</value>
        [Field("serial")]
        public string Serial { get; set; }

        /// <value>Gets/sets the component's location.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "location", SerializeAs = "location_id", Converter = CommonModelConverter)]
        public Location Location { get; set; }

        /// <value>Gets/sets the total quantity of this component.</value>
        /// <remarks>
        /// <para>This value must be greater than or equal to one.</para>
        /// <para>This field is required.</para>
        /// </remarks>
        [Field("qty", IsRequired = true)]
        public int? Quantity { get; set; }

        /// <value>Gets/sets the minimum quantity before an alert should pop up</value>
        [Field("min_amt")]
        public int? MinimumQuantity { get; set; }

        /// <value>Gets/sets the Category this Component is in.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// <para>The Category must have the CategoryType "Component" for the change to be realized in the API; the API won't stop you from giving anything a Category of the wrong type, though.</para>
        /// <para>This field is required.</para>
        /// </remarks>
        [Field(DeserializeAs = "category", SerializeAs = "category_id", Converter = CommonModelConverter, IsRequired = true)]
        public Category Category { get; set; }

        /// <value>The order number associated with this Components's purchase.</value>
        [Field("order_number")]
        public string OrderNumber { get; set; }

        /// <value>The date this Component was purchased.</value>
        [Field("purchase_date", Converter = DateTimeConverter)]
        public DateTime? PurchaseDate { get; set; }

        /// <value>Gets/sets the cost of this Component when purchased.</value>
        [Field("purchase_cost")]
        public decimal? PurchaseCost { get; set; }

        /// <value>The quantity of this Component that has not yet been checked out.</value>
        [Field(DeserializeAs = "remaining")]
        public int? RemainingQuantity { get; private set; }

        /// <value>The Company this Accessory belongs to.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "company", SerializeAs = "company_id", Converter = CommonModelConverter)]
        public Company Company { get; set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <value>Indicates that this accessory is available to be checked out.</value>
        [Field(DeserializeAs = "user_can_checkout")]
        public bool? UserCanCheckOut { get; private set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }

        /// <inheritdoc />
        public Component CloneForUpdate() => new Component(this.Id);

        /// <inheritdoc />
        public Component WithValuesFrom(Component other)
            => new Component(this.Id)
            {
                Name = other.Name,
                Serial = other.Serial,
                Location = other.Location,
                Quantity = other.Quantity,
                MinimumQuantity = other.MinimumQuantity,
                Category = other.Category,
                OrderNumber = other.OrderNumber,
                PurchaseDate = other.PurchaseDate,
                PurchaseCost = other.PurchaseCost,
                Company = other.Company
            };
    }
}
