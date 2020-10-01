using System;
using System.IO;
using Newtonsoft.Json;
using SnipeSharp.Serialization;
using SnipeSharp.Serialization.Converters;
using Xunit;

namespace SnipeSharp.Test
{
    public sealed class NullableBooleanConverterTests
    {
        [Theory]
        [InlineData(true, "true")]
        [InlineData(false, "false")]
        [InlineData(null, "null")]
        public void ReadJson(bool? expected, string json)
        {
            var converter = NullableBooleanConverter.Instance;
            using(var stringReader = new StringReader(json))
            using(var jsonReader = new JsonTextReader(stringReader))
            {
                var actual = converter.ReadJson(jsonReader, null, null, false, NewtonsoftJsonSerializer.Deserializer);
                Assert.Equal(expected, actual);
            }
        }

        [Theory]
        [InlineData(true, "true")]
        [InlineData(false, "false")]
        [InlineData(null, "null")]
        public void WriteJson(bool? value, string expected)
        {
            var converter = NullableBooleanConverter.Instance;
            using(var stringWriter = new StringWriter())
            using(var jsonWriter = new JsonTextWriter(stringWriter))
            {
                converter.WriteJson(jsonWriter, value, null);
                Assert.Equal(expected, stringWriter.ToString());
            }
        }
    }
}
