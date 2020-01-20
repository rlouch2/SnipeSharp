using System;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;
using System.Runtime.Serialization;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A License.
    /// Licenses may be checked out to Assets or Users.
    /// </summary>
    [PathSegment("licenses")]
    public sealed class License : CommonEndPointModel, IAvailableActions, IPatchable
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
        [Patch(nameof(isNameModified))]
        public override string Name
        {
            get => name;
            set
            {
                isNameModified = true;
                name = value;
            }
        }
        private bool isNameModified = false;
        private string name;

        /// <value>The company that owns this license.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "company", SerializeAs = "company_id", Converter = CommonModelConverter)]
        [Patch(nameof(isCompanyModified))]
        public Company Company
        {
            get => company;
            set
            {
                isCompanyModified = true;
                company = value;
            }
        }
        private bool isCompanyModified = false;
        private Company company;

        /// <value>The depreciation for this license.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("depreciation_id", Converter = CommonModelConverter)]
        [Patch(nameof(isDepreciationModified))]
        public Depreciation Depreciation
        {
            get => depreciation;
            set
            {
                isDepreciationModified = true;
                depreciation = value;
            }
        }
        private bool isDepreciationModified = false;
        private Depreciation depreciation;

        /// <value>The manufacturer that produced this license.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "manufacturer", SerializeAs = "manufacturer_id", Converter = CommonModelConverter)]
        [Patch(nameof(isManufacturerModified))]
        public Manufacturer Manufacturer
        {
            get => manufacturer;
            set
            {
                isManufacturerModified = true;
                manufacturer = value;
            }
        }
        private bool isManufacturerModified = false;
        private Manufacturer manufacturer;

        /// <value>The Product Key for this license.</value>
        [Field(DeserializeAs = "product_key", SerializeAs = "serial")]
        [Patch(nameof(isProductKeyModified))]
        public string ProductKey
        {
            get => productKey;
            set
            {
                isProductKeyModified = true;
                productKey = value;
            }
        }
        private bool isProductKeyModified = false;
        private string productKey;

        /// <value>The supplier order number associated with this License's purchase.</value>
        [Field("order_number")]
        [Patch(nameof(isOrderNumberModified))]
        public string OrderNumber
        {
            get => orderNumber;
            set
            {
                isOrderNumberModified = true;
                orderNumber = value;
            }
        }
        private bool isOrderNumberModified = false;
        private string orderNumber;

        /// <value>The purchase order associated with this License's purchase.</value>
        [Field("purchase_order")]
        [Patch(nameof(isPurchaseOrderModified))]
        public string PurchaseOrder
        {
            get => purchaseOrder;
            set
            {
                isPurchaseOrderModified = true;
                purchaseOrder = value;
            }
        }
        private bool isPurchaseOrderModified = false;
        private string purchaseOrder;

        /// <value>The date this License was purchased.</value>
        [Field("purchase_date", Converter = DateTimeConverter)]
        [Patch(nameof(isPurchaseDateModified))]
        public DateTime? PurchaseDate
        {
            get => purchaseDate;
            set
            {
                isPurchaseDateModified = true;
                purchaseDate = value;
            }
        }
        private bool isPurchaseDateModified = false;
        private DateTime? purchaseDate;

        /// <value>The cost of this License when purchased.</value>
        [Field("purchase_cost")]
        [Patch(nameof(isPurchaseCostModified))]
        public decimal? PurchaseCost
        {
            get => purchaseCost;
            set
            {
                isPurchaseCostModified = true;
                purchaseCost = value;
            }
        }
        private bool isPurchaseCostModified = false;
        private decimal? purchaseCost;

        /// <value>The description for this License.</value>
        [Field("notes")]
        [Patch(nameof(isNotesModified))]
        public string Notes
        {
            get => notes;
            set
            {
                isNotesModified = true;
                notes = value;
            }
        }
        private bool isNotesModified = false;
        private string notes;

        /// <value>The date this license expires. This is not the TerminationDate!</value>
        [Field("expiration_date", Converter = DateTimeConverter)]
        public DateTime? ExpirationDate { get; private set; }

        /// <value>The number of seats this license is good for.</value>
        /// <remarks>This field is required.</remarks>
        [Field("seats", IsRequired = true)]
        [Patch(nameof(isTotalSeatsModified))]
        public int? TotalSeats
        {
            get => totalSeats;
            set
            {
                isTotalSeatsModified = true;
                totalSeats = value;
            }
        }
        private bool isTotalSeatsModified = false;
        private int? totalSeats;

        /// <value>The number of remaining seats on this license.</value>
        [Field(DeserializeAs = "free_seats_count")]
        public int? FreeSeats { get; private set; }

        /// <value>The name of the entity this license is licensed to.</value>
        [Field("license_name")]
        [Patch(nameof(isLicensedToNameModified))]
        public string LicensedToName
        {
            get => licensedToName;
            set
            {
                isLicensedToNameModified = true;
                licensedToName = value;
            }
        }
        private bool isLicensedToNameModified = false;
        private string licensedToName;

        /// <value>The email address of the entity this license is licensed to.</value>
        [Field("license_email")]
        [Patch(nameof(isLicensedToEmailAddressModified))]
        public string LicensedToEmailAddress
        {
            get => licensedToEmailAddress;
            set
            {
                isLicensedToEmailAddressModified = true;
                licensedToEmailAddress = value;
            }
        }
        private bool isLicensedToEmailAddressModified = false;
        private string licensedToEmailAddress;

        /// <value>Whether or not this license is maintained.</value>
        [Field("maintained")]
        [Patch(nameof(isIsMaintainedModified))]
        public bool? IsMaintained
        {
            get => isMaintained;
            set
            {
                isIsMaintainedModified = true;
                isMaintained = value;
            }
        }
        private bool isIsMaintainedModified = false;
        private bool? isMaintained;

        /// <value>The category this license is in.</value>
        /// <remarks>
        /// <para>This field is required, and will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "category", SerializeAs = "category_id", Converter = CommonModelConverter, IsRequired = true)]
        [Patch(nameof(isCategoryModified))]
        public Category Category
        {
            get => category;
            set
            {
                isCategoryModified = true;
                category = value;
            }
        }
        private bool isCategoryModified = false;
        private Category category;

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
        public AvailableAction AvailableActions { get; private set; }

        /// <value>Gets/sets if sears on this license are reassignable.</value>
        [Field("reassignable")]
        [Patch(nameof(isIsReassignableModified))]
        public bool IsReassignable
        {
            get => isReassignable;
            set
            {
                isIsReassignableModified = true;
                isReassignable = value;
            }
        }
        private bool isIsReassignableModified = false;
        private bool isReassignable;

        /// <value>Gets/sets the supplier who sold this license.</value>
        [Field(DeserializeAs = "supplier", SerializeAs = "supplier_id", Converter = CommonModelConverter)]
        [Patch(nameof(isSupplierModified))]
        public Supplier Supplier
        {
            get => supplier;
            set
            {
                isSupplierModified = true;
                supplier = value;
            }
        }
        private bool isSupplierModified = false;
        private Supplier supplier;

        void IPatchable.SetAllModifiedState(bool isModified)
        {
            isNameModified = isModified;
            isCompanyModified = isModified;
            isDepreciationModified = isModified;
            isManufacturerModified = isModified;
            isProductKeyModified = isModified;
            isOrderNumberModified = isModified;
            isPurchaseOrderModified = isModified;
            isPurchaseDateModified = isModified;
            isPurchaseCostModified = isModified;
            isNotesModified = isModified;
            isTotalSeatsModified = isModified;
            isLicensedToNameModified = isModified;
            isLicensedToEmailAddressModified = isModified;
            isIsMaintainedModified = isModified;
            isCategoryModified = isModified;
            isIsReassignableModified = isModified;
            isSupplierModified = isModified;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            ((IPatchable)this).SetAllModifiedState(false);
        }
    }
}
