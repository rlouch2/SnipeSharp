using System;
using Newtonsoft.Json;

namespace SnipeSharp.Serialization.Converters
{
    internal sealed class DateObjectConverter : JsonConverter<DateTime?>
    {
        public static readonly DateObjectConverter Instance = new DateObjectConverter();

        public override DateTime? ReadJson(JsonReader reader, Type objectType, DateTime? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if(serializer.Deserialize<DateObjectResponse>(reader) is DateObjectResponse response && DateTime.TryParse(response.DateTime, out var datetime))
                return datetime;
            return null;
        }

        public override void WriteJson(JsonWriter writer, DateTime? value, JsonSerializer serializer)
        {
            if(null == value)
                writer.WriteNull();
            else
                serializer.Serialize(writer, new DateObjectResponse(value.Value));
        }
    }

    internal sealed class DateObjectResponse
    {
        [DeserializeAs("datetime")]
        [SerializeAs("datetime")]
        public string DateTime { get; set; }

        [DeserializeAs("formatted")]
        [SerializeAs("formatted")]
        public string Formatted { get; set; }

        public DateObjectResponse()
        {
        }

        public DateObjectResponse(DateTime dateTime)
        {
            DateTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            Formatted = dateTime.ToString("yyyy-MM-dd hh:mm:ss tt");
        }
    }
}
