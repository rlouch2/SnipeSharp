using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(DepreciationConverter))]
    [GeneratePartial, GenerateConverter]
    public sealed partial class Depreciation : IApiObject<Depreciation>
    {
        [DeserializeAs(Static.ID)]
        public int Id { get; }

        [DeserializeAs(Static.NAME)]
        public string Name { get; }

        [DeserializeAs(Static.Depreciation.MONTHS, Type = typeof(string))]
        public int Months { get; }

        [DeserializeAs(Static.CREATED_AT)]
        public FormattedDateTime CreatedAt { get; }

        [DeserializeAs(Static.UPDATED_AT)]
        public FormattedDateTime UpdatedAt { get; }

        [DeserializeAs(Static.AVAILABLE_ACTIONS, Type = typeof(PartialDepreciation.Actions), IsNonNullable = true)]
        public readonly Actions AvailableActions;

        [GeneratePartialActions]
        public partial struct Actions
        {
            public bool Update { get; }
            public bool Delete { get; }
        }

        private const NumberStyles MONTHS_STYLE = NumberStyles.Integer;
        private static Regex MONTHS_FORMAT = new Regex(@"^\d+");
        internal Depreciation(PartialDepreciation partial)
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

    [GenerateFilter(typeof(DepreciationSortOn))]
    public sealed partial class DepreciationFilter: IFilter<Depreciation>
    {
    }

    [SortColumn]
    public enum DepreciationSortOn
    {
        [EnumMember(Value = Static.CREATED_AT)]
        CreatedAt = 0,

        [EnumMember(Value = Static.ID)]
        Id,

        [EnumMember(Value = Static.NAME)]
        Name
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
}
