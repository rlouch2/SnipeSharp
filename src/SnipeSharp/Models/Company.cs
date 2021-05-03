using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using SnipeSharp.Exceptions;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(Serialization.CompanyConverter))]
    public sealed class Company: IApiObject<Company>
    {
        public int Id { get; }
        public string Name { get; }
        public Uri? Image { get; }
        public FormattedDate CreatedAt { get; }
        public FormattedDate UpdatedAt { get; }
        public int AssetsCount { get; }
        public int LicensesCount { get; }
        public int AccessoriesCount { get; }
        public int ConsumablesCount { get; }
        public int ComponentsCount { get; }
        public int UsersCount { get; }

        public readonly Actions AvailableActions;

        public struct Actions
        {
            public bool Update { get; }
            public bool Delete { get; }

            internal Actions(Serialization.PartialCompany.Actions partial)
                => (Update, Delete) = partial;

            public override string ToString()
            {
                var joiner = new StringJoiner("{", ",", "}");
                if(Delete)
                    joiner.Append(nameof(Delete));
                if(Update)
                    joiner.Append(nameof(Update));
                return joiner.ToString();
            }
        }

        internal Company(Serialization.PartialCompany partial)
        {
            Id = partial.Id ?? throw new MissingRequiredPropertyException(nameof(Id), nameof(Company));
            Name = partial.Name ?? throw new MissingRequiredPropertyException(nameof(Name), nameof(Company));
            Image = partial.Image;
            CreatedAt = partial.CreatedAt ?? throw new MissingRequiredPropertyException(nameof(CreatedAt), nameof(Company));
            UpdatedAt = partial.UpdatedAt ?? throw new MissingRequiredPropertyException(nameof(UpdatedAt), nameof(Company));
            AssetsCount = partial.AssetsCount;
            LicensesCount = partial.LicensesCount;
            AccessoriesCount = partial.AccessoriesCount;
            ConsumablesCount = partial.ConsumablesCount;
            ComponentsCount = partial.ComponentsCount;
            UsersCount = partial.UsersCount;
            AvailableActions = new Actions(partial.AvailableActions);
        }
    }

    public sealed class CompanyFilter : IFilter<Company>
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string? SearchString { get; set; }
        public SortOrder? SortOrder { get; set; }
        public CompanySortOn? SortOn { get; set; }

        IFilter<Company> IFilter<Company>.Clone()
            => new CompanyFilter
            {
                Limit = Limit,
                Offset = Offset,
                SearchString = SearchString,
                SortOrder = SortOrder,
                SortOn = SortOn
            };

        IReadOnlyDictionary<string, string?> IFilter<Company>.GetParameters()
            => new Dictionary<string, string?>()
                .AddIfNotNull(Static.LIMIT, Limit?.ToString())
                .AddIfNotNull(Static.OFFSET, Offset?.ToString())
                .AddIfNotNull(Static.SEARCH, SearchString)
                .AddIfNotNull(Static.ORDER, SortOrder.Serialize())
                .AddIfNotNull(Static.SORT_COLUMN, SortOn.Serialize());
    }

    public enum CompanySortOn
    {
        Id,
        Name,
        CreatedAt,
        UpdatedAt,
        UsersCount,
        AssetsCount,
        Licensescount,
        AccessoriesCount,
        ComponentsCount,
        ConsumablesCount
    }

    public sealed class CompanyProperty: IPutable<Company>, IPostable<Company>, IPatchable<Company>
    {
        [JsonPropertyName(Static.NAME)]
        public string Name
        {
            get => _name;
            set => _name = !string.IsNullOrEmpty(value) ? value : throw new ArgumentException(Static.Error.VALUE_EMPTY);
        }
        private string _name = string.Empty;

        public CompanyProperty(string name)
            => Name = name;

        IToPatch<Company> IPatchable<Company>.GetPatchable(Company main)
            => new CompanyPatch { Name = Name == main.Name ? null : Name };

        public static explicit operator CompanyProperty(Company company)
            => new CompanyProperty(company.Name);
    }

    internal sealed class CompanyPatch: IToPatch<Company>
    {
        [JsonPropertyName(Static.NAME)]
        public string? Name { get; init; }
    }

    public static class CompanySortOnExtensions
    {
        public static string? Serialize(this CompanySortOn? column)
            => column switch
            {
                CompanySortOn.Id => Static.ID,
                CompanySortOn.Name => Static.NAME,
                CompanySortOn.CreatedAt => Static.CREATED_AT,
                CompanySortOn.UpdatedAt => Static.UPDATED_AT,
                CompanySortOn.UsersCount => Static.Count.USERS,
                CompanySortOn.AssetsCount => Static.Count.ASSETS,
                CompanySortOn.Licensescount => Static.Count.LICENSES,
                CompanySortOn.AccessoriesCount => Static.Count.ACCESSORIES,
                CompanySortOn.ComponentsCount => Static.Count.COMPONENTS,
                CompanySortOn.ConsumablesCount => Static.Count.CONSUMABLES,
                _ => null
            };
    }

    namespace Serialization
    {
        internal sealed class PartialCompany
        {
            [JsonPropertyName(Static.ID)]
            public int? Id { get; set; }

            [JsonPropertyName(Static.NAME)]
            public string? Name { get; set; }

            [JsonPropertyName(Static.IMAGE)]
            public Uri? Image { get; set; }

            [JsonPropertyName(Static.CREATED_AT)]
            public FormattedDate? CreatedAt { get; set; }

            [JsonPropertyName(Static.UPDATED_AT)]
            public FormattedDate? UpdatedAt { get; set; }

            [JsonPropertyName(Static.Count.ASSETS)]
            public int AssetsCount { get; set; }

            [JsonPropertyName(Static.Count.LICENSES)]
            public int LicensesCount { get; set; }

            [JsonPropertyName(Static.Count.ACCESSORIES)]
            public int AccessoriesCount { get; set; }

            [JsonPropertyName(Static.Count.CONSUMABLES)]
            public int ConsumablesCount { get; set; }

            [JsonPropertyName(Static.Count.COMPONENTS)]
            public int ComponentsCount { get; set; }

            [JsonPropertyName(Static.Count.USERS)]
            public int UsersCount { get; set; }

            [JsonPropertyName(Static.AVAILABLE_ACTIONS)]
            public Actions AvailableActions { get; set; }

            public struct Actions
            {
                [JsonPropertyName(Static.Actions.UPDATE)]
                public bool Update { get; set; }

                [JsonPropertyName(Static.Actions.DELETE)]
                public bool Delete { get; set; }

                internal void Deconstruct(out bool update, out bool delete)
                    => (update, delete) = (Update, Delete);
            }
        }

        internal sealed class CompanyConverter : JsonConverter<Company>
        {
            public override Company? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialCompany>(ref reader, options);
                if(null == partial)
                    return null;
                return new Company(partial);
            }

            public override void Write(Utf8JsonWriter writer, Company value, JsonSerializerOptions options)
                => throw new InvalidOperationException($"Cannot serialize {nameof(Company)}; instead use {nameof(CompanyProperty)}.");
        }
    }
}
