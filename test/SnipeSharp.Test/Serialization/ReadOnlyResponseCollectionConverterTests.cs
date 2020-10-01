using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SnipeSharp.Models;
using SnipeSharp.Serialization;
using SnipeSharp.Serialization.Converters;
using Xunit;

namespace SnipeSharp.Test
{
    public sealed class ReadOnlyResponseCollectionConverterTests
    {
        [Theory]
        [InlineData(typeof(ResponseCollection<GenericEndPointModel>))]
        [InlineData(typeof(ResponseCollection<ApiObject>))]
        [InlineData(typeof(ResponseCollection<Stub<Model>>))]
        [InlineData(typeof(IReadOnlyCollection<Stub<Asset>>))]
        public void CanConvert_ReadOnlyCollections(Type type)
        {
            Assert.True(ReadOnlyResponseCollectionConverter.Instance.CanConvert(type));
        }

        [Theory]
        [InlineData(typeof(string))]
        [InlineData(typeof(ISet<uint>))]
        public void CanConvert_CannotConvertOtherTypes(Type type)
        {
            Assert.False(ReadOnlyResponseCollectionConverter.Instance.CanConvert(type));
        }

        [Fact]
        public void WriteJson_IsNotImplemented()
        {
            Assert.Throws<NotImplementedException>(() => ReadOnlyResponseCollectionConverter.Instance.WriteJson(null, null, null));
        }

        [Fact]
        public void ReadJson_EmptyCollection()
        {
            var converter = ReadOnlyResponseCollectionConverter.Instance;
            using(var stringReader = new StringReader("{\"total\": 0, \"rows\": []}"))
            using(var jsonReader = new JsonTextReader(stringReader))
            {
                var actual = (IReadOnlyCollection<ApiObject>)converter.ReadJson(jsonReader, typeof(IReadOnlyCollection<ApiObject>), null, NewtonsoftJsonSerializer.Deserializer);
                Assert.NotNull(actual);
                Assert.Empty(actual);
            }
        }

        [Fact]
        public void ReadJson_3EmptyObjects()
        {
            var converter = ReadOnlyResponseCollectionConverter.Instance;
            using(var stringReader = new StringReader("{\"total\": 3, \"rows\": [{}, {}, {}]}"))
            using(var jsonReader = new JsonTextReader(stringReader))
            {
                var actual = (IReadOnlyCollection<ApiObject>)converter.ReadJson(jsonReader, typeof(IReadOnlyCollection<ApiObject>), null, NewtonsoftJsonSerializer.Deserializer);
                Assert.NotNull(actual);
                Assert.Collection(actual,
                    a => { Assert.NotNull(a); Assert.IsType<ApiObject>(a); },
                    a => { Assert.NotNull(a); Assert.IsType<ApiObject>(a); },
                    a => { Assert.NotNull(a); Assert.IsType<ApiObject>(a); });
            }
        }

        [Fact]
        public void ReadJson_StubObject()
        {
            var converter = ReadOnlyResponseCollectionConverter.Instance;
            using(var stringReader = new StringReader("{\"total\": 1, \"rows\": [{\"id\": 0, \"name\": \"Test User\"}]}"))
            using(var jsonReader = new JsonTextReader(stringReader))
            {
                var actual = (IReadOnlyCollection<Stub<User>>)converter.ReadJson(jsonReader, typeof(IReadOnlyCollection<Stub<User>>), null, NewtonsoftJsonSerializer.Deserializer);
                Assert.NotNull(actual);
                Assert.Collection(actual, stub => {
                    Assert.Equal(0, stub.Id);
                    Assert.Equal("Test User", stub.Name);
                });
            }
        }
    }
}
