using System;
using Newtonsoft.Json;
using SnipeSharp.Models;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomCommonModelArrayConverter : JsonConverter
    {
        internal static readonly CustomCommonModelArrayConverter Instance = new CustomCommonModelArrayConverter();
        public override bool CanConvert(Type objectType)
            => true;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            => (CommonEndPointModel[]) serializer.Deserialize<GenericEndPointModel[]>(reader);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var items = value as CommonEndPointModel[];
            writer.WriteStartArray();
            if(!(items is null))
                foreach(var item in items)
                    writer.WriteValue(item.Id);
            writer.WriteEndArray();
        }
    }
}
