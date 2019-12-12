using System;
using System.Collections.Generic;
using SnipeSharp.EndPoint;
using SnipeSharp.Serialization;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// An Accessory.
    /// Accessories may be checked out to Users, but unlike Consumables can be checked back in.
    /// </summary>
    [PathSegment("accessories")]
    public sealed class Accessory : CommonEndPointModel, IAvailableActions, IUpdatable<Accessory>
    {
        /// <summary>Create a new Accessory object.</summary>
        public Accessory() { }

        /// <summary>Create a new Accessory object with the supplied ID, for use with updating.</summary>
        internal Accessory(int id)
        {
            Id = id;
        }

        /// <inheritdoc/>
        [Field("id")]
        public override int Id { get; protected set; }

        /// <summary>
        /// The Name of the Accessory in Snipe-IT.
        /// </summary>
        /// <remarks>This field is required.</remarks>
        [Field("name", IsRequired = true)]
        public override string Name { get; set; }

        /// <summary>
        /// The Company this Accessory belongs to.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "company", SerializeAs = "company_id", Converter = CommonModelConverter)]
        public Company Company { get; set; }

        /// <summary>
        /// The Manufacturer that made this Accessory.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "manufacturer", SerializeAs = "manufacturer_id", Converter = CommonModelConverter, IsRequired = true)]
        public Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// The Supplier that sold this Accessory.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "supplier", SerializeAs = "supplier_id", Converter = CommonModelConverter)]
        public Supplier Supplier { get; set; }

        /// <summary>
        /// The ModelNumber of this Accessory.
        /// </summary>
        [Field("model_number")]
        public string ModelNumber { get; set; }

        /// <summary>
        /// The Category this Accessory is in.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// <para>The Category must have the CategoryType "Accessory" for the change to be realized in the API; the API won't stop you from giving anything a Category of the wrong type, though.</para>
        /// <para>This field is required.</para>
        /// </remarks>
        [Field(DeserializeAs = "category", SerializeAs = "category_id", Converter = CommonModelConverter, IsRequired = true)]
        public Category Category { get; set; }

        /// <summary>
        /// The Location this Accessory is in.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "location", SerializeAs = "location_id", Converter = CommonModelConverter)]
        public Location Location { get; set; }

        /// <summary>
        /// The total quantity of this Accessory.
        /// </summary>
        /// <remarks>
        /// <para>This value must be greater than or equal to one.</para>
        /// <para>This field is required.</para>
        /// </remarks>
        [Field("qty", IsRequired = true)]
        public int? Quantity { get; set; }

        /// <summary>
        /// The date this Accessory was purchased.
        /// </summary>
        [Field("purchase_date", Converter = DateTimeConverter)]
        public DateTime? PurchaseDate { get; set; }

        /// <summary>
        /// The cost of this Accessory when purchased.
        /// </summary>
        [Field("purchase_cost")]
        public decimal? PurchaseCost { get; set; }

        /// <summary>
        /// The order number associated with this Accessory's purchase.
        /// </summary>
        /// <remarks>A single Accessory only has one OrderNumber field. Multiple orders should use multiple Accessories of the same ModelNumber, IIRC.</remarks>
        [Field("order_number")]
        public string OrderNumber { get; set; }

        /// <summary>
        /// The Minimum quantity of this Accessory before an alert should pop up.
        /// </summary>
        /// <remarks>Supposedly this is setable, but the field is not fillable in Snipe-IT.</remarks>
        [Field(DeserializeAs = "min_qty", SerializeAs = "min_amt")]
        public int? MinimumQuantity { get; set; }

        /// <summary>
        /// The quantity of this Accessory that has not yet been checked out.
        /// </summary>
        [Field(DeserializeAs = "remaining_qty")]
        public int? RemainingQuantity { get; private set; }

        /// <summary>
        /// The Url of the image for this Accessory in the web interface.
        /// </summary>
        [Field("image")]
        public Uri ImageUri { get; set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; private set; }

        /// <summary>
        /// Indicates that this accessory is available to be checked out.
        /// </summary>
        [Field(DeserializeAs = "user_can_checkout")]
        public bool? UserCanCheckOut { get; private set; }

        /* NOT_IMPL: This field is currently not readable from the API, nor used in SnipeIT.
         * [Field(null, "requestable")]
         * public bool? IsRequestable { get; set; }
         */

        /// <inheritdoc />
        public Accessory CloneForUpdate() => new Accessory(this.Id);

        /// <inheritdoc />
        public Accessory WithValuesFrom(Accessory other)
            => new Accessory(this.Id)
            {
                Name = other.Name,
                Company = other.Company,
                Manufacturer = other.Manufacturer,
                Supplier = other.Supplier,
                ModelNumber = other.ModelNumber,
                Category = other.Category,
                Location = other.Location,
                Quantity = other.Quantity,
                PurchaseDate = other.PurchaseDate,
                PurchaseCost = other.PurchaseCost,
                OrderNumber = other.OrderNumber,
                MinimumQuantity = other.MinimumQuantity,
                RemainingQuantity = other.RemainingQuantity,
                ImageUri = other.ImageUri
            };
    }
}
