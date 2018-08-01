using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [EndPointInformation("manufacturers", "")]
    public class Manufacturer : CommonEndPointModel
    {
        [Field("id")]
        public override long Id { get; set; }

        [Field("name")]
        public override string Name { get; set; }

        [Field("url")]
        public Uri Url { get; set; }

        [Field("image")]
        public Uri ImageUri { get; set; }

        [Field("support_url")]
        public Uri SupportUrl { get; set; }

        [Field("support_phone")]
        public string SupportPhoneNumber { get; set; }

        [Field("support_email")]
        public string SupportEmailAddress { get; set; }

        [Field("assets_count")]
        public int? AssetsCount { get; set; }

        [Field("licenses_count")]
        public int? LicensesCount { get; set; }

        [Field("consumables_count")]
        public int? ConsumablesCount { get; set; }

        [Field("accessories_count")]
        public int? AccessoriesCount { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; set; }

        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; set; }

        [Field("deleted_at", converter: DateTimeConverter)]
        public DateTime? DeletedAt { get; set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }
}