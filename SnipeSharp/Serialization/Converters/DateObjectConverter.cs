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
            => throw new NotImplementedException();
    }

    internal sealed class DateObjectResponse
    {
        [DeserializeAs("date")]
        public string DateTime { get; set; }

        [DeserializeAs("formatted")]
        public string Formatted { get; set; }
    }
}
