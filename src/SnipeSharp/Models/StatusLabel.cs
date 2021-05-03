using System;
using System.Drawing;
using System.Text.Json.Serialization;

namespace SnipeSharp.Models
{
    public sealed class StatusLabel: IApiObject<StatusLabel>
    {
        public int Id { get; }
        public string Name { get; }
        public StatusLabelType Type { get; }
        public Color? Color { get; }
        public bool IsShownInNav { get; }
        public bool IsDefaultLabel { get; }
        public int AssetsCount { get; }
        public string Notes { get; }
        public FormattedDateTime CreatedAt { get; }
        public FormattedDateTime UpdatedAt { get; }
        public readonly Actions AvailableActions;

        public struct Actions
        {
            public bool Update { get; }
            public bool Delete { get; }

            internal Actions(Serialization.PartialStatusLabel.Actions partial)
            {
                Update = partial.Update;
                Delete = partial.Delete;
            }
        }

        internal StatusLabel(Serialization.PartialStatusLabel partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Name = partial.Name ?? throw new ArgumentException(nameof(Name));
            Type = partial.Type ?? throw new ArgumentException(nameof(Type));
            Color = partial.Color;
            IsShownInNav = partial.IsShownInNav;
            IsDefaultLabel = partial.IsDefaultLabel;
            AssetsCount = partial.AssetsCount;
            Notes = partial.Notes ?? string.Empty;
            CreatedAt = partial.CreatedAt ?? throw new ArgumentException(nameof(CreatedAt));
            UpdatedAt = partial.UpdatedAt ?? throw new ArgumentException(nameof(UpdatedAt));
            AvailableActions = new Actions(partial.AvailableActions);
        }
    }

    namespace Serialization
    {
        internal sealed class PartialStatusLabel
        {
            [JsonPropertyName(Static.ID)]
            public int? Id { get; set; }

            [JsonPropertyName(Static.NAME)]
            public string? Name { get; }

            [JsonPropertyName(Static.TYPE)]
            public StatusLabelType? Type { get; }

            [JsonPropertyName(Static.StatusLabel.COLOR)]
            public Color? Color { get; }

            [JsonPropertyName(Static.StatusLabel.SHOW_IN_NAV)]
            public bool IsShownInNav { get; }

            [JsonPropertyName(Static.StatusLabel.DEFAULT_LABEL)]
            public bool IsDefaultLabel { get; }

            [JsonPropertyName(Static.Count.ASSETS)]
            public int AssetsCount { get; }

            [JsonPropertyName(Static.NOTES)]
            public string? Notes { get; }

            [JsonPropertyName(Static.CREATED_AT)]
            public FormattedDateTime? CreatedAt { get; }

            [JsonPropertyName(Static.UPDATED_AT)]
            public FormattedDateTime? UpdatedAt { get; }

            [JsonPropertyName(Static.AVAILABLE_ACTIONS)]
            public Actions AvailableActions { get; set; }

            internal struct Actions
            {
                [JsonPropertyName(Static.Actions.UPDATE)]
                public bool Update { get; set; }

                [JsonPropertyName(Static.Actions.DELETE)]
                public bool Delete { get; set; }
            }
        }
    }
}
