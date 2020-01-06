using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A License.
    /// Licenses may be checked out to Assets or Users.
    /// </summary>
    [PathSegment("licenses")]
    public sealed class License : CommonEndPointModel, IAvailableActions, IUpdatable<License>
    {
        /// <summary>Create a new License object.</summary>
        public License() { }

        /// <summary>Create a new License object with the supplied ID, for use with updating.</summary>
        internal License(int id)
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

        /// <value>The company that owns this license.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "company", SerializeAs = "company_id", Converter = CommonModelConverter)]
        public Company Company { get; set; }

        /// <value>The depreciation for this license.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("depreciation_id", Converter = CommonModelConverter)]
        public Depreciation Depreciation { get; set; }

        /// <value>The manufacturer that produced this license.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "manufacturer", SerializeAs = "manufacturer_id", Converter = CommonModelConverter)]
        public Manufacturer Manufacturer { get; set; }

        /// <value>The Product Key for this license.</value>
        [Field(DeserializeAs = "product_key", SerializeAs = "serial")]
        public string ProductKey { get; set; }

        /// <value>The supplier order number associated with this License's purchase.</value>
        [Field("order_number")]
        public string OrderNumber { get; set; }

        /// <value>The purchase order associated with this License's purchase.</value>
        [Field("purchase_order")]
        public string PurchaseOrder { get; set; }

        /// <value>The date this License was purchased.</value>
        [Field("purchase_date", Converter = DateTimeConverter)]
        public DateTime? PurchaseDate { get; set; }

        /// <value>The cost of this License when purchased.</value>
        [Field("purchase_cost")]
        public decimal? PurchaseCost { get; set; }

        /// <value>The description for this License.</value>
        [Field("notes")]
        public string Notes { get; set; }

        /// <value>The date this license expires. This is not the TerminationDate!</value>
        [Field("expiration_date", Converter = DateTimeConverter)]
        public DateTime? ExpirationDate { get; private set; }

        /// <value>The number of seats this license is good for.</value>
        /// <remarks>This field is required.</remarks>
        [Field("seats", IsRequired = true)]
        public int? TotalSeats { get; set; }

        /// <value>The number of remaining seats on this license.</value>
        [Field(DeserializeAs = "free_seats_count")]
        public int? FreeSeats { get; private set; }

        /// <value>The name of the entity this license is licensed to.</value>
        [Field("license_name")]
        public string LicensedToName { get; set; }

        /// <value>The email address of the entity this license is licensed to.</value>
        [Field("license_email")]
        public string LicensedToEmailAddress { get; set; }

        /// <value>Whether or not this license is maintained.</value>
        [Field("maintained")]
        public bool? IsMaintained { get; set; }

        /// <value>The category this license is in.</value>
        /// <remarks>
        /// <para>This field is required, and will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "category", SerializeAs = "category_id", Converter = CommonModelConverter, IsRequired = true)]
        public Category Category { get; set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <value>Whether or not there are seats left to check out.</value>
        [Field(DeserializeAs = "user_can_checkout")]
        public bool? UserCanCheckOut { get; private set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; private set; }

        /// <value>Gets/sets if sears on this license are reassignable.</value>
        [Field("reassignable")]
        public bool IsReassignable { get; set; }

        /// <value>Gets/sets the supplier who sold this license.</value>
        [Field(DeserializeAs = "supplier", SerializeAs = "supplier_id", Converter = CommonModelConverter)]
        public Supplier Supplier { get; set; }

        /// <inheritdoc />
        public License CloneForUpdate() => new License(this.Id);

        /// <inheritdoc />
        public License WithValuesFrom(License other)
            => new License(this.Id)
            {
                Name = other.Name,
                Company = other.Company,
                Depreciation = other.Depreciation,
                Manufacturer = other.Manufacturer,
                ProductKey = other.ProductKey,
                OrderNumber = other.OrderNumber,
                PurchaseOrder = other.PurchaseOrder,
                PurchaseDate = other.PurchaseDate,
                PurchaseCost = other.PurchaseCost,
                Notes = other.Notes,
                TotalSeats = other.TotalSeats,
                LicensedToName = other.LicensedToName,
                LicensedToEmailAddress = other.LicensedToEmailAddress,
                IsMaintained = other.IsMaintained,
                Category = other.Category,
                IsReassignable = other.IsReassignable,
                Supplier = other.Supplier
            };
    }
}
