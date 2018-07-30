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

        [Field("company", FieldConverter = SerializeToId)]
        public Company Company { get; set; }

        [Field("manufacturer", FieldConverter = SerializeToId)]
        public Manufacturer Manufacturer { get; set; }

        [Field("product_key")]
        public string ProductKey { get; set; }

        [Field("order_number")]
        public string OrderNumber { get; set; }

        [Field("purchase_order")]
        public string PurchaseOrder { get; set; }

        [Field("purchase_date", FieldConverter = ExtractDateTime)]
        public DateTime? PurchaseDate { get; set; }

        [Field("purchase_cost")]
        public decimal PurchaseCost { get; set; }

        [Field("notes")]
        public string Notes { get; set; }

        [Field("expiration_date", FieldConverter = ExtractDateTime)]
        public DateTime? ExpirationDate { get; set; }

        [Field("seats")]
        public int? TotalSeats { get; set; }

        [Field("free_seats_count")]
        public int? FreeSeats { get; set; }

        [Field("license_name")]
        public string LicenseName { get; set; }

        [Field("license_email")]
        public string LicenseEmail { get; set; }

        [Field("maintained")]
        public bool? IsMaintained { get; set; }

        [Field("category", FieldConverter = SerializeToId)]
        public Category Category { get; set; }

        [Field("created_at", FieldConverter = ExtractDateTime)]
        public override DateTime? CreatedAt { get; set; }

        [Field("updated_at", FieldConverter = ExtractDateTime)]
        public override DateTime? UpdatedAt { get; set; }

        [Field("user_can_checkout")]
        public bool? CanUserCheckOut { get; set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }
}