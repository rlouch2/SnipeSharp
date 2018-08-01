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
        public override int Id { get; set; }

        [Field("asset", "asset_id", converter: CommonModelConverter)]
        public Asset Asset { get; set; }

        [Field("title", true)]
        public override string Name { get; set; }

        [Field("location")]
        public Location Location { get; set; }

        [Field("notes", true)]
        public string Notes { get; set; }

        [Field("supplier", "supplier_id", converter: CommonModelConverter)]
        public Supplier Supplier { get; set; }

        [Field("cost", true)]
        public decimal? MaintenanceCost { get; set; }

        [Field("asset_maintenance_type", true)]
        public string MaintenanceType { get; set; }

        [Field("is_warranty", true)]
        public bool? IsWarranty { get; set; }

        [Field("start_date", true, converter: DateTimeConverter)]
        public DateTime? StartDate { get; set; }

        [Field("asset_maintenance_time", converter: TimeSpanConverter)]
        public TimeSpan? MaintenanceDuration { get; set; }

        [Field("completion_date", true, converter: DateTimeConverter)]
        public DateTime? CompletionDate { get; set; }

        [Field("user_id")]
        public User User { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; set; }

        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }
}