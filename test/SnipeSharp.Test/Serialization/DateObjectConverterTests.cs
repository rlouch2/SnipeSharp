using System;
using System.IO;
using Newtonsoft.Json;
using SnipeSharp.Serialization;
using SnipeSharp.Serialization.Converters;
using Xunit;

namespace SnipeSharp.Test
{
    public sealed class DateObjectConverterTests
    {
        [Theory]
        [InlineData(2020, 1, 1, "{\"date\": \"2020-01-01\"}")]
        [InlineData(1970, 12, 31, "{\"date\": \"1970-12-31\"}")]
        [InlineData(2015, 6, 6, "{\"date\": \"2015-06-06\"}")]
        public void ReadJson_NotNull(int year, int month, int day, string json)
        {
            var expected = new DateTime(year, month, day);
            var converter = DateObjectConverter.Instance;
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
            var converter = DateObjectConverter.Instance;
            using(var stringReader = new StringReader("null"))
            using(var jsonReader = new JsonTextReader(stringReader))
            {
                var actual = converter.ReadJson(jsonReader, null, null, false, NewtonsoftJsonSerializer.Deserializer);
                Assert.Null(actual);
            }
        }

        [Fact]
        public void WriteJson_IsNotImplemented()
        {
            Assert.Throws<NotImplementedException>(() => DateObjectConverter.Instance.WriteJson(null, null, null));
        }
    }
}
