using System;
using Newtonsoft.Json;
using SnipeSharp.Models;

namespace SnipeSharp.Serialization.Converters
{
    internal sealed class SerializeToStatusIdConverter : JsonConverter<AssetStatus>
    {
        internal static readonly SerializeToStatusIdConverter Instance = new SerializeToStatusIdConverter();

        public override AssetStatus ReadJson(JsonReader reader, Type objectType, AssetStatus existingValue, bool hasExistingValue, JsonSerializer serializer)
            => throw new NotImplementedException();

        public override void WriteJson(JsonWriter writer, AssetStatus value, JsonSerializer serializer)
            => writer.WriteValue(value.StatusId);
    }
}
