using Newtonsoft.Json;
using System;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomMonthsConverter : JsonConverter<int?>
    {
        public static readonly CustomMonthsConverter Instance = new CustomMonthsConverter();

        public override int? ReadJson(JsonReader reader, Type objectType, int? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            int readInt;
            var asString = serializer.Deserialize<string>(reader)?.Replace(" months", "");
            if(null != asString && int.TryParse(asString, out readInt))
                return readInt;
            return null;
        }

        public override void WriteJson(JsonWriter writer, int? value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}
