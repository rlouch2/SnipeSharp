using System;
using System.Text.Json.Serialization;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(GroupConverter))]
    [GeneratePartial, GenerateConverter]
    public sealed partial class Group: IApiObject<Group>
    {
        [DeserializeAs(Static.ID)]
        public int Id { get; }

        [DeserializeAs(Static.NAME)]
        public string Name { get; }

        [DeserializeAs(Static.Count.USERS, IsNonNullable = true)]
        public int UsersCount { get; }

        [DeserializeAs(Static.CREATED_AT)]
        public FormattedDateTime CreatedAt { get; }

        [DeserializeAs(Static.UPDATED_AT)]
        public FormattedDateTime UpdatedAt { get; }

        [DeserializeAs(Static.PERMISSIONS)]
        public PermissionSet Permissions { get; }

        [DeserializeAs(Static.AVAILABLE_ACTIONS, Type = typeof(PartialGroup.Actions), IsNonNullable = true)]
        public readonly Actions AvailableActions;

        [GeneratePartialActions]
        public partial struct Actions
        {
            public bool Update { get; }
            public bool Delete { get; }
        }

        internal Group(PartialGroup partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Name = partial.Name ?? throw new ArgumentNullException(nameof(Name));
            UsersCount = partial.UsersCount;
            CreatedAt = partial.CreatedAt ?? throw new ArgumentNullException(nameof(CreatedAt));
            UpdatedAt = partial.UpdatedAt ?? throw new ArgumentNullException(nameof(UpdatedAt));
            Permissions = partial.Permissions ?? new PermissionSet();
            AvailableActions = new Actions(partial.AvailableActions);
        }
    }
}
