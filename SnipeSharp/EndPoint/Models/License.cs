using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// A License.
    /// Licenses may be checked out to Assets or Users.
    /// </summary>
    [PathSegment("licenses")]
    public sealed class License : CommonEndPointModel
    {
        [Field("id")]
        public override int Id { get; protected set; }

        [Field("name", true)]
        public override string Name { get; set; }

        [Field("company", "company_id", converter: CommonModelConverter)]
        public Company Company { get; set; }

        [Field("depreciation_id", true, converter: CommonModelConverter)]
        public Depreciation Depreciation { get; set; }

        [Field("manufacturer", "manufacturer_id", converter: CommonModelConverter)]
        public Manufacturer Manufacturer { get; set; }

        [Field("product_key")]
        public string ProductKey { get; set; }

        [Field("order_number", true)]
        public string OrderNumber { get; set; }

        [Field("purchase_order", true)]
        public string PurchaseOrder { get; set; }

        /// <summary>
        /// The date this License was purchased.
        /// </summary>
        [Field("purchase_date", true, converter: DateTimeConverter)]
        public DateTime? PurchaseDate { get; set; }

        /// <summary>
        /// The cost of this License when purchased.
        /// </summary>
        [Field("purchase_cost", true)]
        public decimal? PurchaseCost { get; set; }

        [Field("notes", true)]
        public string Notes { get; set; }

        [Field("expiration_date", true, converter: DateTimeConverter)]
        public DateTime? ExpirationDate { get; set; }

        [Field("seats", true)]
        public int? TotalSeats { get; set; }

        [Field("free_seats_count")]
        public int? FreeSeats { get; set; }

        [Field("license_name", true)]
        public string LicenseName { get; set; }

        [Field("license_email", true)]
        public string LicenseEmailAddress { get; set; }

        [Field("maintained", true)]
        public bool? IsMaintained { get; set; }

        [Field("category", "category_id", converter: CommonModelConverter)]
        public Category Category { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        [Field("user_can_checkout")]
        public bool? UserCanCheckOut { get; set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }

        [Field("reassignable", true)]
        public bool IsReassignable { get; set; }

        [Field("serial", true)]
        public string Serial { get; set; }

        [Field("supplier_id", true, converter: CommonModelConverter)]
        public Supplier Supplier { get; set; }

        [Field("termination_date", true, converter: DateTimeConverter)]
        public DateTime? TerminationDate { get; set; }

        [Field("user_id", true, converter: CommonModelConverter)]
        public User TODO_WHATS_THIS_User { get; set; }
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
        public bool? UserCanCheckOut { get; set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }

        public bool IsCheckedOut => AssignedUser != null || AssignedAsset != null;
    }
}
