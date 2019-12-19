using System;
using Newtonsoft.Json;
using SnipeSharp.Models;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomAssetStatusConverter : JsonConverter<AssetStatus>
    {
        internal static readonly CustomAssetStatusConverter Instance = new CustomAssetStatusConverter();

        public override AssetStatus ReadJson(JsonReader reader, Type objectType, AssetStatus existingValue, bool hasExistingValue, JsonSerializer serializer)
            => throw new NotImplementedException();

        public override void WriteJson(JsonWriter writer, AssetStatus value, JsonSerializer serializer)
            => writer.WriteValue(value.StatusId);
    }
}
