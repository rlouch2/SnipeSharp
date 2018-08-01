using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [EndPointInformation("licenses", "")]
    public class License : CommonEndPointModel
    {
        [Field("id")]
        public override long Id { get; set; }

        [Field("name")]
        public override string Name { get; set; }

        [Field("company", converter: CommonModelConverter)]
        public Company Company { get; set; }

        [Field("manufacturer", converter: CommonModelConverter)]
        public Manufacturer Manufacturer { get; set; }

        [Field("product_key")]
        public string ProductKey { get; set; }

        [Field("order_number")]
        public string OrderNumber { get; set; }

        [Field("purchase_order")]
        public string PurchaseOrder { get; set; }

        [Field("purchase_date", converter: DateTimeConverter)]
        public DateTime? PurchaseDate { get; set; }

        [Field("purchase_cost")]
        public decimal? PurchaseCost { get; set; }

        [Field("notes")]
        public string Notes { get; set; }

        [Field("expiration_date", converter: DateTimeConverter)]
        public DateTime? ExpirationDate { get; set; }

        [Field("seats")]
        public int? TotalSeats { get; set; }

        [Field("free_seats_count")]
        public int? FreeSeats { get; set; }

        [Field("license_name")]
        public string LicenseName { get; set; }

        [Field("license_email")]
        public string LicenseEmailAddress { get; set; }

        [Field("maintained")]
        public bool? IsMaintained { get; set; }

        [Field("category", converter: CommonModelConverter)]
        public Category Category { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; set; }

        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; set; }

        [Field("user_can_checkout")]
        public bool? CanUserCheckOut { get; set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }

    public sealed class LicenseSeat : ApiObject
    {
        [Field("id")]
        public long Id { get; set; }

        [Field("license_id")]
        public long LicenseId { get; set; }

        [Field("assigned_user")]
        public User AssignedUser { get; set; }

        [Field("assigned_asset")]
        public Asset AssignedAsset { get; set; }

        [Field("location")]
        public Location Location { get; set; }

        [Field("reassignable")]
        public bool IsReassignable { get; set; }

        [Field("user_can_checkout")]
        public bool CanUserCheckOut { get; set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }

        public bool IsCheckedOut => AssignedUser != null || AssignedAsset != null;
    }
}