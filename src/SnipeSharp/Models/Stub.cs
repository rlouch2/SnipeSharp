using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(Serialization.StubConverterFactory))]
    public sealed class Stub<T>: IApiObject<T>
        where T : class, IApiObject<T>
    {
        public int Id { get; }
        public string Name { get; }

        internal Stub(Serialization.PartialStub partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Name = partial.Name ?? throw new ArgumentNullException(nameof(Name));
        }

        public override string ToString() => $"({Id}) {Name}";
    }

    namespace Serialization
    {
        internal sealed class StubConverterFactory : JsonConverterFactory
        {
            public override bool CanConvert(Type typeToConvert)
                => typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Stub<>);

            public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
                => (JsonConverter?)Activator.CreateInstance(
                    typeof(StubConverter<>).MakeGenericType(typeToConvert.GetGenericArguments()),
                    BindingFlags.Public | BindingFlags.Instance,
                    binder: null, args: Array.Empty<object>(), culture: null);
        }

        internal sealed class PartialStub
        {
            [JsonPropertyName("id")]
            public int? Id { get; set; }

            [JsonPropertyName("name")]
            public string? Name { get; set; }
        }

        internal sealed class StubConverter<T> : JsonConverter<Stub<T>>
            where T : class, IApiObject<T>
        {
            public override Stub<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialStub>(ref reader, options);
                if(null == partial)
                    return null;
                return new Stub<T>(partial);
            }

            public override void Write(Utf8JsonWriter writer, Stub<T> value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }
    }
}
