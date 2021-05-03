using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(Serialization.StubAssetConverter))]
    public sealed class StubAsset: IApiObject<Asset>
    {
        public int Id { get; }
        public string? Name { get; }
        public string AssetTag { get; }

        internal StubAsset(Serialization.PartialStubAsset partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Name = partial.Name;
            AssetTag = partial.AssetTag ?? throw new ArgumentNullException(nameof(AssetTag));
        }

        public override string ToString() => Name ?? AssetTag;
    }

    namespace Serialization
    {
        internal sealed class PartialStubAsset
        {
            [JsonPropertyName("id")]
            public int? Id { get; set; }

            [JsonPropertyName("name")]
            public string? Name { get; set; }

            [JsonPropertyName("asset_tag")]
            public string? AssetTag { get; set; }
        }

        internal sealed class StubAssetConverter : JsonConverter<StubAsset>
        {
            public override StubAsset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialStubAsset>(ref reader, options);
                if(null == partial)
                    return null;
                return new StubAsset(partial);
            }

            public override void Write(Utf8JsonWriter writer, StubAsset value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }
    }
}
