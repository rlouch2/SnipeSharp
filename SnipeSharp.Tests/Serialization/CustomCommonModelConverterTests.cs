using System;
using System.IO;
using Newtonsoft.Json;
using SnipeSharp.Models;
using SnipeSharp.Serialization;
using Xunit;

namespace SnipeSharp.Tests
{
    public sealed class CustomCommonModelConverterTests
    {
        [Fact]
        public void ReadJson_IsNotImplemented()
        {
            Assert.Throws<NotImplementedException>(() => new CustomCommonModelConverter().ReadJson(null, null, null, false, null));
        }

        [Fact]
        public void WriteJson_WritesNull()
        {
            var converter = new CustomCommonModelConverter();
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
            var converter = new CustomCommonModelConverter();
            using(var stringWriter = new StringWriter())
            using(var jsonWriter = new JsonTextWriter(stringWriter))
            {
                converter.WriteJson(jsonWriter, new GenericEndPointModel { Id = value }, null);
                Assert.Equal(value.ToString(), stringWriter.ToString());
            }
        }
    }
}
