using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnipeSharp.Models
{
    public sealed class Manufacturer: IApiObject<Manufacturer>
    {
        public int Id { get; }
        public string Name { get; }
        public Uri? Url { get; }
        public Uri? Image { get; }
        public Uri? SupportUrl { get; }
        public string? SupportPhone { get; }
        public string? SupportEmail { get; }
        public int AccessoriesCount { get; }
        public int AssetsCount { get; }
        public int ConsumablesCount { get; }
        public int LicensesCount { get; }
        public FormattedDateTime CreatedAt { get; }
        public FormattedDateTime UpdatedAt { get; }
        public FormattedDateTime? DeletedAt { get; }
        public readonly Actions AvailableActions;

        public struct Actions
        {
            public bool Update { get; }
            public bool Restore { get; }
            public bool Delete { get; }

            internal Actions(Serialization.PartialManufacturer.Actions actions)
            {
                Update = actions.Update;
                Restore = actions.Restore;
                Delete = actions.Delete;
            }
        }

        internal Manufacturer(Serialization.PartialManufacturer partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Name = partial.Name ?? throw new ArgumentNullException(nameof(Name));
            Url = partial.Url;
            Image = partial.Image;
            SupportUrl = partial.SupportUrl;
            SupportPhone = partial.SupportPhone;
            SupportEmail = partial.SupportEmail;
            AccessoriesCount = partial.AccessoriesCount;
            AssetsCount = partial.AssetsCount;
            ConsumablesCount = partial.ConsumablesCount;
            LicensesCount = partial.LicensesCount;
            CreatedAt = partial.CreatedAt ?? throw new ArgumentNullException(nameof(CreatedAt));
            UpdatedAt = partial.UpdatedAt ?? throw new ArgumentNullException(nameof(UpdatedAt));
            DeletedAt = partial.DeletedAt;
            AvailableActions = new Actions(partial.AvailableActions);
        }
    }

    public sealed class ManufacturerFilter : IFilter<Manufacturer>
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string? SearchString { get; set; }
        public SortOrder? SortOrder { get; set; }
        public ManufacturerSortOn? SortOn { get; set; }
        public bool? IsDeleted { get; set; }

        IFilter<Manufacturer> IFilter<Manufacturer>.Clone()
            => new ManufacturerFilter
            {
                Limit = Limit,
                Offset = Offset,
                SearchString = SearchString,
                SortOrder = SortOrder,
                SortOn = SortOn,
                IsDeleted = IsDeleted
            };

        IReadOnlyDictionary<string, string?> IFilter<Manufacturer>.GetParameters()
        {
            throw new NotImplementedException();
        }
    }

    public enum ManufacturerSortOn
    {
        CreatedAt = 0,
        Id,
        Name,
        Url,
        SupportUrl,
        SupportPhone,
        SupportEmail,
        UpdatedAt,
        Image,
        //AccessoriesCount, // for some reason, can't actually sort as this, but can sort on components? // TODO: submit patch to SnipeIT
        AssetsCount,
        ConsumablesCount,
        LicensesCount,
    }

    public sealed class ManufacturerProperty: IPostable<Manufacturer>, IPutable<Manufacturer>, IPatchable<Manufacturer>
    {
        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set => _name = !string.IsNullOrEmpty(value)
                ? value
                : throw new ArgumentException(Static.Error.VALUE_EMPTY, paramName: nameof(Name));
        }

        public Uri? Url { get; set; }
        public Uri? Image { get; set; }
        public Uri? SupportUrl { get; set; }
        public string? SupportPhone { get; set; }
        public string? SupportEmail { get; set; }

        public ManufacturerProperty(string name)
            => Name = name;

        IToPatch<Manufacturer> IPatchable<Manufacturer>.GetPatchable(Manufacturer main)
            => new ManufacturerPatch
            {
                Name = Name == main.Name ? null : Name,
                Url = Url == main.Url ? null : Url,
                Image = Image == main.Image ? null : Image,
                SupportUrl = SupportUrl == main.SupportUrl ? null : SupportUrl,
                SupportPhone = SupportPhone == main.SupportPhone ? null : SupportPhone,
                SupportEmail = SupportEmail == main.SupportEmail ? null : SupportEmail,
            };

        public static explicit operator ManufacturerProperty(Manufacturer manufacturer)
            => new ManufacturerProperty(manufacturer.Name)
            {
                Url = manufacturer.Url,
                Image = manufacturer.Image,
                SupportUrl = manufacturer.SupportUrl,
                SupportPhone = manufacturer.SupportPhone,
                SupportEmail = manufacturer.SupportEmail,
            };
    }

    internal sealed class ManufacturerPatch: IToPatch<Manufacturer>
    {
        public string? Name { get; set; }
        public Uri? Url { get; set; }
        public Uri? Image { get; set; }
        public Uri? SupportUrl { get; set; }
        public string? SupportPhone { get; set; }
        public string? SupportEmail { get; set; }
    }

    public static class ManufacturerSortOnExtensions
    {
        public static string? Serialize(this ManufacturerSortOn? column)
            => column switch
            {
                ManufacturerSortOn.CreatedAt => Static.CREATED_AT,
                ManufacturerSortOn.Id => Static.ID,
                ManufacturerSortOn.Name => Static.NAME,
                ManufacturerSortOn.Url => Static.URL,
                ManufacturerSortOn.Image => Static.IMAGE,
                ManufacturerSortOn.SupportUrl => Static.Manufacturer.SUPPORT_URL,
                ManufacturerSortOn.SupportPhone => Static.Manufacturer.SUPPORT_PHONE,
                ManufacturerSortOn.SupportEmail => Static.Manufacturer.SUPPORT_EMAIL,
                ManufacturerSortOn.AssetsCount => Static.Count.ASSETS,
                ManufacturerSortOn.ConsumablesCount => Static.Count.CONSUMABLES,
                ManufacturerSortOn.LicensesCount => Static.Count.LICENSES,
                _ => null
            };
    }

    namespace Serialization
    {
        internal sealed class PartialManufacturer
        {
            [JsonPropertyName(Static.ID)]
            public int? Id { get; set; }

            [JsonPropertyName(Static.NAME)]
            public string? Name { get; set; }

            [JsonPropertyName(Static.URL)]
            public Uri? Url { get; set; }

            [JsonPropertyName(Static.IMAGE)]
            public Uri? Image { get; set; }

            [JsonPropertyName(Static.Manufacturer.SUPPORT_URL)]
            public Uri? SupportUrl { get; set; }

            [JsonPropertyName(Static.Manufacturer.SUPPORT_PHONE)]
            public string? SupportPhone { get; set; }

            [JsonPropertyName(Static.Manufacturer.SUPPORT_EMAIL)]
            public string? SupportEmail { get; set; }

            [JsonPropertyName(Static.Count.ACCESSORIES)]
            public int AccessoriesCount { get; set; }

            [JsonPropertyName(Static.Count.ASSETS)]
            public int AssetsCount { get; set; }

            [JsonPropertyName(Static.Count.CONSUMABLES)]
            public int ConsumablesCount { get; set; }

            [JsonPropertyName(Static.Count.LICENSES)]
            public int LicensesCount { get; set; }

            [JsonPropertyName(Static.CREATED_AT)]
            public FormattedDateTime? CreatedAt { get; set; }

            [JsonPropertyName(Static.UPDATED_AT)]
            public FormattedDateTime? UpdatedAt { get; set; }

            [JsonPropertyName(Static.DELETED_AT)]
            public FormattedDateTime? DeletedAt { get; set; }

            [JsonPropertyName(Static.AVAILABLE_ACTIONS)]
            public Actions AvailableActions { get; set; }

            public struct Actions
            {
                [JsonPropertyName(Static.Actions.UPDATE)]
                public bool Update { get; set; }

                [JsonPropertyName(Static.Actions.RESTORE)]
                public bool Restore { get; set; }

                [JsonPropertyName(Static.Actions.DELETE)]
                public bool Delete { get; set; }
            }
        }

        internal sealed class ManufacturerConverter : JsonConverter<Manufacturer>
        {
            public override Manufacturer? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialManufacturer>(ref reader, options);
                if(null == partial)
                    return null;
                return new Manufacturer(partial);
            }

            public override void Write(Utf8JsonWriter writer, Manufacturer value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }
    }
}
