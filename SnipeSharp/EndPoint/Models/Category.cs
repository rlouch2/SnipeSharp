using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [PathSegment("categories")]
    public class Category : CommonEndPointModel
    {

        [Field("id")]
        public override int Id { get; set; }

        [Field("name", true, required: true)]
        public override string Name { get; set; }

        [Field("category_type", true, required: true)]
        public CategoryType? CategoryType { get; set; }

        [Field("eula", "use_default_eula")]
        public bool? UseDefaultEula { get; set; }

        [Field(null, "eula_text")]
        public string EulaText { get; set; }

        [Field(null, "user_id", converter: CommonModelConverter)]
        public User User { get; set; }

        [Field("checkin_email", true)]
        public bool? EmailUserOnCheckInOrOut { get; set; }

        [Field("require_acceptance", true)]
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

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; set; }

        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; set; }
        
        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }
}
