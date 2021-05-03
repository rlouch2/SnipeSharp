using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(Serialization.AssetStatusConverter))]
    public sealed class AssetStatus: IApiObject<StatusLabel>
    {
        public int Id { get; }
        public string Name { get; }
        public StatusLabelType Type { get; }
        public StatusMeta MetaStatus { get; }

        internal AssetStatus(Serialization.PartialAssetStatus partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Name = partial.Name ?? throw new ArgumentNullException(nameof(Name));
            Type = partial.Type ?? throw new ArgumentNullException(nameof(Type));
            MetaStatus = partial.MetaStatus ?? throw new ArgumentNullException(nameof(MetaStatus));
        }
    }

    namespace Serialization
    {
        internal sealed class AssetStatusConverter : JsonConverter<AssetStatus>
        {
            public override AssetStatus? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialAssetStatus>(ref reader, options);
                if(null == partial)
                    return null;
                return new AssetStatus(partial);
            }

            public override void Write(Utf8JsonWriter writer, AssetStatus value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }

        internal sealed class PartialAssetStatus
        {
            [JsonPropertyName(Static.ID)]
            public int? Id { get; set; }

            [JsonPropertyName(Static.NAME)]
            public string? Name { get; set; }

            [JsonPropertyName(Static.Asset.STATUS_TYPE)]
            public StatusLabelType? Type { get; set; }

            [JsonPropertyName(Static.Asset.STATUS_META)]
            public StatusMeta? MetaStatus { get; set; }
        }
    }
}