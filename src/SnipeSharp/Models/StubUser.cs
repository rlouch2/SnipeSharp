using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(Serialization.StubUserConverter))]
    public sealed class StubUser: IApiObject<User>
    {
        public int Id { get; }
        public string Name { get; }

        public string FirstName { get; }
        public string LastName { get; }

        internal StubUser(Serialization.PartialStubUser partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Name = partial.Name ?? throw new ArgumentNullException(nameof(Name));
            FirstName = partial.FirstName ?? throw new ArgumentNullException(nameof(FirstName));
            LastName = partial.LastName ?? throw new ArgumentNullException(nameof(LastName));
        }

        public override string ToString() => Name;
    }

    namespace Serialization
    {
        internal sealed class PartialStubUser
        {
            [JsonPropertyName("id")]
            public int? Id { get; set; }

            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonPropertyName("first_name")]
            public string? FirstName { get; set; }

            [JsonPropertyName("last_name")]
            public string? LastName { get; set; }
        }

        internal sealed class StubUserConverter : JsonConverter<StubUser>
        {
            public override StubUser? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialStubUser>(ref reader, options);
                if(null == partial)
                    return null;
                return new StubUser(partial);
            }

            public override void Write(Utf8JsonWriter writer, StubUser value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }
    }
}
