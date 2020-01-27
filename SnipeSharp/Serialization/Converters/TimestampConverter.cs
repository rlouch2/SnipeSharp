using System;
using Newtonsoft.Json;

namespace SnipeSharp.Serialization.Converters
{
    internal sealed class TimestampConverter : JsonConverter<DateTime?>
    {
        public static readonly TimestampConverter Instance = new TimestampConverter();

        public override DateTime? ReadJson(JsonReader reader, Type objectType, DateTime? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if(serializer.Deserialize<TimestampResponse>(reader) is TimestampResponse response && DateTime.TryParse(response.DateTime, out var datetime))
                return datetime;
            return null;
        }

        public override void WriteJson(JsonWriter writer, DateTime? value, JsonSerializer serializer)
            => throw new NotImplementedException();

        private sealed class TimestampResponse
        {
            [DeserializeAs("datetime")]
            public string DateTime { get; set; }
        }
    }
}
