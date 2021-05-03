using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SnipeSharp.Exceptions;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(Serialization.FormattedDateTimeConverter))]
    public sealed class FormattedDateTime
    {
        public const string FORMAT = "YYYY-MM-dd HH:mm:ss";

        public DateTime DateTime { get; }
        public string? Formatted { get; }

        public FormattedDateTime(DateTime raw): this(raw, null){}
        internal FormattedDateTime(DateTime date, string? formatted)
        {
            DateTime = date;
            Formatted = formatted;
        }

        public static implicit operator DateTime(FormattedDateTime formatted) => formatted.DateTime;
        public static implicit operator FormattedDateTime(DateTime raw) => new FormattedDateTime(raw);

        public override string ToString() => Formatted ?? DateTime.ToString(FORMAT);
    }

    namespace Serialization
    {
        internal class PartialFormattedDateTime
        {
            [JsonPropertyName("datetime")]
            public string? DateTime { get; set; }

            [JsonPropertyName("formatted")]
            public string? Formatted { get; set; }
        }

        internal class FormattedDateTimeConverter : JsonConverter<FormattedDateTime>
        {
            public override FormattedDateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialFormattedDateTime>(ref reader, options);
                if(null == partial)
                    return null;
                if(null == partial.DateTime)
                    throw new MissingRequiredPropertyException(nameof(FormattedDateTime.DateTime), nameof(FormattedDateTime));
                if(!DateTime.TryParse(partial.DateTime, out var datetime))
                    throw new ArgumentException($"DateTime could not be parsed: {partial.DateTime}");
                return new FormattedDateTime(datetime, partial.Formatted);
            }

            public override void Write(Utf8JsonWriter writer, FormattedDateTime value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}
