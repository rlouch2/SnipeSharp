using System;
using System.IO;
using Newtonsoft.Json;
using SnipeSharp.Models;
using SnipeSharp.Serialization;
using Xunit;

namespace SnipeSharp.Tests
{
    public sealed class CustomAssetStatusConverterTests
    {
        [Fact]
        public void ReadJson_IsNotImplemented()
        {
            Assert.Throws<NotImplementedException>(() => new CustomAssetStatusConverter().ReadJson(null, null, null, false, null));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void WriteJson_WritesInt(int value)
        {
            var converter = new CustomAssetStatusConverter();
            using(var stringWriter = new StringWriter())
            using(var jsonWriter = new JsonTextWriter(stringWriter))
            {
                converter.WriteJson(jsonWriter, new AssetStatus { StatusId = value }, null);
                Assert.Equal(value.ToString(), stringWriter.ToString());
            }
        }
    }
}
