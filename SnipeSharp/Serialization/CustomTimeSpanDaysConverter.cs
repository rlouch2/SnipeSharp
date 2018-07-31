using System;
using Newtonsoft.Json;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomTimeSpanDaysConverter : JsonConverter
    {
        public static readonly CustomTimeSpanDaysConverter Instance = new CustomTimeSpanDaysConverter();
        public override bool CanConvert(Type objectType)
            => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var days = serializer.Deserialize<int?>(reader);
            if(days == null)
                return null;
            return new TimeSpan(days.Value, 0, 0, 0);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => serializer.Serialize(writer, (value as TimeSpan?)?.Days);
    }
}