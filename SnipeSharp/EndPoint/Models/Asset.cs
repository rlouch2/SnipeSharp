using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [EndPointInformation("hardware", "")]
    public class Asset : CommonEndPointModel
    {
        [Field("id")]
        public override long Id { get; set; }
        
        [Field("name")]
        public override string Name { get; set; }
        
        [Field("asset_tag")]
        public string AssetTag { get; set; }

        [Field("serial")]
        public string Serial { get; set; }

        [Field("model", SerializeAs = "model_id", FieldConverter = SerializeToId)]
        public Model Model { get; set; }

        [Field("model_number")]
        public string ModelNumber { get; set; }

        [Field("eol")]
        public string Eol { get; set; }

        [Field("status_label")]
        public StatusLabel StatusLabel { get; set; }

        [Field("category")]
        public Category Category { get; set; }

        [Field("manufacturer")]
        public Manufacturer Manufacturer { get; set; }

        [Field("supplier")]
        public Supplier Supplier { get; set; }

        [Field("notes")]
        public string Notes { get; set; }

        [Field("order_number")]
        public string OrderNumber { get; set; }

        [Field("company")]
        public Company Company { get; set; }

        [Field("location")]
        public Location Location { get; set; }

        [Field("rtd_location")]
        public Location RtdLocation { get; set; }

        [Field("image")]
        public Uri ImageUri { get; set; }

        [Field("assigned_to")]
        public object AssignedTo { get; set; } //TODO: type

        [Field("warranty_months", FieldConverter = StripMonthSuffix)]
        public int? WarrantyMonths { get; set; }

        [Field("warranty_expires", FieldConverter = ExtractDateTime)]
        public DateTime? WarrantyExpires { get; set; }

        [Field("created_at", FieldConverter = ExtractDateTime)]
        public override DateTime? CreatedAt { get; set; }

        [Field("updated_at", FieldConverter = ExtractDateTime)]
        public override DateTime? UpdatedAt { get; set; }

        [Field("last_audit_date", FieldConverter = ExtractDateTime)]
        public DateTime? LastAuditDate { get; set; }

        [Field("next_audit_date", FieldConverter = ExtractDateTime)]
        public DateTime? NextAuditDate { get; set; }

        [Field("deleted_at", FieldConverter = ExtractDateTime)]
        public DateTime? DeletedAt { get; set; }

        [Field("purchase_date", FieldConverter = ExtractDateTime)]
        public DateTime? PurchaseDate { get; set; }

        [Field("last_checkout", FieldConverter = ExtractDateTime)]
        public DateTime? LastCheckOut { get; set; }

        [Field("expected_checkin", FieldConverter = ExtractDateTime)]
        public DateTime? ExpectedCheckIn { get; set; }

        [Field("purchase_cost")]
        public decimal? PurchaseCost { get; set; }

        [Field("checkin_counter")]
        public int CheckInCounter { get; set; }

        [Field("checkout_counter")]
        public int CheckOutCounter { get; set; }

        [Field("requests_counter")]
        public int RequestsCounter { get; set; }

        [Field("user_can_checkout")]
        public bool? CanUserCheckOut { get; set; }

        [Field("custom_fields")]
        public List<AssetCustomField> CustomFields { get; set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }

    public sealed class AssetCustomField : ApiObject
    {
        [Field("field")]
        public string Field { get; set; }

        [Field("value")]
        public string Value { get; set; }

        [Field("field_format")]
        public string Format { get; set; }
    }

    public sealed class AssetCheckOutRequest : ApiObject
    {
        public Asset Asset { get; private set; }

        [Field("assigned_location")]
        public Location AssignedLocation { get; private set; }

        [Field("assigned_asset")]
        public Asset AssignedAsset { get; private set; }

        [Field("assigned_user")]
        public User AssignedUser { get; private set; }

        [Field("checkout_to_type")]
        public string CheckOutToType { get; private set; }

        [Field("checkout_at")]
        public DateTime? CheckOutAt { get; set; }

        [Field("expected_checkin")]
        public DateTime? ExpectedCheckIn { get; set; }

        [Field("note")]
        public string Note { get; set; }

        [Field("name")]
        public string AssetName { get; set; }

        public AssetCheckOutRequest(Asset asset, Location location)
        {
            Asset = asset;
            AssignedLocation = location;
            CheckOutToType = "location";
        }

        public AssetCheckOutRequest(Asset asset, User user)
        {
            Asset = asset;
            AssignedUser = user;
            CheckOutToType = "user";
        }

        public AssetCheckOutRequest(Asset asset, Asset assignedAsset)
        {
            Asset = asset;
            AssignedAsset = assignedAsset;
            CheckOutToType = "asset";
        }
    }

    internal sealed class AssetCheckInRequest : ApiObject
    {
        public string Note { get; set; }
        public Location Location { get; set; }
    }
}