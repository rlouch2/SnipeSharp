using System;
using Newtonsoft.Json;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomDateTimeConverter : JsonConverter
    {
        public static readonly CustomDateTimeConverter Instance = new CustomDateTimeConverter();
        public override bool CanConvert(Type objectType)
            => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            DateTime dateTime;
            var @object = serializer.Deserialize<DateTimeResponse>(reader);
            if(@object != null && !string.IsNullOrWhiteSpace(@object.DateTime) && DateTime.TryParse(@object.DateTime, out dateTime))
                return dateTime;
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => serializer.Serialize(writer, value == null ? null : new DateTimeResponse((value as DateTime?).Value));
    }

    internal sealed class DateTimeResponse
    {
        [Field("datetime")]
        public string DateTime { get; set; }

        [Field("formatted")]
        public string Formatted { get; set; }

        public DateTimeResponse()
        {
        }

        public DateTimeResponse(DateTime dateTime)
        {
            DateTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            Formatted = dateTime.ToString("yyyy-MM-dd hh:mm:ss tt");
        }
    }
}