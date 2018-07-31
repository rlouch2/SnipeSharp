using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [EndPointInformation("maintenances", "")]
    public class Maintenance : CommonEndPointModel
    {
        [Field("id")]
        public override long Id { get; set; }

        [Field("asset")]
        public Asset Asset { get; set; }

        [Field("title")]
        public override string Name { get; set; }

        [Field("location")]
        public Location Location { get; set; }

        [Field("notes")]
        public Supplier Supplier { get; set; }

        [Field("cost")]
        public decimal? MaintenanceCost { get; set; }

        [Field("asset_maintenance_type")]
        public string MaintenanceType { get; set; }

        [Field("start_date", FieldConverter = ExtractDateTime)]
        public DateTime? StartDate { get; set; }

        [Field("asset_maintenance_time", FieldConverter = ExtractTimeSpanDays)]
        public TimeSpan? MaintenanceDuration { get; set; }

        [Field("completion_date", FieldConverter = ExtractDateTime)]
        public DateTime? CompletionDate { get; set; }

        [Field("user_id")]
        public User User { get; set; }

        [Field("created_at", FieldConverter = ExtractDateTime)]
        public override DateTime? CreatedAt { get; set; }

        [Field("updated_at", FieldConverter = ExtractDateTime)]
        public override DateTime? UpdatedAt { get; set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }
}