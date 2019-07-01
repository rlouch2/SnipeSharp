using System;
using Newtonsoft.Json;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomBoolStringConverter : JsonConverter
    {
        internal static readonly CustomBoolStringConverter Instance = new CustomBoolStringConverter();
        public override bool CanConvert(Type objectType)
            => true;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            => throw new NotImplementedException();

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var boolValue = (bool) value;
            writer.WriteValue(boolValue);
        }
    }
}
