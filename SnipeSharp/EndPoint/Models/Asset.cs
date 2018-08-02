using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [PathSegment("hardware")]
    public sealed class Asset : CommonEndPointModel
    {
        [Field("id")]
        public override int Id { get; set; }
        
        [Field("name", true)]
        public override string Name { get; set; }
        
        [Field("asset_tag", true, required: true)]
        public string AssetTag { get; set; }

        [Field("serial", true)]
        public string Serial { get; set; }

        [Field("model", "model_id", converter: CommonModelConverter, required: true)]
        public Model Model { get; set; }

        [Field("model_number", true)]
        public string ModelNumber { get; set; }

        [Field("eol", converter: DateTimeConverter)]
        public DateTime? EndOfLife { get; set; }

        [Field("status_label", "status_id", converter: CommonModelConverter, required: true)]
        public AssetStatus Status { get; set; }

        [Field("category")]
        public Category Category { get; set; }

        [Field("manufacturer")]
        public Manufacturer Manufacturer { get; set; }

        [Field("supplier")]
        public Supplier Supplier { get; set; }

        [Field("notes", true)]
        public string Notes { get; set; }

        [Field("order_number", true)]
        public string OrderNumber { get; set; }

        [Field("company", "company_id", converter: CommonModelConverter)]
        public Company Company { get; set; }

        [Field("location", "location_id", converter: CommonModelConverter)]
        public Location Location { get; set; }

        [Field("rtd_location", "rtd_location_id", converter: CommonModelConverter)]
        public Location DefaultLocation { get; set; }

        [Field("image", true)]
        public Uri ImageUri { get; set; }

        [Field("assigned_to", true)]
        public CommonEndPointModel AssignedTo { get; set; } //TODO: type

        [Field("assigned_type", true)]
        public AssignedToType AssignedType { get; set; }

        [Field("warranty_months", true, converter: MonthsConverter)]
        public int? WarrantyMonths { get; set; }

        [Field("warranty_expires", converter: DateTimeConverter)]
        public DateTime? WarrantyExpires { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; set; }

        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; set; }

        [Field("last_audit_date", converter: DateTimeConverter)]
        public DateTime? LastAuditDate { get; set; }

        [Field("next_audit_date", converter: DateTimeConverter)]
        public DateTime? NextAuditDate { get; set; }

        [Field("deleted_at", converter: DateTimeConverter)]
        public DateTime? DeletedAt { get; set; }

        [Field("purchase_date", true, converter: DateTimeConverter)]
        public DateTime? PurchaseDate { get; set; }

        [Field("last_checkout", converter: DateTimeConverter)]
        public DateTime? LastCheckOut { get; set; }

        [Field("expected_checkin", converter: DateTimeConverter)]
        public DateTime? ExpectedCheckIn { get; set; }

        [Field("purchase_cost", true)]
        public decimal? PurchaseCost { get; set; }

        [Field("checkin_counter")]
        public int CheckInCounter { get; set; }

        [Field("checkout_counter")]
        public int CheckOutCounter { get; set; }

        [Field("requests_counter")]
        public int RequestsCounter { get; set; }

        [Field("user_can_checkout")]
        public bool CanUserCheckOut { get; set; }

        [Field("custom_fields")]
        public Dictionary<string, AssetCustomField> CustomFields { get; set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }
}
