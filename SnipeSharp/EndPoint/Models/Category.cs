using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [EndPointInformation("categories", "")]
    public class Category : CommonEndPointModel
    {

        [Field("id")]
        public override long Id { get; set; }

        [Field("name")]
        public override string Name { get; set; }

        [Field("category_type")]
        public string CategoryType { get; set; }

        [Field("eula")]
        public bool? Eula { get; set; } // todo name

        [Field("checkin_email")]
        public bool? CheckInEmail { get; set; } // todo name

        [Field("require_acceptance")]
        public bool? IsAcceptanceRequired { get; set; }

        [Field("assets_count")]
        public int? AssetsCount { get; set; }

        [Field("accessories_count")]
        public int? AccessoriesCount { get; set; }

        [Field("consumables_count")]
        public int? ConsumablesCount { get; set; }

        [Field("copmonents_count")]
        public int? ComponentsCount { get; set; }

        [Field("licenses_count")]
        public int? LicensesCount { get; set; }

        [Field("created_at", FieldConverter = ExtractDateTime)]
        public override DateTime? CreatedAt { get; set; }

        [Field("updated_at", FieldConverter = ExtractDateTime)]
        public override DateTime? UpdatedAt { get; set; }
        
        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }
}