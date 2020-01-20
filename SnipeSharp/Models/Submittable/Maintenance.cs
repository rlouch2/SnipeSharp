using System;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;
using System.Runtime.Serialization;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A Maintenance.
    /// Maintenances are operations performed on Assets, such as repair or reimaging.
    /// </summary>
    [PathSegment("maintenances")]
    public sealed class Maintenance : CommonEndPointModel, IAvailableActions, IPatchable
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
        public override int Id { get; set; }

        /// <value>Gets/sets asset this maintenance was performed on.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// <para>This field is required.</para>
        /// </remarks>
        [Field(DeserializeAs = "asset", SerializeAs = "asset_id", Converter = CommonModelConverter, IsRequired = true)]
        [Patch(nameof(isAssetModified))]
        public Asset Asset
        {
            get => asset;
            set
            {
                isAssetModified = true;
                asset = value;
            }
        }
        private bool isAssetModified = false;
        private Asset asset;

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("title")]
        [Patch(nameof(isNameModified))]
        public override string Name
        {
            get => name;
            set
            {
                isNameModified = true;
                name = value;
            }
        }
        private bool isNameModified = false;
        private string name;

        /// <value>Gets the location for the maintenance.</value>
        [Field(DeserializeAs = "location", Converter = CommonModelConverter)]
        [Patch(nameof(isLocationModified))]
        public Location Location
        {
            get => location;
            set
            {
                isLocationModified = true;
                location = value;
            }
        }
        private bool isLocationModified = false;
        private Location location;

        /// <value>Gets/sets the notes for the maintenance.</value>
        [Field("notes")]
        public string Notes { get; set; }

        /// <value>Gets/sets the supplier for the maintenance.</value>
        [Field(DeserializeAs = "supplier", SerializeAs = "supplier_id", Converter = CommonModelConverter, IsRequired = true)]
        [Patch(nameof(isSupplierModified))]
        public Supplier Supplier
        {
            get => supplier;
            set
            {
                isSupplierModified = true;
                supplier = value;
            }
        }
        private bool isSupplierModified = false;
        private Supplier supplier;

        /// <value>Gets/sets the cost of the maintenance.</value>
        [Field("cost")]
        [Patch(nameof(isMaintenanceCostModified))]
        public decimal? MaintenanceCost
        {
            get => maintenanceCost;
            set
            {
                isMaintenanceCostModified = true;
                maintenanceCost = value;
            }
        }
        private bool isMaintenanceCostModified = false;
        private decimal? maintenanceCost;

        /// <value>Gets/sets the type of the maintenance.</value>
        [Field("asset_maintenance_type", IsRequired = true)]
        [Patch(nameof(isMaintenanceTypeModified))]
        public MaintenanceType? MaintenanceType
        {
            get => maintenanceType;
            set
            {
                isMaintenanceTypeModified = true;
                maintenanceType = value;
            }
        }
        private bool isMaintenanceTypeModified = false;
        private MaintenanceType? maintenanceType;

        /// <value>Gets/sets if the maintenance is covered under warranty.</value>
        [Field("is_warranty")]
        [Patch(nameof(isIsWarrantyModified))]
        public bool? IsWarranty
        {
            get => isWarranty;
            set
            {
                isIsWarrantyModified = true;
                isWarranty = value;
            }
        }
        private bool isIsWarrantyModified = false;
        private bool? isWarranty;

        /// <value>Gets/sets the date the maintenance begins.</value>
        [Field("start_date", Converter = DateTimeConverter, IsRequired = true)]
        [Patch(nameof(isStartDateModified))]
        public DateTime? StartDate
        {
            get => startDate;
            set
            {
                isStartDateModified = true;
                startDate = value;
            }
        }
        private bool isStartDateModified = false;
        private DateTime? startDate;

        /// <value>Gets/sets the duration of the maintenance.</value>
        [Field(DeserializeAs = "asset_maintenance_time", Converter = TimeSpanConverter)]
        public TimeSpan? MaintenanceDuration { get; private set; }

        /// <value>Gets/sets the date the maintenance ends.</value>
        [Field("completion_date", Converter = DateTimeConverter)]
        [Patch(nameof(isCompletionDateModified))]
        public DateTime? CompletionDate
        {
            get => completionDate;
            set
            {
                isCompletionDateModified = true;
                completionDate = value;
            }
        }
        private bool isCompletionDateModified = false;
        private DateTime? completionDate;

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
        public AvailableAction AvailableActions { get; private set; }

        void IPatchable.SetAllModifiedState(bool isModified)
        {
            isAssetModified = isModified;
            isNameModified = isModified;
            isLocationModified = isModified;
            isSupplierModified = isModified;
            isMaintenanceCostModified = isModified;
            isMaintenanceTypeModified = isModified;
            isIsWarrantyModified = isModified;
            isStartDateModified = isModified;
            isCompletionDateModified = isModified;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            ((IPatchable)this).SetAllModifiedState(false);
        }
    }
}
