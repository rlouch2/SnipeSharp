using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(Serialization.GroupConverter))]
    public sealed class Group: IApiObject<Group>
    {
        public int Id { get; }
        public string Name { get; }
        public int UsersCount { get; }
        public FormattedDateTime CreatedAt { get; }
        public FormattedDateTime UpdatedAt { get; }
        public PermissionSet Permissions { get; }
        public readonly Actions AvailableActions;

        public struct Actions
        {
            public bool Update { get; }
            public bool Delete { get; }

            internal Actions(Serialization.PartialGroup.Actions partial)
                => (Update, Delete) = partial;
        }

        internal Group(Serialization.PartialGroup partial)
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

    namespace Serialization
    {
        internal sealed class GroupConverter : JsonConverter<Group>
        {
            public override Group? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialGroup>(ref reader, options);
                if(null == partial)
                    return null;
                return new Group(partial);
            }

            public override void Write(Utf8JsonWriter writer, Group value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }

        internal sealed class PartialGroup
        {
            [JsonPropertyName(Static.ID)]
            public int? Id { get; set; }

            [JsonPropertyName(Static.NAME)]
            public string? Name { get; set; }

            [JsonPropertyName(Static.Count.USERS)]
            public int UsersCount { get; set; }

            [JsonPropertyName(Static.CREATED_AT)]
            public FormattedDateTime? CreatedAt { get; set; }

            [JsonPropertyName(Static.UPDATED_AT)]
            public FormattedDateTime? UpdatedAt { get; set; }

            [JsonPropertyName(Static.PERMISSIONS)]
            public PermissionSet? Permissions { get; set; }

            [JsonPropertyName(Static.AVAILABLE_ACTIONS)]
            public Actions AvailableActions { get; set; }

            internal struct Actions
            {
                [JsonPropertyName(Static.Actions.UPDATE)]
                public bool Update { get; set; }

                [JsonPropertyName(Static.Actions.DELETE)]
                public bool Delete { get; set; }

                public void Deconstruct(out bool update, out bool delete)
                    => (update, delete) = (Update, Delete);
            }
        }
    }
}
