using System;
using System.IO;
using Newtonsoft.Json;
using SnipeSharp.Models;
using SnipeSharp.Serialization.Converters;
using Xunit;

namespace SnipeSharp.Test
{
    public sealed class SerializeToIdConverterTests
    {
        [Fact]
        public void ReadJson_IsNotImplemented()
        {
            Assert.Throws<NotImplementedException>(() => SerializeToIdConverter.Instance.ReadJson(null, null, null, false, null));
        }

        [Fact]
        public void WriteJson_WritesNull()
        {
            var converter = SerializeToIdConverter.Instance;
            using(var stringWriter = new StringWriter())
            using(var jsonWriter = new JsonTextWriter(stringWriter))
            {
                converter.WriteJson(jsonWriter, null, null);
                Assert.Equal("null", stringWriter.ToString());
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void WriteJson_WritesId(int value)
        {
            var converter = SerializeToIdConverter.Instance;
            using(var stringWriter = new StringWriter())
            using(var jsonWriter = new JsonTextWriter(stringWriter))
            {
                converter.WriteJson(jsonWriter, new GenericEndPointModel { Id = value }, null);
                Assert.Equal(value.ToString(), stringWriter.ToString());
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void WriteJson_WritesStatusId(int value)
        {
            var converter = SerializeToIdConverter.Instance;
            using(var stringWriter = new StringWriter())
            using(var jsonWriter = new JsonTextWriter(stringWriter))
            {
                converter.WriteJson(jsonWriter, new AssetStatus { StatusId = value }, null);
                Assert.Equal(value.ToString(), stringWriter.ToString());
            }
        }
    }
}
