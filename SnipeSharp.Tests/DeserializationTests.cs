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
        [Fact]
        public void DeserializeAsset()
        {
            var result = Utility.OneUseApi("./Resources/IndividualModels/asset.json").GetEndPoint<Asset>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Asset>(result);
        }

        [Fact]
        public void DeserializeModel()
        {
            var result = Utility.OneUseApi("./Resources/IndividualModels/model.json").GetEndPoint<Model>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Model>(result);
        }

        [Fact]
        public void DeserializeCompany()
        {
            var result = Utility.OneUseApi("./Resources/IndividualModels/company.json").GetEndPoint<Company>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Company>(result);
        }

        [Fact]
        public void DeserializeLocation()
        {
            var result = Utility.OneUseApi("./Resources/IndividualModels/location.json").GetEndPoint<Location>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Location>(result);
        }

        [Fact]
        public void DeserializeAccessory()
        {
            var result = Utility.OneUseApi("./Resources/IndividualModels/accessory.json").GetEndPoint<Accessory>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Accessory>(result);
        }

        [Fact]
        public void DeserializeConsumable()
        {
            var result = Utility.OneUseApi("./Resources/IndividualModels/consumable.json").GetEndPoint<Consumable>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Consumable>(result);
        }

        [Fact]
        public void DeserializeComponent()
        {
            var result = Utility.OneUseApi("./Resources/IndividualModels/component.json").GetEndPoint<Component>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Component>(result);
        }

        [Fact]
        public void DeserializeUser()
        {
            var result = Utility.OneUseApi("./Resources/IndividualModels/user.json").GetEndPoint<User>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<User>(result);
        }

        [Fact]
        public void DeserializeStatusLabel()
        {
            var result = Utility.OneUseApi("./Resources/IndividualModels/statuslabel.json").GetEndPoint<StatusLabel>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<StatusLabel>(result);
        }

        [Fact]
        public void DeserializeStatusLicense()
        {
            var result = Utility.OneUseApi("./Resources/IndividualModels/license.json").GetEndPoint<License>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<License>(result);
        }

        [Fact]
        public void DeserializeStatusCategory()
        {
            var result = Utility.OneUseApi("./Resources/IndividualModels/category.json").GetEndPoint<Category>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Category>(result);
        }

        [Fact]
        public void DeserializeStatusManufacturer()
        {
            var result = Utility.OneUseApi("./Resources/IndividualModels/manufacturer.json").GetEndPoint<Manufacturer>().Get(0);
            Assert.NotNull(result);
            Assert.IsType<Manufacturer>(result);
        }
    }
}
