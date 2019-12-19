using System;
using Newtonsoft.Json;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomTimeSpanConverter : JsonConverter<TimeSpan?>
    {
        public static readonly CustomTimeSpanConverter Instance = new CustomTimeSpanConverter();

        public override TimeSpan? ReadJson(JsonReader reader, Type objectType, TimeSpan? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var days = serializer.Deserialize<int?>(reader);
            if(null == days)
                return null;
            return new TimeSpan(days.Value, 0, 0, 0);
        }

        public override void WriteJson(JsonWriter writer, TimeSpan? value, JsonSerializer serializer)
            => serializer.Serialize(writer, value?.Days);
    }
}
