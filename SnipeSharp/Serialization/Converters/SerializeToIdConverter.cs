using System;
using Newtonsoft.Json;
using SnipeSharp.Models;

namespace SnipeSharp.Serialization.Converters
{
    internal sealed class SerializeToIdConverter : JsonConverter<CommonEndPointModel>
    {
        internal static readonly SerializeToIdConverter Instance = new SerializeToIdConverter();
        public override CommonEndPointModel ReadJson(JsonReader reader, Type objectType, CommonEndPointModel existingValue, bool hasExistingValue, JsonSerializer serializer)
            => throw new NotImplementedException();
        public override void WriteJson(JsonWriter writer, CommonEndPointModel value, JsonSerializer serializer)
        {
            if(null == value)
                writer.WriteNull();
            else
                writer.WriteValue(value.Id);
        }
    }
}
