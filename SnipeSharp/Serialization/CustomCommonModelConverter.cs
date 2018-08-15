using System;
using Newtonsoft.Json;
using SnipeSharp.Models;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomCommonModelConverter : JsonConverter
    {
        internal static readonly CustomCommonModelConverter Instance = new CustomCommonModelConverter();
        public override bool CanConvert(Type objectType)
            => true;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            => (CommonEndPointModel) serializer.Deserialize<GenericEndPointModel>(reader);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var item = value as CommonEndPointModel;
            writer.WriteValue(item?.Id);
        }
    }
}
