using System;
using System.IO;
using Newtonsoft.Json;
using SnipeSharp.Serialization;
using SnipeSharp.Serialization.Converters;
using Xunit;

namespace SnipeSharp.Test
{
    public sealed class SimpleDateConverterTests
    {
        [Theory]
        [InlineData(637157139670000000L, "\"2020-01-27 09:26:07\"")]
        [InlineData(811784444090000000L, "\"2573-06-11 07:53:29\"")]
        [InlineData(205373411500000000L, "\"0651-10-21 16:59:10\"")]
        [InlineData(1756532393440000000L, "\"5567-03-26 14:29:04\"")]
        [InlineData(1273812174050000000L, "\"4037-07-20 15:30:05\"")]
        [InlineData(1202562106240000000L, "\"3811-10-09 06:57:04\"")]
        [InlineData(2987276785760000000L, "\"9467-04-22 06:42:56\"")]
        [InlineData(1676486813150000000L, "\"5313-07-30 06:08:35\"")]
        [InlineData(647824249660000000L, "\"2053-11-15 14:02:46\"")]
        [InlineData(789374042580000000L, "\"2502-06-06 08:44:18\"")]
        [InlineData(2989437163520000000L, "\"9474-02-24 17:12:32\"")]
        [InlineData(2807032630650000000L, "\"8896-02-18 08:37:45\"")]
        [InlineData(2736181334650000000L, "\"8671-08-13 13:04:25\"")]
        [InlineData(2879107718280000000L, "\"9124-07-13 14:23:48\"")]
        [InlineData(1691728080620000000L, "\"5361-11-15 14:41:02\"")]
        public void ReadJson_NotNull(long ticks, string json)
        {
            var expected = new DateTime(ticks);
            var converter = SimpleDateConverter.Instance;
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
            var converter = SimpleDateConverter.Instance;
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
            var converter = SimpleDateConverter.Instance;
            using(var stringWriter = new StringWriter())
            using(var jsonWriter = new JsonTextWriter(stringWriter))
            {
                converter.WriteJson(jsonWriter, null, null);
                Assert.Equal("null", stringWriter.ToString());
            }
        }

        [Theory]
        [InlineData(637157139670000000L, "\"2020-01-27 09:26:07\"")]
        [InlineData(811784444090000000L, "\"2573-06-11 07:53:29\"")]
        [InlineData(205373411500000000L, "\"0651-10-21 16:59:10\"")]
        [InlineData(1756532393440000000L, "\"5567-03-26 14:29:04\"")]
        [InlineData(1273812174050000000L, "\"4037-07-20 15:30:05\"")]
        [InlineData(1202562106240000000L, "\"3811-10-09 06:57:04\"")]
        [InlineData(2987276785760000000L, "\"9467-04-22 06:42:56\"")]
        [InlineData(1676486813150000000L, "\"5313-07-30 06:08:35\"")]
        [InlineData(647824249660000000L, "\"2053-11-15 14:02:46\"")]
        [InlineData(789374042580000000L, "\"2502-06-06 08:44:18\"")]
        [InlineData(2989437163520000000L, "\"9474-02-24 17:12:32\"")]
        [InlineData(2807032630650000000L, "\"8896-02-18 08:37:45\"")]
        [InlineData(2736181334650000000L, "\"8671-08-13 13:04:25\"")]
        [InlineData(2879107718280000000L, "\"9124-07-13 14:23:48\"")]
        [InlineData(1691728080620000000L, "\"5361-11-15 14:41:02\"")]
        public void WriteJson_WritesTimestamp(long ticks, string expected)
        {
            var converter = SimpleDateConverter.Instance;
            using(var stringWriter = new StringWriter())
            using(var jsonWriter = new JsonTextWriter(stringWriter))
            {
                converter.WriteJson(jsonWriter, new DateTime(ticks), null);
                Assert.Equal(expected, stringWriter.ToString());
            }
        }
    }
}
