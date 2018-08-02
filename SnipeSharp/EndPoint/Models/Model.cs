using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [PathSegment("models")]
    public class Model : CommonEndPointModel
    {
        [Field("id")]
        public override int Id { get; protected set; }

        [Field("name")]
        public override string Name { get; set; }

        [Field("manufacturer", converter: CommonModelConverter)]
        public Manufacturer Manufacturer { get; set; }

        [Field("image")]
        public Uri ImageUri { get; set; }

        [Field("model_number")]
        public string ModelNumber { get; set; }

        [Field("depreciation", converter: CommonModelConverter)]
        public Depreciation Depreciation { get; set; }

        [Field("assets_count")]
        public int? AssetsCount { get; set; }

        [Field("category", converter: CommonModelConverter)]
        public Category Category { get; set; }

        [Field("FieldSet")]
        public FieldSet FieldSet { get; set; }

        [Field("eol")]
        public string Eol { get; set; }

        [Field("notes")]
        public string Notes { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        [Field("deleted_at", converter: DateTimeConverter)]
        public DateTime? DeletedAt { get ;set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }
}
