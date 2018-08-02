using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint.Models;
using static SnipeSharp.Serialization.FieldConverter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.EndPoint.Filters
{
    public sealed class AssetSearchFilter : ISortableSearchFilter<AssetSearchColumn>
    {
        [Field("limit", true)]
        public int? Limit { get; set; }

        [Field("offset", true)]
        public int? Offset { get; set; }

        [Field("search", true)]
        public string Search { get; set; }

        [Field("sort", true)]
        public AssetSearchColumn SortColumn { get; set; }

        [Field("order", true)]
        public SearchOrder Order { get; set; }

        [Field("status_id", true, converter: CommonModelConverter)]
        public StatusLabel StatusLabel { get; set; }

        [Field("status", true)]
        public string Status { get; set; }

        [Field("requestable", true)]
        public bool? IsRequestable { get; set; }

        [Field("model_id", true, converter: CommonModelConverter)]
        public Model Model { get; set; }

        [Field("category_id", true, converter: CommonModelConverter)]
        public Category Category { get; set; }

        [Field("location_id", true, converter: CommonModelConverter)]
        public Location Location { get; set; }

        [Field("supplier_id", true, converter: CommonModelConverter)]
        public Supplier Supplier { get; set; }

        [Field("assigned_to", true, converter: CommonModelConverter)]
        public CommonEndPointModel AssignedTo { get; set; }

        [Field("assigned_type")]
        public AssignedToType AssignedToType { get; set; }

        [Field("company_id", true, converter: CommonModelConverter)]
        public Company Company { get; set; }

        [Field("manufacturer_id", true, converter: CommonModelConverter)]
        public Manufacturer Manufacturer { get; set; }

        [Field("depreciation_id", true, converter: CommonModelConverter)]
        public Depreciation Depreciation { get; set; }

        [Field("order_number", true)]
        public string OrderNumber { get; set; }

        public AssetSearchFilter()
        {
        }

        public AssetSearchFilter(string searchString)
        {
            Search = searchString;
        }
    }

    public sealed class CustomAssetSearchFilter : ISortableSearchFilter<string>
    {
        [Field("limit", true)]
        public int? Limit { get; set; }

        [Field("offset", true)]
        public int? Offset { get; set; }

        [Field("search", true)]
        public string Search { get; set; }

        [Field("sort", true)]
        public string SortColumn { get; set; }

        [Field("order", true)]
        public SearchOrder Order { get; set; }

        [Field("status_id", true, converter: CommonModelConverter)]
        public StatusLabel StatusLabel { get; set; }

        [Field("status", true)]
        public string Status { get; set; }

        [Field("requestable", true)]
        public bool? IsRequestable { get; set; }

        [Field("model_id", true, converter: CommonModelConverter)]
        public Model Model { get; set; }

        [Field("category_id", true, converter: CommonModelConverter)]
        public Category Category { get; set; }

        [Field("location_id", true, converter: CommonModelConverter)]
        public Location Location { get; set; }

        [Field("supplier_id", true, converter: CommonModelConverter)]
        public Supplier Supplier { get; set; }

        [Field("assigned_to", true, converter: CommonModelConverter)]
        public CommonEndPointModel AssignedTo { get; set; }

        [Field("assigned_type")]
        public AssignedToType AssignedToType { get; set; }

        [Field("company_id", true, converter: CommonModelConverter)]
        public Company Company { get; set; }

        [Field("manufacturer_id", true, converter: CommonModelConverter)]
        public Manufacturer Manufacturer { get; set; }

        [Field("depreciation_id", true, converter: CommonModelConverter)]
        public Depreciation Depreciation { get; set; }

        [Field("order_number", true)]
        public string OrderNumber { get; set; }

        public CustomAssetSearchFilter()
        {
        }

        public CustomAssetSearchFilter(string searchString)
        {
            Search = searchString;
        }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AssetSearchColumn
    {
        [EnumMember(Value = "id")]
        Id,
        [EnumMember(Value = "name")]
        Name,
        [EnumMember(Value = "asset_tag")]
        AssetTag,
        [EnumMember(Value = "model_number")]
        ModelNumber,
        [EnumMember(Value = "last_checkout")]
        LastCheckOut,
        [EnumMember(Value = "notes")]
        Notes,
        [EnumMember(Value = "expected_checkin")]
        ExpectedCheckIn,
        [EnumMember(Value = "order_number")]
        OrderNumber,
        [EnumMember(Value = "image")]
        ImageUri,
        [EnumMember(Value = "assigned_to")]
        AssignedTo,
        [EnumMember(Value = "created_at")]
        CreatedAt,
        [EnumMember(Value = "updated_at")]
        UpdatedAt,
        [EnumMember(Value = "purchase_date")]
        PurchaseDate,
        [EnumMember(Value = "purchase_cost")]
        PurchaseCost,
        [EnumMember(Value = "last_audit_date")]
        LastAuditDate,
        [EnumMember(Value = "next_audit_date")]
        NextAuditDate,
        [EnumMember(Value = "warranty_months")]
        WarrantyMonths,
        [EnumMember(Value = "checkout_counter")]
        CheckOutCounter,
        [EnumMember(Value = "checkin_counter")]
        CheckInCounter,
        [EnumMember(Value = "requests_counter")]
        RequestsCounter
    }
}
