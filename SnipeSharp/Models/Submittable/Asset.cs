using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
using SnipeSharp.Collections;

namespace SnipeSharp.Models
{
    /// <summary>
    /// An Accessory.
    /// Accessories may be checked out to Users, Locations, or other Assets.
    /// </summary>
    [PathSegment("hardware")]
    public sealed class Asset : CommonEndPointModel, IAvailableActions, IUpdatable<Asset>
    {
        /// <summary>Create a new Asset object.</summary>
        public Asset() { }

        /// <summary>Create a new Asset object with the supplied ID, for use with updating.</summary>
        internal Asset(int id)
        {
            Id = id;
        }

        /// <inheritdoc />
        [Field(DeserializeAs = "id")]
        public override int Id { get; protected set; }

        /// <inheritdoc />
        [Field("name")]
        public override string Name { get; set; }

        /// <summary>
        /// The asset tag of the Asset.
        /// </summary>
        /// <remarks>
        /// <para>This field is required, and must be unique amongst non-deleted assets.</para>
        /// </remarks>
        [Field("asset_tag", IsRequired = true)]
        public string AssetTag { get; set; }

        /// <summary>
        /// The serial (number) of the Asset.
        /// </summary>
        /// <remarks>This value must be unique amongst all assets.</remarks>
        [Field("serial")]
        public string Serial { get; set; }

        /// <summary>
        /// The model of the Asset.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// <para>This field is required.</para>
        /// </remarks>
        [Field(DeserializeAs = "model", SerializeAs = "model_id", Converter = CommonModelConverter, IsRequired = true)]
        public Model Model { get; set; }

        /// <summary>
        /// The model number of the model of the Asset.
        /// </summary>
        /// <remarks>This field cannot be used to set the model.</remarks>
        [Field(DeserializeAs = "model_number")]
        public string ModelNumber { get; private set; }

        /// <summary>
        /// The End-of-life date for the Asset, based on its purchase date an the end-of-life time of its model.
        /// </summary>
        [Field(DeserializeAs = "eol", Converter = DateTimeConverter)]
        public DateTime? EndOfLife { get; private set; }

        /// <summary>
        /// The status of the asset, derived from its associated StatusLabel and other metadata.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its StatusId when serialized.</para>
        /// </remarks>
        /// <seealso cref="StatusLabelEndPoint.FromAssetStatus(AssetStatus)" />
        /// <seealso cref="StatusLabel.ToAssetStatus" />
        [Field(DeserializeAs = "status_label", SerializeAs = "status_id", Converter = AssetStatusConverter, IsRequired = true)]
        public AssetStatus Status { get; set; }

        /// <summary>
        /// The category of the model of the Asset.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// <para>To update this field, see <see cref="Model.Category"/></para>
        /// </remarks>
        [Field(DeserializeAs = "category", Converter = CommonModelConverter)]
        public Category Category { get; private set; }

        /// <summary>
        /// The manufacturer of the model of the Asset.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// <para>To update this field, see <see cref="Model.Manufacturer"/></para>
        /// </remarks>
        [Field(DeserializeAs = "manufacturer", Converter = CommonModelConverter)]
        public Manufacturer Manufacturer { get; private set; }

        /// <summary>
        /// The supplier of the Asset.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "supplier", SerializeAs = "supplier_id", Converter = CommonModelConverter)]
        public Supplier Supplier { get; set; }

        /// <summary>
        /// Notes for the Asset.
        /// </summary>
        [Field("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// The order number associated with this Asset's purchase.
        /// </summary>
        [Field("order_number")]
        public string OrderNumber { get; set; }

        /// <summary>
        /// The company that owns this Asset.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "company", SerializeAs = "company_id", Converter = CommonModelConverter)]
        public Company Company { get; set; }

        /// <summary>
        /// <para>The location this asset is currently at.</para>
        /// <para>It is preferable to check out the asset than to set its location directly.</para>
        /// <seealso cref="AssetEndPoint.CheckOut(AssetCheckOutRequest)" />
        /// <para>When an asset is checked in, its location will be set to its <see cref="DefaultLocation">DefaultLocation</see>.</para>
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "location", SerializeAs =  "location_id", Converter = CommonModelConverter)]
        public Location Location { get; set; }

        /// <summary>
        /// The default location for the asset.
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "rtd_location", SerializeAs = "rtd_location_id", Converter = CommonModelConverter)]
        public Location DefaultLocation { get; set; }

        /// <summary>
        /// The url for the image of the asset.
        /// </summary>
        /// <remarks>If the asset does not have an image set explicitly, it uses its model's image by default.</remarks>
        [Field("image")]
        public Uri ImageUri { get; set; }

        /// <summary>
        /// <para>The object this asset is assigned to; it may be either a <see cref="User">User</see>, a <see cref="Location">Location</see>, or another <see cref="Asset">Asset</see>.</para>
        /// </summary>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "assigned_to", Converter = CommonModelConverter, OverrideAffinity = true)]
        public AssetAssignedTo AssignedTo { get; private set; }

        /// <value>If the assigned object has been modified.</value>
        /// <remarks>Tracking this lets us skip it when writing back.</remarks>
        private bool _updateAssignedTo = false;

        /// <summary>
        /// Assigne this asset to a user.
        /// </summary>
        /// <param ref="user">The user to assign to.</param>
        /// <returns>The stub object representing the user to the API.</returns>
        public AssetAssignedTo AssignTo(User user)
        {
            _updateAssignedTo = true;
            return AssignedTo = new AssetAssignedTo(user);
        }

        /// <summary>
        /// Assigne this asset to a location.
        /// </summary>
        /// <param ref="location">The location to assign to.</param>
        /// <returns>The stub object representing the location to the API.</returns>
        public AssetAssignedTo AssignTo(Location location)
        {
            _updateAssignedTo = true;
            return AssignedTo = new AssetAssignedTo(location);
        }

        /// <summary>
        /// Assigne this asset to a asset.
        /// </summary>
        /// <param ref="asset">The asset to assign to.</param>
        /// <returns>The stub object representing the asset to the API.</returns>
        public AssetAssignedTo AssignTo(Asset asset)
        {
            _updateAssignedTo = true;
            return AssignedTo = new AssetAssignedTo(asset);
        }

        /// <summary>
        /// The number of months the warranty covers for this asset.
        /// </summary>
        [Field("warranty_months", Converter = MonthsConverter)]
        public int? WarrantyMonths { get; set; }

        /// <summary>
        /// The date the warranty for this asset expires. This value is calculated from <see cref="PurchaseDate">PurchaseDate</see> and <see cref="WarrantyMonths">WarrantyMonths</see>.
        /// </summary>
        [Field(DeserializeAs = "warranty_expires", Converter = DateTimeConverter)]
        public DateTime? WarrantyExpires { get; private set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <summary>
        /// The date this asset was last audited.
        /// </summary>
        /// <seealso cref="AssetEndPoint.Audit(Asset, Location, DateTime?, string)" />
        [Field(DeserializeAs = "last_audit_date", Converter = DateTimeConverter)]
        public DateTime? LastAuditDate { get; private set; }

        /// <summary>
        /// The date this asset will next be audited.
        /// </summary>
        /// <seealso cref="AssetEndPoint.Audit(Asset, Location, DateTime?, string)" />
        [Field(DeserializeAs = "next_audit_date", Converter = DateTimeConverter)]
        public DateTime? NextAuditDate { get; private set; }

        /// <summary>
        /// <para>The date this asset was marked deleted.</para>
        /// <para>As assets are never truly deleted, yes, this is a field that can have a value.</para>
        /// </summary>
        [Field(DeserializeAs = "deleted_at", Converter = DateTimeConverter)]
        public DateTime? DeletedAt { get; private set; }

        /// <summary>
        /// The date this Asset was purchased.
        /// </summary>
        [Field("purchase_date", Converter = DateTimeConverter)]
        public DateTime? PurchaseDate { get; set; }

        /// <summary>
        /// The date this Asset was last checked out.
        /// </summary>
        /// <seealso cref="AssetEndPoint.CheckOut(AssetCheckOutRequest)" />
        [Field(DeserializeAs = "last_checkout", Converter = DateTimeConverter)]
        public DateTime? LastCheckOut { get; private set; }

        /// <summary>
        /// The date this Asset is expected to be checked back in.
        /// </summary>
        /// <seealso cref="AssetEndPoint.CheckOut(AssetCheckOutRequest)" />
        [Field(DeserializeAs = "expected_checkin", Converter = DateTimeConverter)]
        public DateTime? ExpectedCheckIn { get; private set; }

        /// <summary>
        /// The cost of this Asset when purchased.
        /// </summary>
        [Field("purchase_cost")]
        public decimal? PurchaseCost { get; set; }

        /// <summary>
        /// The number of times this asset has been checked in.
        /// </summary>
        [Field(DeserializeAs = "checkin_counter")]
        public int CheckInCounter { get; private set; }

        /// <summary>
        /// The number of times this asset has been checked out.
        /// </summary>
        [Field(DeserializeAs = "checkout_counter")]
        public int CheckOutCounter { get; private set; }

        /// <summary>
        /// The number of times this asset has been requested.
        /// </summary>
        [Field(DeserializeAs = "requests_counter")]
        public int RequestsCounter { get; private set; }

        /// <summary>
        /// Whether or not a user can check this asset out.
        /// </summary>
        [Field(DeserializeAs = "user_can_checkout")]
        public bool? UserCanCheckOut { get; private set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; private set; }

        /// <summary>
        /// <para>Custom fields for this Asset, selected by the Model's FieldSet.</para>
        /// <para>Values in this collection will be serialized with the key <c><see cref="AssetCustomField.Field">value.Field</see> ?? key</c> and the value <see cref="AssetCustomField.Value">value.Value</see>.</para>
        /// </summary>
        [Field(DeserializeAs = "custom_fields", Converter = FieldConverter.CustomFieldDictionaryConverter)]
        public CustomFieldDictionary CustomFields { get; set; } = new CustomFieldDictionary();

        [JsonExtensionData]
        private Dictionary<string, JToken> _customFields { get; set; }

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            _customFields = new Dictionary<string, JToken>();
            if(null != CustomFields)
                foreach(var pair in CustomFields)
                    _customFields[pair.Value?.Field ?? pair.Key] = pair.Value?.Value;
            if(null != AssignedTo && _updateAssignedTo)
            {
                switch(AssignedTo.Type)
                {
                    case AssignedToType.Asset:
                        _customFields["assigned_asset"] = AssignedTo.Id;
                        break;
                    case AssignedToType.Location:
                        _customFields["assigned_location"] = AssignedTo.Id;
                        break;
                    case AssignedToType.User:
                        _customFields["assigned_user"] = AssignedTo.Id;
                        break;
                }
            }
        }

        [OnSerialized]
        private void OnSerialized(StreamingContext context)
        {
            // remove unnecessary object now.
            _customFields = null;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if(null != _customFields)
            {
                foreach(var pair in _customFields)
                {
                    if(!pair.Key.StartsWith("_snipeit_")) // custom fields start with _snipeit_
                        continue;
                    var model = new AssetCustomField
                    {
                        FriendlyName = pair.Key,
                        Field = pair.Key,
                        Value = pair.Value.ToObject<string>()
                    };
                    CustomFields.Add(pair.Key, model);
                }
                _customFields = null;
            }
            return;
        }

        /// <inheritdoc />
        public Asset CloneForUpdate() => new Asset(this.Id);

        /// <inheritdoc />
        public Asset WithValuesFrom(Asset other)
            => new Asset(this.Id)
            {
                AssetTag = other.AssetTag,
                Name = other.Name,
                Serial = other.Serial,
                Model = other.Model,
                Status = other.Status,
                Supplier = other.Supplier,
                Notes = other.Notes,
                OrderNumber = other.OrderNumber,
                Company = other.Company,
                Location = other.Location,
                DefaultLocation = other.DefaultLocation,
                ImageUri = other.ImageUri,
                WarrantyMonths = other.WarrantyMonths,
                PurchaseDate = other.PurchaseDate,
                PurchaseCost = other.PurchaseCost,
                CustomFields = other.CustomFields
            };
    }
}
