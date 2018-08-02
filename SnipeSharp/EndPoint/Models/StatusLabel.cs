using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [PathSegment("statuslabels")]
    public class StatusLabel : CommonEndPointModel
    {
        [Field("id")]
        public override int Id { get; protected set; }

        [Field("name")]
        public override string Name { get; set; }

        [Field("type")]
        public string Type { get; set; }

        [Field("color")]
        public string Color { get; set; }

        [Field("show_in_nav")]
        public bool? ShouldShowInNav { get; set; }

        [Field("default_lable")]
        public bool? IsDefaultLabel { get; set; }

        [Field("assets_count")]
        public int? AssetsCount { get; set; }

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
