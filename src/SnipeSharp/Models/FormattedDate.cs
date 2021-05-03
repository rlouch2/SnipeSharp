using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SnipeSharp.Exceptions;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(Serialization.FormattedDateConverter))]
    public sealed class FormattedDate
    {
        public const string FORMAT = "YYYY-MM-dd";

        public DateTime Date { get; }
        public string? Formatted { get; }

        public FormattedDate(DateTime raw): this(raw, null){}
        internal FormattedDate(DateTime date, string? formatted)
        {
            Date = date;
            Formatted = formatted;
        }

        public static implicit operator DateTime(FormattedDate formatted) => formatted.Date;
        public static implicit operator FormattedDate(DateTime raw) => new FormattedDate(raw);

        public override string ToString() => Formatted ?? Date.ToString(FORMAT);
    }

    namespace Serialization
    {
        internal class PartialFormattedDate
        {
            [JsonPropertyName("datetime")]
            public string? Date { get; set; }

            [JsonPropertyName("formatted")]
            public string? Formatted { get; set; }
        }

        internal class FormattedDateConverter : JsonConverter<FormattedDate>
        {
            public override FormattedDate? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialFormattedDate>(ref reader, options);
                if(null == partial)
                    return null;
                if(null == partial.Date)
                    throw new MissingRequiredPropertyException(nameof(FormattedDate.Date), nameof(FormattedDate));
                if(!DateTime.TryParse(partial.Date, out var date))
                    throw new ArgumentException($"DateTime could not be parsed: {partial.Date}");
                return new FormattedDate(date, partial.Formatted);
            }

            public override void Write(Utf8JsonWriter writer, FormattedDate value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}
