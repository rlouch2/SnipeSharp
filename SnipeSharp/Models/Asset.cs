using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SnipeSharp.Models
{
    /// <summary>
    /// An Accessory.
    /// Accessories may be checked out to Users, Locations, or other Assets.
    /// </summary>
    [PathSegment("hardware")]
    public sealed class Asset : CommonEndPointModel, ICustomFields<AssetCustomField>, IAvailableActions
    {
        /// <inheritdoc />
        [Field("id")]
        public override int Id { get; protected set; }
        
        /// <inheritdoc />
        [Field("name", true)]
        public override string Name { get; set; }
        
        /// <summary>
        /// The asset tag of the Asset.
        /// </summary>
        /// <remarks>
        /// <para>This field is required, and must be unique amongst non-deleted assets.</para>
        /// </remarks>
        [Field("asset_tag", true, required: true)]
        public string AssetTag { get; set; }

        /// <summary>
        /// The serial (number) of the Asset.
        /// </summary>
        /// <remarks>This value must be unique amongst all assets.</remarks>
        [Field("serial", true)]
        public string Serial { get; set; }

        /// <summary>
        /// The model of the Asset.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// <para>This field is required.</para>
        /// </remarks>
        [Field("model", "model_id", converter: CommonModelConverter, required: true)]
        public Model Model { get; set; }

        /// <summary>
        /// The model number of the model of the Asset.
        /// </summary>
        /// <remarks>This field cannot be used to set the model.</remarks>
        [Field("model_number")]
        public string ModelNumber { get; private set; }

        /// <summary>
        /// The End-of-life date for the Asset, based on its purchase date an the end-of-life time of its model.
        /// </summary>
        [Field("eol", converter: DateTimeConverter)]
        public DateTime? EndOfLife { get; private set; }

        /// <summary>
        /// The status of the asset, derived from its associated StatusLabel and other metadata.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its StatusId when serialized.</para>
        /// </remarks>
        /// <seealso cref="EndPointExtensions.FromAssetStatus(EndPoint{StatusLabel}, AssetStatus)" />
        /// <seealso cref="StatusLabel.ToAssetStatus" />
        [Field("status_label", "status_id", converter: AssetStatusConverter, required: true)]
        public AssetStatus Status { get; set; }

        /// <summary>
        /// The category of the model of the Asset.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// <para>To update this field, see <see cref="Model.Category"/></para>
        /// </remarks>
        [Field("category", converter: CommonModelConverter)]
        public Category Category { get; private set; }

        /// <summary>
        /// The manufacturer of the model of the Asset.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// <para>To update this field, see <see cref="Model.Manufacturer"/></para>
        /// </remarks>
        [Field("manufacturer", converter: CommonModelConverter)]
        public Manufacturer Manufacturer { get; private set; }

        /// <summary>
        /// The supplier of the Asset.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("supplier", "supplier_id", converter: CommonModelConverter)]
        public Supplier Supplier { get; set; }

        /// <summary>
        /// Notes for the Asset.
        /// </summary>
        [Field("notes", true)]
        public string Notes { get; set; }

        /// <summary>
        /// The order number associated with this Asset's purchase.
        /// </summary>
        [Field("order_number", true)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// The company that owns this Asset.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("company", "company_id", converter: CommonModelConverter)]
        public Company Company { get; set; }

        /// <summary>
        /// <para>The location this asset is currently at.</para>
        /// <para>It is preferable to check out the asset than to set its location directly.</para>
        /// <seealso cref="EndPointExtensions.CheckOut(EndPoint{Asset}, AssetCheckOutRequest)" />
        /// <para>When an asset is checked in, its location will be set to its <see cref="DefaultLocation">DefaultLocation</see>.</para>
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("location", "location_id", converter: CommonModelConverter)]
        public Location Location { get; set; }

        /// <summary>
        /// The default location for the asset.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("rtd_location", "rtd_location_id", converter: CommonModelConverter)]
        public Location DefaultLocation { get; set; }

        /// <summary>
        /// The url for the image of the asset.
        /// </summary>
        /// <remarks>If the asset does not have an image set explicitly, it uses its model's image by default.</remarks>
        [Field("image", true)]
        public Uri ImageUri { get; set; }

        /// <summary>
        /// <para>The object this asset is assigned to; it may be either a <see cref="User">User</see>, a <see cref="Location">Location</see>, or another <see cref="Asset">Asset</see>.</para>
        /// <para>You can use the value of the <see cref="AssignedType">AssignedType</see> property to determine what kind of object this is.</para>
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("assigned_to", true, converter: CommonModelConverter, OverrideAffinity = true)]
        public CommonEndPointModel AssignedTo { get; set; }

        /// <summary>
        /// <para>The type of the assignee.</para>
        /// <seealso cref="EndPointExtensions.CheckOut(EndPoint{Asset}, AssetCheckOutRequest)" />
        /// </summary>
        [Field("assigned_type", true)]
        public AssignedToType? AssignedType { get; set; }

        /// <summary>
        /// The number of months the warranty covers for this asset.
        /// </summary>
        [Field("warranty_months", true, converter: MonthsConverter)]
        public int? WarrantyMonths { get; set; }

        /// <summary>
        /// The date the warranty for this asset expires. This value is calculated from <see cref="PurchaseDate">PurchaseDate</see> and <see cref="WarrantyMonths">WarrantyMonths</see>.
        /// </summary>
        [Field("warranty_expires", converter: DateTimeConverter)]
        public DateTime? WarrantyExpires { get; private set; }

        /// <inheritdoc />
        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <summary>
        /// <para>The date this asset was last audited.</para>
        /// <seealso cref="EndPointExtensions.Audit(EndPoint{Asset}, Asset, Location, Nullable{DateTime}, string)"/>
        /// </summary>
        [Field("last_audit_date", converter: DateTimeConverter)]
        public DateTime? LastAuditDate { get; private set; }

        /// <summary>
        /// <para>The date this asset will next be audited.</para>
        /// <seealso cref="EndPointExtensions.Audit(EndPoint{Asset}, Asset, Location, Nullable{DateTime}, string)"/>
        /// </summary>
        [Field("next_audit_date", converter: DateTimeConverter)]
        public DateTime? NextAuditDate { get; private set; }

        /// <summary>
        /// <para>The date this asset was marked deleted.</para>
        /// <para>As assets are never truly deleted, yes, this is a field that can have a value.</para>
        /// </summary>
        [Field("deleted_at", converter: DateTimeConverter)]
        public DateTime? DeletedAt { get; private set; }

        /// <summary>
        /// The date this Asset was purchased.
        /// </summary>
        [Field("purchase_date", true, converter: DateTimeConverter)]
        public DateTime? PurchaseDate { get; set; }

        /// <summary>
        /// The date this Asset was last checked out.
        /// </summary>
        /// <seealso cref="EndPointExtensions.CheckOut(EndPoint{Asset}, AssetCheckOutRequest)" />
        [Field("last_checkout", converter: DateTimeConverter)]
        public DateTime? LastCheckOut { get; private set; }

        /// <summary>
        /// The date this Asset is expected to be checked back in.
        /// </summary>
        /// <seealso cref="EndPointExtensions.CheckOut(EndPoint{Asset}, AssetCheckOutRequest)" />
        [Field("expected_checkin", converter: DateTimeConverter)]
        public DateTime? ExpectedCheckIn { get; private set; }

        /// <summary>
        /// The cost of this Asset when purchased.
        /// </summary>
        [Field("purchase_cost", true)]
        public decimal? PurchaseCost { get; set; }

        /// <summary>
        /// The number of times this asset has been checked in.
        /// </summary>
        [Field("checkin_counter")]
        public int CheckInCounter { get; private set; }

        /// <summary>
        /// The number of times this asset has been checked out.
        /// </summary>
        [Field("checkout_counter")]
        public int CheckOutCounter { get; private set; }

        /// <summary>
        /// The number of times this asset has been requested.
        /// </summary>
        [Field("requests_counter")]
        public int RequestsCounter { get; private set; }

        /// <summary>
        /// Whether or not a user can check this asset out.
        /// </summary>
        [Field("user_can_checkout")]
        public bool? UserCanCheckOut { get; private set; }

        /// <summary>
        /// <para>Custom fields for this Asset, selected by the Model's FieldSet.</para>
        /// <para>Values in this collection will be serialized with the key <c><see cref="AssetCustomField.Field">value.Field</see> ?? key</c> and the value <see cref="AssetCustomField.Value">value.Value</see>.</para>
        /// </summary>
        [Field("custom_fields", converter: CustomFieldDictionaryConverter)]
        public Dictionary<string, AssetCustomField> CustomFields { get; set; }

        [JsonExtensionData(ReadData = false, WriteData = true)]
        private Dictionary<string, JToken> CustomFieldsWriter
        {
            get
            {
                var newDictionary = new Dictionary<string, JToken>();
                if(!(CustomFields is null))
                    foreach(var pair in CustomFields)
                        newDictionary[pair.Value?.Field ?? pair.Key] = pair.Value?.Value;
                return newDictionary;
            }
        }

        /// <inheritdoc />
        [Field("available_actions", converter: AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }
    }
}
