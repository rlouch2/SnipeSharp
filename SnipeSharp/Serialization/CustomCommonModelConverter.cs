using System;
using Newtonsoft.Json;
using SnipeSharp.EndPoint.Models;

namespace SnipeSharp.Serialization
{
    internal sealed class CommonModelConverter : JsonConverter
    {
        internal static readonly CommonModelConverter Instance = new CommonModelConverter();
        public override bool CanConvert(Type objectType)
            => true;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            => throw new NotImplementedException();

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var item = value as CommonEndPointModel;
            writer.WriteValue(item.Id);
        }
    }
}