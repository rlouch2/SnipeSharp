using System;
using Newtonsoft.Json;
using SnipeSharp.Models;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomCommonModelArrayConverter : JsonConverter<CommonEndPointModel[]>
    {
        internal static readonly CustomCommonModelArrayConverter Instance = new CustomCommonModelArrayConverter();
        public override CommonEndPointModel[] ReadJson(JsonReader reader, Type objectType, CommonEndPointModel[] existingValue, bool hasExistingValue, JsonSerializer serializer)
            => (CommonEndPointModel[]) serializer.Deserialize<GenericEndPointModel[]>(reader);

        public override void WriteJson(JsonWriter writer, CommonEndPointModel[] value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            if(null != value)
                foreach(var item in value)
                    writer.WriteValue(item.Id);
            writer.WriteEndArray();
        }
    }
}
