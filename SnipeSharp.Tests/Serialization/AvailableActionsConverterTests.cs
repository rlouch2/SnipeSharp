using System;
using SnipeSharp.Serialization.Converters;
using SnipeSharp.Models.Enumerations;
using Xunit;
using static SnipeSharp.Models.Enumerations.AvailableAction;
using System.IO;
using Newtonsoft.Json;
using SnipeSharp.Serialization;

namespace SnipeSharp.Tests
{
    public sealed class CustomAvailableActionsConverterTests
    {

        [Fact]
        public void WriteJson_IsNotImplemented()
        {
            Assert.Throws<NotImplementedException>(() => AvailableActionsConverter.Instance.WriteJson(null, None, null));
        }

        [Theory]
        [InlineData(None, "null")]
        [InlineData(None, "{}")]
        [InlineData(None, "{\"checkout\":false,\"checkin\":false,\"clone\":false,\"delete\":false,\"restore\":false,\"update\":false}")]
        [InlineData(CheckOut, "{\"checkout\":true,\"checkin\":false,\"clone\":false,\"delete\":false,\"restore\":false,\"update\":false}")]
        [InlineData(CheckIn, "{\"checkout\":false,\"checkin\":true,\"clone\":false,\"delete\":false,\"restore\":false,\"update\":false}")]
        [InlineData(Clone, "{\"checkout\":false,\"checkin\":false,\"clone\":true,\"delete\":false,\"restore\":false,\"update\":false}")]
        [InlineData(Delete, "{\"checkout\":false,\"checkin\":false,\"clone\":false,\"delete\":true,\"restore\":false,\"update\":false}")]
        [InlineData(Restore, "{\"checkout\":false,\"checkin\":false,\"clone\":false,\"delete\":false,\"restore\":true,\"update\":false}")]
        [InlineData(Update, "{\"checkout\":false,\"checkin\":false,\"clone\":false,\"delete\":false,\"restore\":false,\"update\":true}")]
        [InlineData(Request, "{\"request\":true}")]
        [InlineData(CancelRequest, "{\"cancel\":true}")]
        [InlineData(CheckOut | Update | Delete, "{\"checkout\":true,\"checkin\":false,\"clone\":false,\"delete\":true,\"restore\":false,\"update\":true}")]
        public void ReadJson(AvailableAction expected, string json)
        {
            var converter = AvailableActionsConverter.Instance;
            using(var stringReader = new StringReader(json))
            using(var jsonReader = new JsonTextReader(stringReader))
            {
                Assert.Equal(expected, converter.ReadJson(jsonReader, null, None, false, NewtonsoftJsonSerializer.Deserializer));
            }
        }
    }
}
