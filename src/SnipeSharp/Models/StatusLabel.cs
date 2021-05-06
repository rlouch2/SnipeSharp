using System;
using System.Drawing;
using System.Text.Json.Serialization;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(StatusLabelConverter))]
    [GeneratePartial, GenerateConverter]
    public sealed partial class StatusLabel: IApiObject<StatusLabel>
    {
        [DeserializeAs(Static.ID)]
        public int Id { get; }

        [DeserializeAs(Static.NAME)]
        public string Name { get; }

        [DeserializeAs(Static.TYPE)]
        public StatusLabelType Type { get; }

        [DeserializeAs(Static.StatusLabel.COLOR)]
        public Color? Color { get; }

        [DeserializeAs(Static.StatusLabel.SHOW_IN_NAV, IsNonNullable = true)]
        public bool IsShownInNav { get; }

        [DeserializeAs(Static.StatusLabel.DEFAULT_LABEL, IsNonNullable = true)]
        public bool IsDefaultLabel { get; }

        [DeserializeAs(Static.Count.ASSETS, IsNonNullable = true)]
        public int AssetsCount { get; }

        [DeserializeAs(Static.Count.ASSETS)]
        public string Notes { get; }

        [DeserializeAs(Static.CREATED_AT)]
        public FormattedDateTime CreatedAt { get; }

        [DeserializeAs(Static.UPDATED_AT)]
        public FormattedDateTime UpdatedAt { get; }

        [DeserializeAs(Static.AVAILABLE_ACTIONS, Type = typeof(PartialStatusLabel.Actions), IsNonNullable = true)]
        public readonly Actions AvailableActions;

        [GeneratePartialActions]
        public partial struct Actions
        {
            public bool Update { get; }
            public bool Delete { get; }
        }

        internal StatusLabel(PartialStatusLabel partial)
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
}
