using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(Serialization.DepartmentConverter))]
    public sealed class Department : IApiObject<Department>
    {
        public int Id { get; }
        public string Name { get; }
        public Uri? Image { get; }
        public Stub<Company>? Company { get; }
        public StubUser? Manager { get; }
        public Stub<Location>? Location { get; }
        public string UsersCount { get; }
        public FormattedDateTime CreatedAt { get; }
        public FormattedDateTime UpdatedAt { get; }
        public readonly Actions AvailableActions;

        public struct Actions
        {
            public bool Update { get; }
            public bool Delete { get; }

            internal Actions(Serialization.PartialDepartment.Actions partial)
                => (Update, Delete) = partial;
        }

        internal Department(Serialization.PartialDepartment partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Name = partial.Name ?? throw new ArgumentNullException(nameof(Name));
            Image = partial.Image;
            Company = partial.Company;
            Manager = partial.Manager;
            Location = partial.Location;
            UsersCount = partial.UsersCount ?? throw new ArgumentNullException(nameof(UsersCount));
            CreatedAt = partial.CreatedAt ?? throw new ArgumentNullException(nameof(CreatedAt));
            UpdatedAt = partial.UpdatedAt ?? throw new ArgumentNullException(nameof(UpdatedAt));
            AvailableActions = new Actions(partial.AvailableActions);
        }
    }

    namespace Serialization
    {
        internal sealed class DepartmentConverter : JsonConverter<Department>
        {
            public override Department? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialDepartment>(ref reader, options);
                if(null == partial)
                    return null;
                return new Department(partial);
            }

            public override void Write(Utf8JsonWriter writer, Department value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }

        internal sealed class PartialDepartment
        {
            [JsonPropertyName("id")]
            public int? Id { get; set; }

            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonPropertyName("image")]
            public Uri? Image { get; set; }

            [JsonPropertyName("company")]
            public Stub<Company>? Company { get; set; }

            [JsonPropertyName("manager")]
            public StubUser? Manager { get; set; }

            [JsonPropertyName("location")]
            public Stub<Location>? Location { get; set; }

            [JsonPropertyName("users_count")]
            public string? UsersCount { get; set; }

            [JsonPropertyName("created_at")]
            public FormattedDateTime? CreatedAt { get; set; }

            [JsonPropertyName("updated_at")]
            public FormattedDateTime? UpdatedAt { get; set; }

            [JsonPropertyName("available_actions")]
            public Actions AvailableActions { get; set; }

            internal struct Actions
            {
                [JsonPropertyName("update")]
                public bool Update { get; set; }

                [JsonPropertyName("delete")]
                public bool Delete { get; set; }

                internal void Deconstruct(out bool update, out bool delete)
                    => (update, delete) = (Update, Delete);
            }
        }
    }
}
