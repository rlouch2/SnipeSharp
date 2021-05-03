using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(Serialization.DepreciationConverter))]
    public sealed class Depreciation : IApiObject<Depreciation>
    {
        public int Id { get; }
        public string Name { get; }
        public int Months { get; }
        public FormattedDateTime CreatedAt { get; }
        public FormattedDateTime UpdatedAt { get; }
        public readonly Actions AvailableActions;

        public struct Actions
        {
            public bool Update { get; }
            public bool Delete { get; }

            internal Actions(Serialization.PartialDepreciation.Actions partial)
                => (Update, Delete) = partial;
        }

        private const NumberStyles MONTHS_STYLE = NumberStyles.Integer;
        private static Regex MONTHS_FORMAT = new Regex(@"^\d+");
        internal Depreciation(Serialization.PartialDepreciation partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Name = partial.Name ?? throw new ArgumentNullException(nameof(Name));
            CreatedAt = partial.CreatedAt ?? throw new ArgumentNullException(nameof(CreatedAt));
            UpdatedAt = partial.UpdatedAt ?? throw new ArgumentNullException(nameof(UpdatedAt));
            AvailableActions = new Actions(partial.AvailableActions);

            var monthString = partial.Months ?? throw new ArgumentNullException(nameof(Months));
            var match = MONTHS_FORMAT.Match(monthString);
            if(!match.Success)
                throw new ArgumentException($@"Month string does not contain leading integer: ""{monthString}""", paramName: nameof(Months));
            if(int.TryParse(match.Value, MONTHS_STYLE, CultureInfo.InvariantCulture.NumberFormat, out int months))
                Months = months;
            else
                throw new ArgumentException($@"Month string could not be parsed to an integer: ""{match.Value}""", paramName: nameof(Months));
        }
    }

    public enum DepreciationSortOn
    {
        CreatedAt = 0,
        Id,
        Name
    }

    internal static class DepreciationSortOnExtensions
    {
        internal static string? Serialize(this DepreciationSortOn value)
            => value switch
            {
                DepreciationSortOn.CreatedAt => Static.CREATED_AT,
                DepreciationSortOn.Id => Static.ID,
                DepreciationSortOn.Name => Static.NAME,
                _ => null,
            };
    }

    public sealed class DepreciationFilter: IFilter<Depreciation>
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string? SearchString { get; set; }
        public SortOrder? SortOrder { get; set; }
        public DepreciationSortOn? SortOn { get; set; }

        IFilter<Depreciation> IFilter<Depreciation>.Clone()
            => new DepreciationFilter
            {
                Limit = Limit,
                Offset = Offset,
                SearchString = SearchString,
                SortOrder = SortOrder,
                SortOn = SortOn,
            };

        IReadOnlyDictionary<string, string?> IFilter<Depreciation>.GetParameters()
            => new Dictionary<string, string?>()
                .AddIfNotNull(Static.LIMIT, Limit?.ToString())
                .AddIfNotNull(Static.OFFSET, Offset?.ToString())
                .AddIfNotNull(Static.SEARCH, SearchString)
                .AddIfNotNull(Static.ORDER, SortOrder.Serialize())
                .AddIfNotNull(Static.SORT_COLUMN, SortOn?.Serialize());
    }

    public sealed class DepreciationProperty: IPutable<Depreciation>, IPostable<Depreciation>
    {
        [JsonPropertyName(Static.NAME)]
        public string Name
        {
            get => _name;
            set => _name = !string.IsNullOrEmpty(value) ? value : throw new ArgumentException(Static.Error.VALUE_EMPTY);
        }
        private string _name = string.Empty;

        [JsonPropertyName(Static.Depreciation.MONTHS)]
        public int Months { get; set; }

        public DepreciationProperty(string name)
            => Name = name;
        public DepreciationProperty(string name, int months): this(name)
            => Months = months;

        public static explicit operator DepreciationProperty(Depreciation depreciation)
            => new DepreciationProperty(depreciation.Name, depreciation.Months);

        public static explicit operator DepreciationProperty(DepreciationPatch patch)
            => new DepreciationProperty(
                name: patch.Name ?? throw new ArgumentNullException(nameof(Name)),
                months: patch.Months ?? throw new ArgumentNullException(nameof(Months))
            );
    }

    public sealed class DepreciationPatch : IPatchable<Depreciation>
    {
        public string? Name { get; set; }
        public int? Months { get; set; }

        IToPatch<Depreciation> IPatchable<Depreciation>.GetPatchable(Depreciation main)
            => new DepreciationToPatch
            {
                Name = main.Name,
                Months = main.Months
            };

        public static implicit operator DepreciationPatch(DepreciationProperty property)
            => new DepreciationPatch
            {
                Name = property.Name,
                Months = property.Months,
            };
    }

    internal sealed class DepreciationToPatch: IToPatch<Depreciation>
    {
        [JsonPropertyName(Static.NAME)]
        public string? Name { get; set; }

        [JsonPropertyName(Static.Depreciation.MONTHS)]
        public int? Months { get; set; }
    }

    namespace Serialization
    {
        internal sealed class DepreciationConverter : JsonConverter<Depreciation>
        {
            public override Depreciation? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialDepreciation>(ref reader, options);
                if(null == partial)
                    return null;
                return new Depreciation(partial);
            }

            public override void Write(Utf8JsonWriter writer, Depreciation value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }

        internal sealed class PartialDepreciation
        {
            [JsonPropertyName(Static.ID)]
            public int? Id { get; set; }

            [JsonPropertyName(Static.NAME)]
            public string? Name { get; set; }

            [JsonPropertyName(Static.Depreciation.MONTHS)]
            public string? Months { get; set; }

            [JsonPropertyName(Static.CREATED_AT)]
            public FormattedDateTime? CreatedAt { get; set; }

            [JsonPropertyName(Static.UPDATED_AT)]
            public FormattedDateTime? UpdatedAt { get; set; }

            [JsonPropertyName(Static.AVAILABLE_ACTIONS)]
            public Actions AvailableActions { get; set; }

            internal struct Actions
            {
                [JsonPropertyName(Static.Actions.UPDATE)]
                public bool Update { get; set; }

                [JsonPropertyName(Static.Actions.DELETE)]
                public bool Delete { get; set; }

                internal void Deconstruct(out bool update, out bool delete)
                    => (update, delete) = (Update, Delete);
            }
        }
    }
}
