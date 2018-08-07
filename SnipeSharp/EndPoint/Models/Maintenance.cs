using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// A Maintenance.
    /// Maintenances are operations performed on Assets, such as repair or reimaging.
    /// </summary>
    [PathSegment("maintenances")]
    public sealed class Maintenance : CommonEndPointModel, IAvailableActions
    {
        /// <inheritdoc />
        [Field("id")]
        public override int Id { get; protected set; }

        /// <value>Gets/sets asset this maintenance was performed on.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// <para>This field is required.</para>
        /// </remarks>
        [Field("asset", "asset_id", converter: CommonModelConverter, required: true)]
        public Asset Asset { get; set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("title", true)]
        public override string Name { get; set; }

        /// <value>Gets the location for the maintenance.</value>
        [Field("location", converter: CommonModelConverter)]
        public Location Location { get; set; }

        /// <value>Gets/sets the notes for the maintenance.</value>
        [Field("notes", true)]
        public string Notes { get; set; }

        /// <value>Gets/sets the supplier for the maintenance.</value>
        [Field("supplier", "supplier_id", converter: CommonModelConverter, required: true)]
        public Supplier Supplier { get; set; }

        /// <value>Gets/sets the cost of the maintenance.</value>
        [Field("cost", true)]
        public decimal? MaintenanceCost { get; set; }

        /// <value>Gets/sets the type of the maintenance.</value>
        [Field("asset_maintenance_type", true, required: true)]
        public MaintenanceType? MaintenanceType { get; set; }

        /// <value>Gets/sets if the maintenance is covered under warranty.</value>
        [Field("is_warranty", true)]
        public bool? IsWarranty { get; set; }

        /// <value>Gets/sets the date the maintenance begins.</value>
        [Field("start_date", true, converter: DateTimeConverter, required: true)]
        public DateTime? StartDate { get; set; }

        /// <value>Gets/sets the duration of the maintenance.</value>
        [Field("asset_maintenance_time", converter: TimeSpanConverter)]
        public TimeSpan? MaintenanceDuration { get; private set; }

        /// <value>Gets/sets the date the maintenance ends.</value>
        [Field("completion_date", true, converter: DateTimeConverter)]
        public DateTime? CompletionDate { get; set; }

        /// <value>Gets the user who created the maintenance.</value>
        [Field("user_id")]
        public User User { get; private set; }

        /// <inheritdoc />
        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <inheritdoc />
        [Field("available_actions", converter: AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }
    }
}
