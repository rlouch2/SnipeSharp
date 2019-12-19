using System;
using Newtonsoft.Json;
using SnipeSharp.Models;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomCommonModelConverter : JsonConverter<CommonEndPointModel>
    {
        internal static readonly CustomCommonModelConverter Instance = new CustomCommonModelConverter();
        public override CommonEndPointModel ReadJson(JsonReader reader, Type objectType, CommonEndPointModel existingValue, bool hasExistingValue, JsonSerializer serializer)
            => serializer.Deserialize<GenericEndPointModel>(reader);
        public override void WriteJson(JsonWriter writer, CommonEndPointModel value, JsonSerializer serializer)
            => writer.WriteValue(value?.Id);
    }
}
