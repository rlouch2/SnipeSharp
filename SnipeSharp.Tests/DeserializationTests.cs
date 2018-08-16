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
            StubRestClient.Responses.Enqueue(new StubResponse(File.ReadAllText("./Resources/IndividualModels/asset.json")));
            var result = Api.GetEndPoint<Asset>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Asset>(result);
        }

        [Fact]
        public void DeserializeModel()
        {
            StubRestClient.Responses.Enqueue(new StubResponse(File.ReadAllText("./Resources/IndividualModels/model.json")));
            var result = Api.GetEndPoint<Model>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Model>(result);
        }

        [Fact]
        public void DeserializeCompany()
        {
            StubRestClient.Responses.Enqueue(new StubResponse(File.ReadAllText("./Resources/IndividualModels/company.json")));
            var result = Api.GetEndPoint<Company>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Company>(result);
        }

        [Fact]
        public void DeserializeLocation()
        {
            StubRestClient.Responses.Enqueue(new StubResponse(File.ReadAllText("./Resources/IndividualModels/location.json")));
            var result = Api.GetEndPoint<Location>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Location>(result);
        }

        [Fact]
        public void DeserializeAccessory()
        {
            StubRestClient.Responses.Enqueue(new StubResponse(File.ReadAllText("./Resources/IndividualModels/accessory.json")));
            var result = Api.GetEndPoint<Accessory>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Accessory>(result);
        }

        [Fact]
        public void DeserializeConsumable()
        {
            StubRestClient.Responses.Enqueue(new StubResponse(File.ReadAllText("./Resources/IndividualModels/consumable.json")));
            var result = Api.GetEndPoint<Consumable>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Consumable>(result);
        }

        [Fact]
        public void DeserializeComponent()
        {
            StubRestClient.Responses.Enqueue(new StubResponse(File.ReadAllText("./Resources/IndividualModels/component.json")));
            var result = Api.GetEndPoint<Component>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Component>(result);
        }

        [Fact]
        public void DeserializeUser()
        {
            StubRestClient.Responses.Enqueue(new StubResponse(File.ReadAllText("./Resources/IndividualModels/user.json")));
            var result = Api.GetEndPoint<User>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<User>(result);
        }

        [Fact]
        public void DeserializeStatusLabel()
        {
            StubRestClient.Responses.Enqueue(new StubResponse(File.ReadAllText("./Resources/IndividualModels/statuslabel.json")));
            var result = Api.GetEndPoint<StatusLabel>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<StatusLabel>(result);
        }

        [Fact]
        public void DeserializeStatusLicense()
        {
            StubRestClient.Responses.Enqueue(new StubResponse(File.ReadAllText("./Resources/IndividualModels/license.json")));
            var result = Api.GetEndPoint<License>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<License>(result);
        }

        [Fact]
        public void DeserializeStatusCategory()
        {
            StubRestClient.Responses.Enqueue(new StubResponse(File.ReadAllText("./Resources/IndividualModels/category.json")));
            var result = Api.GetEndPoint<Category>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Category>(result);
        }

        [Fact]
        public void DeserializeStatusManufacturer()
        {
            StubRestClient.Responses.Enqueue(new StubResponse(File.ReadAllText("./Resources/IndividualModels/manufacturer.json")));
            var result = Api.GetEndPoint<Manufacturer>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Manufacturer>(result);
        }
    }
}
