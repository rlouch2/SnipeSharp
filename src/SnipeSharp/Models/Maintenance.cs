using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(Serialization.MaintenanceConverter))]
    public sealed class Maintenance: IApiObject<Maintenance>
    {
        public int Id { get; }
        public StubAsset Asset { get; }
        public Stub<Model>? Model { get; }
        public Stub<Company>? Company { get; }
        public string Title { get; }
        public Stub<Location>? Location { get; }
        public string? Notes { get; }
        public Stub<Supplier> Supplier { get; }
        public decimal? Cost { get; }
        public AssetMaintenanceType MaintenanceType { get; }
        public TimeSpan? MaintenanceDuration { get; }
        public FormattedDate StartDate { get; }
        public FormattedDate? CompletionDate { get; }
        public Stub<User>? User { get; }
        public FormattedDateTime CreatedAt { get; }
        public FormattedDateTime UpdatedAt { get; }
        public readonly Actions AvailableActions;

        public struct Actions
        {
            public bool Update { get; }
            public bool Delete { get; }

            internal Actions(Serialization.PartialMaintenance.Actions actions)
            {
                Update = actions.Update;
                Delete = actions.Delete;
            }
        }

        internal Maintenance(Serialization.PartialMaintenance partial)
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
            MaintenanceType = partial.AssetMaintenanceType ?? throw new ArgumentNullException(nameof(AssetMaintenanceType));
            StartDate = partial.StartDate ?? throw new ArgumentNullException(nameof(StartDate));
            CompletionDate = partial.CompletionDate;
            User = partial.User;
            CreatedAt = partial.CreatedAt ?? throw new ArgumentNullException(nameof(CreatedAt));
            UpdatedAt = partial.UpdatedAt ?? throw new ArgumentNullException(nameof(UpdatedAt));
            AvailableActions = new Actions(partial.AvailableActions);

            if(partial.AssetMaintenanceTime is int days)
                MaintenanceDuration = StartDate.Date <= CompletionDate!.Date
                    ? new TimeSpan(days, 0, 0, 0, 0)
                    : new TimeSpan(-days, 0, 0, 0, 0);
        }
    }

    public sealed class MaintenanceFilter : IFilter<Maintenance>
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string? SearchString { get; set; }
        public SortOrder? SortOrder { get; set; }
        public MaintenanceSortOn? SortOn { get; set; }
        public IApiObject<Asset>? Asset { get; set; }

        IFilter<Maintenance> IFilter<Maintenance>.Clone()
            => new MaintenanceFilter
            {
                Limit = Limit,
                Offset = Offset,
                SearchString = SearchString,
                SortOrder = SortOrder,
                SortOn = SortOn,
                Asset = Asset
            };

        IReadOnlyDictionary<string, string?> IFilter<Maintenance>.GetParameters()
            => new Dictionary<string, string?>()
                .AddIfNotNull(Static.LIMIT, Limit?.ToString())
                .AddIfNotNull(Static.OFFSET, Offset?.ToString())
                .AddIfNotNull(Static.SEARCH, SearchString)
                .AddIfNotNull(Static.ORDER, SortOrder.Serialize())
                .AddIfNotNull(Static.SORT_COLUMN, SortOn.Serialize())
                .AddIfNotNull(Static.Id.ASSET, Asset?.Id.ToString());
    }

    public enum MaintenanceSortOn
    {
        Id,
        Title,
        AssetMaintenanceType,
        AssetMaintenanceTime,
        Cost,
        StartDate,
        CompletionDate,
        Notes,
        AssetTag,
        AssetName,
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

    public static class MaintenanceSortOnExtensions
    {
        public static string? Serialize(this MaintenanceSortOn? column)
            => column switch
            {
                MaintenanceSortOn.Id => Static.ID,
                MaintenanceSortOn.Title => Static.TITLE,
                MaintenanceSortOn.AssetMaintenanceTime => Static.Maintenance.ASSET_MAINTENANCE_TIME,
                MaintenanceSortOn.AssetMaintenanceType => Static.Maintenance.ASSET_MAINTENANCE_TYPE,
                MaintenanceSortOn.Cost => Static.COST,
                MaintenanceSortOn.StartDate => Static.Maintenance.START_DATE,
                MaintenanceSortOn.CompletionDate => Static.Maintenance.COMPLETION_DATE,
                MaintenanceSortOn.Notes => Static.NOTES,
                MaintenanceSortOn.AssetTag => Static.ASSET_TAG,
                MaintenanceSortOn.AssetName => Static.ASSET_NAME,
                MaintenanceSortOn.UserId => Static.Id.USER,
                _ => null
            };
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

    namespace Serialization
    {
        internal sealed class PartialMaintenance
        {
            [JsonPropertyName(Static.ID)]
            public int? Id { get; set; }

            [JsonPropertyName(Static.Types.ASSET)]
            public StubAsset? Asset { get; set; }

            [JsonPropertyName(Static.Types.MODEL)]
            public Stub<Model>? Model { get; set; }

            [JsonPropertyName(Static.Types.COMPANY)]
            public Stub<Company>? Company { get; set; }

            [JsonPropertyName(Static.TITLE)]
            public string? Title { get; set;  }

            [JsonPropertyName(Static.Types.LOCATION)]
            public Stub<Location>? Location { get; set; }

            [JsonPropertyName(Static.NOTES)]
            public string? Notes { get; set; }

            [JsonPropertyName(Static.Types.SUPPLIER)]
            public Stub<Supplier>? Supplier { get; set; }

            [JsonPropertyName(Static.COST)]
            public decimal? Cost { get; set; }

            [JsonPropertyName(Static.Maintenance.ASSET_MAINTENANCE_TYPE)]
            public AssetMaintenanceType? AssetMaintenanceType { get; set; }

            [JsonPropertyName(Static.Maintenance.ASSET_MAINTENANCE_TIME)]
            public int? AssetMaintenanceTime { get; set; }

            [JsonPropertyName(Static.Maintenance.START_DATE)]
            public FormattedDate? StartDate { get; set; }

            [JsonPropertyName(Static.Maintenance.COMPLETION_DATE)]
            public FormattedDate? CompletionDate { get; set; }

            [JsonPropertyName(Static.Id.USER)]
            public Stub<User>? User { get; set; }

            [JsonPropertyName(Static.CREATED_AT)]
            public FormattedDateTime? CreatedAt { get; set; }

            [JsonPropertyName(Static.UPDATED_AT)]
            public FormattedDateTime? UpdatedAt { get; set; }

            [JsonPropertyName(Static.AVAILABLE_ACTIONS)]
            public Actions AvailableActions { get; set; }

            public struct Actions
            {
                [JsonPropertyName(nameof(Static.Actions.UPDATE))]
                public bool Update { get; set; }

                [JsonPropertyName(nameof(Static.Actions.DELETE))]
                public bool Delete { get; set; }
            }
        }

        internal sealed class MaintenanceConverter : JsonConverter<Maintenance>
        {
            public override Maintenance? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialMaintenance>(ref reader, options);
                if(null == partial)
                    return null;
                return new Maintenance(partial);
            }

            public override void Write(Utf8JsonWriter writer, Maintenance value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }
    }
}
