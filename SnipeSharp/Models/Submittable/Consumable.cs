using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A Consumable.
    /// Consumables may be checked out to Users, but unlike Accessories cannot be checked back in.
    /// </summary>
    [PathSegment("consumables")]
    public sealed class Consumable : CommonEndPointModel, IAvailableActions, IUpdatable<Consumable>
    {
        /// <summary>Create a new Consumable object.</summary>
        public Consumable() { }

        /// <summary>Create a new Consumable object with the supplied ID, for use with updating.</summary>
        internal Consumable(int id)
        {
            Id = id;
        }

        /// <inheritdoc />
        [Field(DeserializeAs = "id")]
        public override int Id { get; set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("name", IsRequired = true)]
        public override string Name { get; set; }

        /// <value>Gets the URL of the image for this consumable.</value>
        /// <remarks>Currently, this field is not fillable.</remarks>
        [Field(DeserializeAs = "image")]
        public Uri ImageUri { get; private set; }

        /// <value>Gets/sets the category of the consumable.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// <para>The Category must have the CategoryType "Consumable" for the change to be realized in the API; the API won't stop you from giving anything a Category of the wrong type, though.</para>
        /// <para>This field is required.</para>
        /// </remarks>
        [Field(DeserializeAs = "category", SerializeAs = "category_id", Converter = CommonModelConverter, IsRequired = true)]
        public Category Category { get; set; }

        /// <value>Gets/sets the company that owns this consumable.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "company", SerializeAs = "company_id", Converter = CommonModelConverter)]
        public Company Company { get; set; }

        /// <value>Gets/sets the item number of this consumable.</value>
        [Field("item_no")]
        public string ItemNumber { get; set; }

        /// <value>Gets/sets location for this consumable.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "location", SerializeAs = "location_id", Converter = CommonModelConverter)]
        public Location Location { get; set; }

        /// <value>Gets/sets the manufacturer who produced this consumable.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "manufacturer", SerializeAs = "manufacturer_id", Converter = CommonModelConverter)]
        public Manufacturer Manufacturer { get; set; }

        /// <value>Gets/sets the total quantity of this consumable.</value>
        /// <remarks>This field is required.</remarks>
        [Field("qty", IsRequired = true)]
        public int? Quantity { get; set; }

        /// <value>Gets/sets the minimum quantity of this consumable before an alert is raised.</value>
        [Field(DeserializeAs = "min_amt")]
        public int? MinimumQuantity { get; set; }

        /// <value>Gets/sets the model number of this consumable.</value>
        [Field("model_number")]
        public string ModelNumber { get; set; }

        /// <value>Gets the remaining quantity of this consumable.</value>
        [Field(DeserializeAs = "remaining")]
        public int? RemainingQuantity { get; private set; }

        /// <value>Gets/sets the order number associated with this consumable's purchase.</value>
        [Field("order_number")]
        public string OrderNumber { get; set; }

        /// <value>The cost of this Consumable when purchased.</value>
        [Field("purchase_cost")]
        public decimal? PurchaseCost { get; set; }

        /// <value>The date this Consumable was purchased.</value>
        [Field("purchase_date", Converter = DateTimeConverter)]
        public DateTime? PurchaseDate { get; set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <value>Gets whether this consumable can be checked out or not.</value>
        [Field(DeserializeAs = "user_can_checkout")]
        public bool? UserCanCheckOut { get; private set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; private set; }

        /// <value>Gets/sets if this consumable is requestable or not.</value>
        [Field("requestable")]
        public bool? IsRequestable { get; set; }

        /// <inheritdoc />
        public Consumable CloneForUpdate() => new Consumable(this.Id);

        /// <inheritdoc />
        public Consumable WithValuesFrom(Consumable other)
            => new Consumable(this.Id)
            {
                Name = other.Name,
                ImageUri = other.ImageUri,
                Category = other.Category,
                Company = other.Company,
                ItemNumber = other.ItemNumber,
                Location = other.Location,
                Manufacturer = other.Manufacturer,
                Quantity = other.Quantity,
                MinimumQuantity = other.MinimumQuantity,
                ModelNumber = other.ModelNumber,
                OrderNumber = other.OrderNumber,
                PurchaseCost = other.PurchaseCost,
                PurchaseDate = other.PurchaseDate,
                IsRequestable = other.IsRequestable
            };
    }
}
