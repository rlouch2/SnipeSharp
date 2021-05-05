using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(MaintenanceConverter))]
    [GeneratePartial, GenerateConverter]
    public sealed partial class Maintenance: IApiObject<Maintenance>
    {
        [DeserializeAs(Static.ID)]
        public int Id { get; }

        [DeserializeAs(Static.Types.ASSET)]
        public StubAsset Asset { get; }

        [DeserializeAs(Static.Types.MODEL)]
        public Stub<Model>? Model { get; }

        [DeserializeAs(Static.Types.COMPANY)]
        public Stub<Company>? Company { get; }

        [DeserializeAs(Static.TITLE)]
        public string Title { get; }

        [DeserializeAs(Static.Types.LOCATION)]
        public Stub<Location>? Location { get; }

        [DeserializeAs(Static.NOTES)]
        public string? Notes { get; }

        [DeserializeAs(Static.Types.SUPPLIER)]
        public Stub<Supplier> Supplier { get; }

        [DeserializeAs(Static.COST)]
        public decimal? Cost { get; }

        [DeserializeAs(Static.Maintenance.ASSET_MAINTENANCE_TYPE)]
        public AssetMaintenanceType MaintenanceType { get; }

        [DeserializeAs(Static.Maintenance.ASSET_MAINTENANCE_TIME, Type = typeof(int))]
        public TimeSpan? MaintenanceDuration { get; }

        [DeserializeAs(Static.Maintenance.START_DATE)]
        public FormattedDate StartDate { get; }

        [DeserializeAs(Static.Maintenance.COMPLETION_DATE)]
        public FormattedDate? CompletionDate { get; }

        [DeserializeAs(Static.Types.USER)]
        public Stub<User>? User { get; }

        [DeserializeAs(Static.CREATED_AT)]
        public FormattedDateTime CreatedAt { get; }

        [DeserializeAs(Static.UPDATED_AT)]
        public FormattedDateTime UpdatedAt { get; }

        [DeserializeAs(Static.AVAILABLE_ACTIONS, Type = typeof(PartialMaintenance.Actions), IsNonNullable = true)]
        public readonly Actions AvailableActions;

        [GeneratePartialActions]
        public partial struct Actions
        {
            public bool Update { get; }
            public bool Delete { get; }
        }

        internal Maintenance(PartialMaintenance partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Asset = partial.Asset ?? throw new ArgumentNullException(nameof(Asset));
            Model = partial.Model;
            Company = partial.Company;
            Title = partial.Title ?? throw new ArgumentNullException(nameof(Title));
            Location = partial.Location;
            Notes = partial.Notes;
            Supplier = partial.Supplier ?? throw new ArgumentNullException(nameof(Supplier));
            Cost = partial.Cost;
            MaintenanceType = partial.MaintenanceType ?? throw new ArgumentNullException(nameof(MaintenanceType));
            StartDate = partial.StartDate ?? throw new ArgumentNullException(nameof(StartDate));
            CompletionDate = partial.CompletionDate;
            User = partial.User;
            CreatedAt = partial.CreatedAt ?? throw new ArgumentNullException(nameof(CreatedAt));
            UpdatedAt = partial.UpdatedAt ?? throw new ArgumentNullException(nameof(UpdatedAt));
            AvailableActions = new Actions(partial.AvailableActions);

            if(partial.MaintenanceDuration is int days)
                MaintenanceDuration = StartDate.Date <= CompletionDate!.Date
                    ? new TimeSpan(days, 0, 0, 0, 0)
                    : new TimeSpan(-days, 0, 0, 0, 0);
        }
    }

    [GenerateFilter(typeof(MaintenanceSortOn))]
    public sealed partial class MaintenanceFilter: IFilter<Maintenance>
    {
    }

    [SortColumn]
    public enum MaintenanceSortOn
    {
        [EnumMember(Value = Static.ID)]
        Id,

        [EnumMember(Value = Static.TITLE)]
        Title,

        [EnumMember(Value = Static.Maintenance.ASSET_MAINTENANCE_TYPE)]
        AssetMaintenanceType,

        [EnumMember(Value = Static.Maintenance.ASSET_MAINTENANCE_TIME)]
        AssetMaintenanceTime,

        [EnumMember(Value = Static.COST)]
        Cost,

        [EnumMember(Value = Static.Maintenance.START_DATE)]
        StartDate,

        [EnumMember(Value = Static.Maintenance.COMPLETION_DATE)]
        CompletionDate,

        [EnumMember(Value = Static.NOTES)]
        Notes,

        [EnumMember(Value = Static.ASSET_TAG)]
        AssetTag,

        [EnumMember(Value = Static.ASSET_NAME)]
        AssetName,

        [EnumMember(Value = Static.Id.USER)]
        UserId
    }

    [JsonConverter(typeof(EnumJsonConverter<AssetMaintenanceType>))]
    public enum AssetMaintenanceType
    {
        [EnumMember(Value = "Maintenance")]
        Maintenance,

        [EnumMember(Value = "Repair")]
        Repair,

        [EnumMember(Value = "Upgrade")]
        Upgrade,

        [EnumMember(Value = "PAT test")]
        PATTest,

        [EnumMember(Value = "Calibration")]
        Calibration,

        [EnumMember(Value = "Software Support")]
        SoftwareSupport,

        [EnumMember(Value = "Hardware Support")]
        HardwareSupport,
    }

    public sealed class MaintenanceProperty: IPutable<Maintenance>, IPostable<Maintenance>, IPatchable<Maintenance>
    {
        [JsonPropertyName(Static.Id.ASSET)]
        public IApiObject<Asset> Asset { get; set; }

        [JsonPropertyName(Static.Id.SUPPLIER)]
        public IApiObject<Supplier> Supplier { get; set; }

        [JsonPropertyName(Static.Maintenance.ASSET_MAINTENANCE_TYPE)]
        public AssetMaintenanceType MaintenanceType { get; set; }

        [JsonPropertyName(Static.TITLE)]
        public string Title { get; set; }

        [JsonPropertyName(Static.Maintenance.START_DATE)]
        public DateTime StartDate { get; set; }

        [JsonPropertyName(Static.Maintenance.COMPLETION_DATE)]
        public DateTime? CompletionDate { get; set; }

        [JsonPropertyName(Static.Maintenance.IS_WARRANTY)]
        public bool? IsWarranty { get; set; }

        [JsonPropertyName(Static.COST)]
        public decimal? Cost { get; set; }

        [JsonPropertyName(Static.NOTES)]
        public string? Notes { get; set; }

        public MaintenanceProperty(IApiObject<Asset> asset, IApiObject<Supplier> supplier, AssetMaintenanceType maintenanceType, string title, DateTime startDate)
        {
            Asset = asset;
            Supplier = supplier;
            MaintenanceType = maintenanceType;
            Title = title;
            StartDate = startDate;
        }

        IToPatch<Maintenance> IPatchable<Maintenance>.GetPatchable(Maintenance main)
            => new MaintenancePatch
            {
                Asset = Asset.Id == main.Asset.Id ? null : Asset,
                Supplier = Supplier.Id == main.Supplier.Id ? null : Supplier,
                MaintenanceType = MaintenanceType == main.MaintenanceType ? null : MaintenanceType,
                Title = Title == main.Title ? null : Title,
                StartDate = StartDate == main.StartDate ? null : StartDate,
                CompletionDate = CompletionDate == main.CompletionDate?.Date ? null : CompletionDate,
                Cost = Cost == main.Cost ? null : Cost,
                Notes = Notes == main.Notes ? null : Notes,
            };

        public static explicit operator MaintenanceProperty(Maintenance maintenance)
            => new MaintenanceProperty(
                asset: maintenance.Asset,
                supplier: maintenance.Supplier,
                maintenanceType: maintenance.MaintenanceType,
                title: maintenance.Title,
                startDate: maintenance.StartDate
                ){
                    CompletionDate = maintenance.CompletionDate?.Date,
                    Cost = maintenance.Cost,
                    Notes = maintenance.Notes,
                };
    }

    internal sealed class MaintenancePatch: IToPatch<Maintenance>
    {
        [JsonPropertyName(Static.Id.ASSET)]
        public IApiObject<Asset>? Asset { get; set; }

        [JsonPropertyName(Static.Id.SUPPLIER)]
        public IApiObject<Supplier>? Supplier { get; set; }

        [JsonPropertyName(Static.Maintenance.ASSET_MAINTENANCE_TYPE)]
        public AssetMaintenanceType? MaintenanceType { get; set; }

        [JsonPropertyName(Static.TITLE)]
        public string? Title { get; set; }

        [JsonPropertyName(Static.Maintenance.START_DATE)]
        public DateTime? StartDate { get; set; }

        [JsonPropertyName(Static.Maintenance.COMPLETION_DATE)]
        public DateTime? CompletionDate { get; set; }

        [JsonPropertyName(Static.Maintenance.IS_WARRANTY)]
        public bool? IsWarranty { get; set; }

        [JsonPropertyName(Static.COST)]
        public decimal? Cost { get; set; }

        [JsonPropertyName(Static.NOTES)]
        public string? Notes { get; set; }
    }
}
