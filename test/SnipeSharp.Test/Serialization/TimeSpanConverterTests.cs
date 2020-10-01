using System;
using System.IO;
using Newtonsoft.Json;
using SnipeSharp.Serialization;
using SnipeSharp.Serialization.Converters;
using Xunit;

namespace SnipeSharp.Test
{
    public sealed class TimeSpanConverterTests
    {
        [Theory]
        [InlineData(0, "0")]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "3")]
        public void ReadJson_NotNull(int days, string json)
        {
            var expected = new TimeSpan(days, 0, 0, 0);
            var converter = TimeSpanConverter.Instance;
            using(var stringReader = new StringReader(json))
            using(var jsonReader = new JsonTextReader(stringReader))
            {
                var actual = converter.ReadJson(jsonReader, null, null, false, NewtonsoftJsonSerializer.Deserializer);
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void ReadJson_Null()
        {
            var converter = TimeSpanConverter.Instance;
            using(var stringReader = new StringReader("null"))
            using(var jsonReader = new JsonTextReader(stringReader))
            {
                var actual = converter.ReadJson(jsonReader, null, null, false, NewtonsoftJsonSerializer.Deserializer);
                Assert.Null(actual);
            }
        }

        [Fact]
        public void WriteJson_WritesNull()
        {
            var converter = TimeSpanConverter.Instance;
            using(var stringWriter = new StringWriter())
            using(var jsonWriter = new JsonTextWriter(stringWriter))
            {
                converter.WriteJson(jsonWriter, null, null);
                Assert.Equal("null", stringWriter.ToString());
            }
        }

        [Theory]
        [InlineData(0, 0, "0")]
        [InlineData(0, 1, "0")]
        [InlineData(1, 0, "1")]
        [InlineData(1, 1, "1")]
        public void WriteJson_WritesInteger(int days, int hours, string expected)
        {
            var converter = TimeSpanConverter.Instance;
            using(var stringWriter = new StringWriter())
            using(var jsonWriter = new JsonTextWriter(stringWriter))
            {
                converter.WriteJson(jsonWriter, new TimeSpan(days, hours, 0, 0), null);
                Assert.Equal(expected, stringWriter.ToString());
            }
        }
    }
}
