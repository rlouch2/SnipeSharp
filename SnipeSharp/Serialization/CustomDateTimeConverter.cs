using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomDateTimeConverter : JsonConverter<DateTime?>
    {
        public static readonly CustomDateTimeConverter Instance = new CustomDateTimeConverter();

        public override DateTime? ReadJson(JsonReader reader, Type objectType, DateTime? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if(reader.TokenType == JsonToken.Null)
                return null;
            if(reader.TokenType == JsonToken.String)
            {
                var str = serializer.Deserialize<string>(reader);
                if(!string.IsNullOrWhiteSpace(str) && DateTime.TryParse(str, out var datetime))
                    return datetime;
            } else if(reader.TokenType == JsonToken.StartObject)
            {
                var dict = serializer.Deserialize<Dictionary<string, string>>(reader);
                if(null == dict)
                    return null;
                if(dict.TryGetValue("datetime", out var str) && DateTime.TryParse(str, out var datetime))
                    return datetime;
                if(dict.TryGetValue("date", out var dateStr) && DateTime.TryParse(dateStr, out var date))
                    return date;
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, DateTime? value, JsonSerializer serializer)
            => serializer.Serialize(writer, null == value ? null : new DateTimeResponse(value.Value));
    }

    internal sealed class DateTimeResponse
    {
        [DeserializeAs("datetime")]
        [SerializeAs("datetime")]
        public string DateTime { get; set; }

        [DeserializeAs("formatted")]
        [SerializeAs("formatted")]
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
