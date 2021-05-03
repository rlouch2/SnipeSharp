using System;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(Serialization.AssetRequestConverter))]
    public sealed class AssetRequest
    {
        public string Name { get; }
        public RequestableType Type { get; }
        public int Quantity { get; }
        public Uri? Image { get; }
        public string? LocationName { get; }
        public FormattedDateTime? ExpectedCheckin { get; }
        public FormattedDateTime RequestDate { get; }

        internal AssetRequest(Serialization.PartialAssetRequest partial)
        {
            Name = partial.Name ?? throw new ArgumentNullException(nameof(Name));
            Type = partial.Type ?? throw new ArgumentNullException(nameof(Type));
            Image = partial.Image;
            LocationName = partial.LocationName;
            ExpectedCheckin = partial.ExpectedCheckin;
            RequestDate = partial.RequestDate ?? throw new ArgumentNullException(nameof(RequestDate));
        }
    }


    [JsonConverter(typeof(EnumJsonConverter<RequestableType>))]
    public enum RequestableType
    {
        [EnumMember(Value = Static.Types.ASSET)]
        Asset
        // TODO
    }

    namespace Serialization
    {
        internal sealed class AssetRequestConverter : JsonConverter<AssetRequest>
        {
            public override AssetRequest? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialAssetRequest>(ref reader, options);
                if(null == partial)
                    return null;
                return new AssetRequest(partial);
            }

            public override void Write(Utf8JsonWriter writer, AssetRequest value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }

        internal sealed class PartialAssetRequest
        {
            [JsonPropertyName(Static.NAME)]
            public string? Name { get; set; }

            [JsonPropertyName(Static.TYPE)]
            public RequestableType? Type { get; }

            [JsonPropertyName(Static.QUANTITY)]
            public int Quantity { get; }

            [JsonPropertyName(Static.IMAGE)]
            public Uri? Image { get; }

            [JsonPropertyName(Static.Types.LOCATION)]
            public string? LocationName { get; }

            [JsonPropertyName(Static.EXPECTED_CHECKIN)]
            public FormattedDateTime? ExpectedCheckin { get; }

            [JsonPropertyName(Static.Request.REQUEST_DATE)]
            public FormattedDateTime? RequestDate { get; }
        }
    }
}
