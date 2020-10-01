using System;
using System.IO;
using Newtonsoft.Json;
using SnipeSharp.Serialization;
using SnipeSharp.Serialization.Converters;
using Xunit;

namespace SnipeSharp.Test
{
    public sealed class MonthStringToIntConverterTests
    {
        [Theory]
        [InlineData(0, "\"0 Months\"")]
        [InlineData(1, "\"1 Month\"")]
        [InlineData(2, "\"2 months\"")]
        [InlineData(12, "\"12 meses\"")]
        [InlineData(24, "\"24 maanden\"")]
        [InlineData(36, "\"36 月\"")]
        [InlineData(null, "null")]
        [InlineData(null, "\"\"")]
        [InlineData(null, "\"not a number\"")]
        public void ReadJson(int? expected, string json)
        {
            var converter = MonthStringToIntConverter.Instance;
            using(var stringReader = new StringReader(json))
            using(var jsonReader = new JsonTextReader(stringReader))
            {
                var actual = converter.ReadJson(jsonReader, null, null, false, NewtonsoftJsonSerializer.Deserializer);
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void WriteJson_IsNotImplemented()
        {
            Assert.Throws<NotImplementedException>(() => MonthStringToIntConverter.Instance.WriteJson(null, null, null));
        }
    }
}
