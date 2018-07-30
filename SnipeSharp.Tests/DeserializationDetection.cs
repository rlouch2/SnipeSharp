using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.Serialization;
using Xunit;

namespace SnipeSharp.Tests
{
    // Test object detection
    public class DeserializationDetection
    {
        private static NewtonsoftJsonSerializer Serializer = new NewtonsoftJsonSerializer();

        private class MockResponse : RestSharp.IRestResponse
        {
            public MockResponse(string content)
            {
                Content = content;
            }
            public IRestRequest Request { get; set; }
            public string ContentType { get; set; }
            public long ContentLength { get; set; }
            public string ContentEncoding { get; set; }
            public string Content { get; set; }
            public HttpStatusCode StatusCode { get; set; }
            public bool IsSuccessful => throw new NotImplementedException();
            public string StatusDescription { get; set; }
            public byte[] RawBytes { get; set; }
            public Uri ResponseUri { get; set; }
            public string Server { get; set; }
            public IList<RestResponseCookie> Cookies => throw new NotImplementedException();
            public IList<Parameter> Headers => throw new NotImplementedException();
            public ResponseStatus ResponseStatus { get; set; }
            public string ErrorMessage { get; set; }
            public Exception ErrorException { get; set; }
            public Version ProtocolVersion { get; set; }
        }

        [Fact]
        public void DeserializeAsset_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/asset.json");
            var result = Serializer.Deserialize<Asset>(new MockResponse(obj));
            Console.WriteLine(result.GetType());
            Assert.IsType<Asset>(result);
        }

        [Fact]
        public void DeserializeModel_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/model.json");
            var result = Serializer.Deserialize<Model>(new MockResponse(obj));
            Assert.IsType<Model>(result);
        }

        [Fact]
        public void DeserializeCompany_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/company.json");
            var result = Serializer.Deserialize<Company>(new MockResponse(obj));
            Assert.IsType<Company>(result);
        }

        [Fact]
        public void DeserializeLocation_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/location.json");
            var result = Serializer.Deserialize<Location>(new MockResponse(obj));
            Assert.IsType<Location>(result);
        }

        [Fact]
        public void DeserializeAccessory_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/accessory.json");
            var result = Serializer.Deserialize<Accessory>(new MockResponse(obj));
            Assert.IsType<Accessory>(result);
        }

        [Fact]
        public void DeserializeConsumable_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/consumable.json");
            var result = Serializer.Deserialize<Consumable>(new MockResponse(obj));
            Assert.IsType<Consumable>(result);
        }

        [Fact]
        public void DeserializeComponent_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/component.json");
            var result = Serializer.Deserialize<Component>(new MockResponse(obj));
            Assert.IsType<Component>(result);
        }

        [Fact]
        public void DeserializeUser_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/user.json");
            var result = Serializer.Deserialize<User>(new MockResponse(obj));
            Assert.IsType<User>(result);
        }

        [Fact]
        public void DeserializeStatusLabel_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/statuslabel.json");
            var result = Serializer.Deserialize<StatusLabel>(new MockResponse(obj));
            Assert.IsType<StatusLabel>(result);
        }

        [Fact]
        public void DeserializeStatusLicense_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/license.json");
            var result = Serializer.Deserialize<License>(new MockResponse(obj));
            Assert.IsType<License>(result);
        }

        [Fact]
        public void DeserializeStatusCategory_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/category.json");
            var result = Serializer.Deserialize<Category>(new MockResponse(obj));
            Assert.IsType<Category>(result);
        }

        [Fact]
        public void DeserializeStatusManufacturer_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/manufacturer.json");
            var result = Serializer.Deserialize<Manufacturer>(new MockResponse(obj));
            Assert.IsType<Manufacturer>(result);
        }
    }
}
