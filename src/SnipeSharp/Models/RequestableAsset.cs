using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(Serialization.RequestableAssetConverter))]
    public sealed class RequestableAsset: IApiObject<RequestableAsset>, IApiObject<Asset>
    {
        public int Id { get; }
        public string Name { get; }
        public string AssetTag { get; }
        public string SerialNumber { get; }
        public Uri? Image { get; }
        public string? ModelName { get; }
        public string? ModelNumber { get; }
        public FormattedDate ExpectedCheckIn { get; }
        public string? LocationName { get; }
        public StatusMeta Status { get; }
        public readonly Actions AvailableActions;

        public struct Actions
        {
            public bool Cancel { get; }
            public bool Request { get; }

            internal Actions(Serialization.PartialRequestableAsset.Actions partial)
                => (Cancel, Request) = partial;
        }

        internal RequestableAsset(Serialization.PartialRequestableAsset partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Name = partial.Name ?? throw new ArgumentNullException(nameof(Name));
            AssetTag = partial.AssetTag ?? throw new ArgumentNullException(nameof(AssetTag));
            SerialNumber = partial.SerialNumber ?? throw new ArgumentNullException(nameof(SerialNumber));
            Image = partial.Image;
            ModelName = partial.ModelName;
            ModelNumber = partial.ModelNumber;
            ExpectedCheckIn = partial.ExpectedCheckIn ?? throw new ArgumentNullException(nameof(ExpectedCheckIn));
            LocationName = partial.LocationName;
            Status = partial.Status ?? throw new ArgumentNullException(nameof(Status));
            AvailableActions = new Actions(partial.AvailableActions);
        }
    }

    namespace Serialization
    {
        internal sealed class RequestableAssetConverter : JsonConverter<RequestableAsset>
        {
            public override RequestableAsset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialRequestableAsset>(ref reader, options);
                if(null == partial)
                    return null;
                return new RequestableAsset(partial);
            }

            public override void Write(Utf8JsonWriter writer, RequestableAsset value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }

        internal sealed class PartialRequestableAsset
        {
            [JsonPropertyName(Static.ID)]
            public int? Id { get; set; }

            [JsonPropertyName(Static.NAME)]
            public string? Name { get; set; }

            [JsonPropertyName(Static.ASSET_TAG)]
            public string? AssetTag { get; set; }

            [JsonPropertyName(Static.SERIAL)]
            public string? SerialNumber { get; set; }

            [JsonPropertyName(Static.IMAGE)]
            public Uri? Image { get; set; }

            [JsonPropertyName(Static.Types.MODEL)]
            public string? ModelName { get; set; }

            [JsonPropertyName(Static.MODEL_NUMBER)]
            public string? ModelNumber { get; set; }

            [JsonPropertyName(Static.EXPECTED_CHECKIN)]
            public FormattedDate? ExpectedCheckIn { get; set; }

            [JsonPropertyName(Static.Types.LOCATION)]
            public string? LocationName { get; set; }

            [JsonPropertyName(Static.STATUS)]
            public StatusMeta? Status { get; set; }

            [JsonPropertyName(Static.AVAILABLE_ACTIONS)]
            public Actions AvailableActions { get; set; }

            public struct Actions
            {
                [JsonPropertyName(Static.Actions.CANCEL)]
                public bool Cancel { get; }

                [JsonPropertyName(Static.Actions.REQUEST)]
                public bool Request { get; }

                internal void Deconstruct(out bool cancel, out bool request)
                    => (cancel, request) = (Cancel, Request);
            }
        }
    }
}
