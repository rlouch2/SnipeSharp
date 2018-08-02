using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [PathSegment("companies")]
    public class Company : CommonEndPointModel
    {
        [Field("id")]
        public override int Id { get; set; }

        [Field("name", true, required: true)]
        public override string Name { get; set; }

        [Field("image")]
        public Uri ImageUri { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; set; }

        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; set; }

        [Field("assets_count")]
        public int AssetsCount { get; set; }

        [Field("licenses_count")]
        public int LicensesCount { get; set; }

        [Field("accessories_count")]
        public int AccessoriesCount { get; set; }

        [Field("consumables_count")]
        public int ConsumablesCount { get; set; }

        [Field("components_count")]
        public int ComponentsCount { get; set; }

        [Field("users_count")]
        public int UsersCount { get; set; }
        
        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }
}