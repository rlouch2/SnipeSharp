using Newtonsoft.Json;
using System;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomMonthsConverter : JsonConverter
    {
        public static readonly CustomMonthsConverter Instance = new CustomMonthsConverter();

        public override bool CanConvert(Type objectType)
            => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            int readInt;
            var asString = serializer.Deserialize<string>(reader)?.Replace(" months", "");
            if(!(asString is null) && int.TryParse(asString, out readInt))
                return readInt;
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}
