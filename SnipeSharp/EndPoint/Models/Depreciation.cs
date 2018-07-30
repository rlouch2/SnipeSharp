using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [EndPointInformation("depreciations", "")]
    public class Depreciation : CommonEndPointModel
    {
        [Field("id")]
        public override long Id { get; set; }

        [Field("name")]
        public override string Name { get; set; }

        [Field("months", FieldConverter = StripMonthSuffix)]
        public int? Months { get; set; }

        [Field("created_at", FieldConverter = ExtractDateTime)]
        public override DateTime? CreatedAt { get; set; }

        [Field("updated_at", FieldConverter = ExtractDateTime)]
        public override DateTime? UpdatedAt { get; set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }
}