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
    public sealed class License : CommonEndPointModel, IAvailableActions
    {
        /// <inheritdoc />
        [Field("id")]
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("name", true, required: true)]
        public override string Name { get; set; }

        /// <value>The company that owns this license.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("company", "company_id", converter: CommonModelConverter)]
        public Company Company { get; set; }

        /// <value>The depreciation for this license.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("depreciation_id", true, converter: CommonModelConverter)]
        public Depreciation Depreciation { get; set; }

        /// <value>The manufacturer that produced this license.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("manufacturer", "manufacturer_id", converter: CommonModelConverter)]
        public Manufacturer Manufacturer { get; set; }

        /// <value>The Product Key for this license.</value>
        [Field("product_key", "serial")]
        public string ProductKey { get; set; }

        /// <value>The order number associated with this License's purchase.</value>
        [Field("order_number", true)]
        public string OrderNumber { get; set; }

        /// <value>The order number associated with this License's purchase.</value>
        [Field("purchase_order", true)]
        public string PurchaseOrder { get; set; }

        /// <value>The date this License was purchased.</value>
        [Field("purchase_date", true, converter: DateTimeConverter)]
        public DateTime? PurchaseDate { get; set; }

        /// <value>The cost of this License when purchased.</value>
        [Field("purchase_cost", true)]
        public decimal? PurchaseCost { get; set; }

        /// <value>The description for this License.</value>
        [Field("notes", true)]
        public string Notes { get; set; }

        /// <value>The date this license expires. This is not the TerminationDate!</value>
        [Field("expiration_date", true, converter: DateTimeConverter)]
        public DateTime? ExpirationDate { get; private set; }

        /// <value>The number of seats this license is good for.</value>
        /// <remarks>This field is required.</remarks>
        [Field("seats", true, required: true)]
        public int? TotalSeats { get; set; }

        /// <value>The number of remaining seats on this license.</value>
        [Field("free_seats_count")]
        public int? FreeSeats { get; private set; }

        /// <value>The name of the entity this license is licensed to.</value>
        [Field("license_name", true)]
        public string LicensedToName { get; set; }

        /// <value>The email address of the entity this license is licensed to.</value>
        [Field("license_email", true)]
        public string LicensedToEmailAddress { get; set; }

        /// <value>Whether or not this license is maintained.</value>
        [Field("maintained", true)]
        public bool? IsMaintained { get; set; }

        /// <value>The category this license is in.</value>
        /// <remarks>
        /// <para>This field is required, and will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("category", "category_id", converter: CommonModelConverter, required: true)]
        public Category Category { get; set; }

        /// <inheritdoc />
        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <value>Whether or not there are seats left to check out.</value>
        [Field("user_can_checkout")]
        public bool? UserCanCheckOut { get; private set; }

        /// <inheritdoc />
        [Field("available_actions", converter: AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }

        /// <value>Gets/sets if sears on this license are reassignable.</value>
        [Field("reassignable", true)]
        public bool IsReassignable { get; set; }

        /// <value>Gets/sets the supplier who sold this license.</value>
        [Field("supplier", "supplier_id", converter: CommonModelConverter)]
        public Supplier Supplier { get; set; }
    }
}
