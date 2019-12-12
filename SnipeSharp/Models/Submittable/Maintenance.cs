using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A Maintenance.
    /// Maintenances are operations performed on Assets, such as repair or reimaging.
    /// </summary>
    [PathSegment("maintenances")]
    public sealed class Maintenance : CommonEndPointModel, IAvailableActions, IUpdatable<Maintenance>
    {
        /// <summary>Create a new Maintenance object.</summary>
        public Maintenance() { }

        /// <summary>Create a new Maintenance object with the supplied ID, for use with updating.</summary>
        internal Maintenance(int id)
        {
            Id = id;
        }

        /// <inheritdoc />
        [Field(DeserializeAs = "id")]
        public override int Id { get; protected set; }

        /// <value>Gets/sets asset this maintenance was performed on.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// <para>This field is required.</para>
        /// </remarks>
        [Field(DeserializeAs = "asset", SerializeAs = "asset_id", Converter = CommonModelConverter, IsRequired = true)]
        public Asset Asset { get; set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("title")]
        public override string Name { get; set; }

        /// <value>Gets the location for the maintenance.</value>
        [Field(DeserializeAs = "location", Converter = CommonModelConverter)]
        public Location Location { get; set; }

        /// <value>Gets/sets the notes for the maintenance.</value>
        [Field("notes")]
        public string Notes { get; set; }

        /// <value>Gets/sets the supplier for the maintenance.</value>
        [Field(DeserializeAs = "supplier", SerializeAs = "supplier_id", Converter = CommonModelConverter, IsRequired = true)]
        public Supplier Supplier { get; set; }

        /// <value>Gets/sets the cost of the maintenance.</value>
        [Field("cost")]
        public decimal? MaintenanceCost { get; set; }

        /// <value>Gets/sets the type of the maintenance.</value>
        [Field("asset_maintenance_type", IsRequired = true)]
        public MaintenanceType? MaintenanceType { get; set; }

        /// <value>Gets/sets if the maintenance is covered under warranty.</value>
        [Field("is_warranty")]
        public bool? IsWarranty { get; set; }

        /// <value>Gets/sets the date the maintenance begins.</value>
        [Field("start_date", Converter = DateTimeConverter, IsRequired = true)]
        public DateTime? StartDate { get; set; }

        /// <value>Gets/sets the duration of the maintenance.</value>
        [Field(DeserializeAs = "asset_maintenance_time", Converter = TimeSpanConverter)]
        public TimeSpan? MaintenanceDuration { get; private set; }

        /// <value>Gets/sets the date the maintenance ends.</value>
        [Field("completion_date", Converter = DateTimeConverter)]
        public DateTime? CompletionDate { get; set; }

        /// <value>Gets the user who created the maintenance.</value>
        [Field(DeserializeAs = "user_id")]
        public User User { get; private set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }

        /// <inheritdoc />
        public Maintenance CloneForUpdate()
            => new Maintenance(this.Id);

        /// <inheritdoc />
        public Maintenance WithValuesFrom(Maintenance other)
            => new Maintenance(this.Id)
            {
                Asset = other.Asset,
                Name = other.Name,
                Location = other.Location,
                Notes = other.Notes,
                Supplier = other.Supplier,
                MaintenanceCost = other.MaintenanceCost,
                MaintenanceType = other.MaintenanceType,
                IsWarranty = other.IsWarranty,
                StartDate = other.StartDate,
                MaintenanceDuration = other.MaintenanceDuration,
                CompletionDate = other.CompletionDate
            };
    }
}
