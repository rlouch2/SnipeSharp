using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using SnipeSharp.Models;
using SnipeSharp.Serialization;
using Xunit;

namespace SnipeSharp.Tests
{
    // Test object detection
    public class DeserializationTests
    {
        private static NewtonsoftJsonSerializer Serializer = new NewtonsoftJsonSerializer();
        private static StubRestClient StubRestClient = new StubRestClient();
        private static SnipeItApi Api = new SnipeItApi(StubRestClient) {
            Token = "xxxx",
            Uri = new Uri("http://localhost/api/v1")
        };

        [Fact]
        public void DeserializeAsset()
        {
            StubRestClient.Response = new StubResponse(File.ReadAllText("./Resources/asset.json"));
            var result = Api.GetEndPoint<Asset>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Asset>(result);
        }

        [Fact]
        public void DeserializeModel()
        {
            StubRestClient.Response = new StubResponse(File.ReadAllText("./Resources/model.json"));
            var result = Api.GetEndPoint<Model>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Model>(result);
        }

        [Fact]
        public void DeserializeCompany_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/company.json");
            var result = Serializer.Deserialize<Company>(new StubResponse(obj));
            Assert.IsType<Company>(result);
        }

        [Fact]
        public void DeserializeLocation_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/location.json");
            var result = Serializer.Deserialize<Location>(new StubResponse(obj));
            Assert.IsType<Location>(result);
        }

        [Fact]
        public void DeserializeAccessory_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/accessory.json");
            var result = Serializer.Deserialize<Accessory>(new StubResponse(obj));
            Assert.IsType<Accessory>(result);
        }

        [Fact]
        public void DeserializeConsumable_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/consumable.json");
            var result = Serializer.Deserialize<Consumable>(new StubResponse(obj));
            Assert.IsType<Consumable>(result);
        }

        [Fact]
        public void DeserializeComponent_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/component.json");
            var result = Serializer.Deserialize<Component>(new StubResponse(obj));
            Assert.IsType<Component>(result);
        }

        [Fact]
        public void DeserializeUser_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/user.json");
            var result = Serializer.Deserialize<User>(new StubResponse(obj));
            Assert.IsType<User>(result);
        }

        [Fact]
        public void DeserializeStatusLabel_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/statuslabel.json");
            var result = Serializer.Deserialize<StatusLabel>(new StubResponse(obj));
            Assert.IsType<StatusLabel>(result);
        }

        [Fact]
        public void DeserializeStatusLicense_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/license.json");
            var result = Serializer.Deserialize<License>(new StubResponse(obj));
            Assert.IsType<License>(result);
        }

        [Fact]
        public void DeserializeStatusCategory_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/category.json");
            var result = Serializer.Deserialize<Category>(new StubResponse(obj));
            Assert.IsType<Category>(result);
        }

        [Fact]
        public void DeserializeStatusManufacturer_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/manufacturer.json");
            var result = Serializer.Deserialize<Manufacturer>(new StubResponse(obj));
            Assert.IsType<Manufacturer>(result);
        }
    }
}
