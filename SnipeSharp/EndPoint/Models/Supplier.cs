using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [PathSegment("suppliers")]
    public sealed class Supplier : CommonEndPointModel
    {
        [Field("id")]
        public override int Id { get; protected set; }

        [Field("name")]
        public override string Name { get; set; }

        [Field("image")]
        public Uri ImageUri { get; set; }

        [Field("address")]
        public string Address { get; set; }

        [Field("address2")]
        public string Address2 { get; set; }

        [Field("city")]
        public string City { get; set; }

        [Field("state")]
        public string State { get; set; }

        [Field("country")]
        public string Country { get; set; }

        [Field("zip")]
        public string ZipCode { get; set; }

        [Field("fax")]
        public string FaxNumber { get; set; }

        [Field("phone")]
        public string PhoneNumber { get; set; }

        [Field("email")]
        public string EmailAddress { get; set; }

        [Field("contact")]
        public string Contact { get; set; } // todo name

        [Field("assets_count")]
        public int? AssetsCount { get; set; }

        [Field("accessories_count")]
        public int? AccessoriesCount { get; set; }

        [Field("licenses_count")]
        public int? LicensesCount { get; set; }

        [Field("notes")]
        public string Notes { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }
        
        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }
}
