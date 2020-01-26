using System;
using Newtonsoft.Json;
using SnipeSharp.Models;

namespace SnipeSharp.Serialization.Converters
{
    internal sealed class SerializeToIdConverter : JsonConverter<IObjectWithId>
    {
        internal static readonly SerializeToIdConverter Instance = new SerializeToIdConverter();
        public override IObjectWithId ReadJson(JsonReader reader, Type objectType, IObjectWithId existingValue, bool hasExistingValue, JsonSerializer serializer)
            => throw new NotImplementedException();
        public override void WriteJson(JsonWriter writer, IObjectWithId value, JsonSerializer serializer)
        {
            if(null == value)
                writer.WriteNull();
            else
                writer.WriteValue(value.Id);
        }
    }
}
