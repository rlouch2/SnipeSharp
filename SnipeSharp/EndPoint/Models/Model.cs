using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [EndPointInformation("models", "")]
    public class Model : CommonEndPointModel
    {
        [Field("id")]
        public override long Id { get; set; }

        [Field("name")]
        public override string Name { get; set; }

        [Field("manufacturer", FieldConverter = SerializeToId)]
        public Manufacturer Manufacturer { get; set; }

        [Field("image")]
        public Uri ImageUri { get; set; }

        [Field("model_number")]
        public string ModelNumber { get; set; }

        [Field("depreciation", FieldConverter = SerializeToId)]
        public Depreciation Depreciation { get; set; }

        [Field("assets_count")]
        public int? AssetsCount { get; set; }

        [Field("category", FieldConverter = SerializeToId)]
        public Category Category { get; set; }

        [Field("FieldSet", CanSerialize = false)]
        public FieldSet FieldSet { get; set; }

        [Field("eol")]
        public string Eol { get; set; }

        [Field("notes")]
        public string Notes { get; set; }

        [Field("created_at", FieldConverter = ExtractDateTime)]
        public override DateTime? CreatedAt { get; set; }

        [Field("updated_at", FieldConverter = ExtractDateTime)]
        public override DateTime? UpdatedAt { get; set; }

        [Field("deleted_at", FieldConverter = ExtractDateTime)]
        public DateTime? DeletedAt { get ;set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }
}