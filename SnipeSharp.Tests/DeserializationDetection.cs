using System;
using System.IO;
using Newtonsoft.Json;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.JsonConverters;
using Xunit;

namespace SnipeSharp.Tests
{
    // Test object detection
    public class DeserializationDetection
    {
        [Fact]
        public void DeserializeAsset_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/asset.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType<Asset>(result);
        }

        [Fact]
        public void DeserializeModel_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/model.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType<Model>(result);
        }

        [Fact]
        public void DeserializeCompany_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/company.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType<Company>(result);
        }

        [Fact]
        public void DeserializeLocation_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/location.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType<Location>(result);
        }

        [Fact]
        public void DeserializeAccessory_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/accessory.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType<Accessory>(result);
        }

        [Fact]
        public void DeserializeConsumable_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/consumable.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType<Consumable>(result);
        }

        [Fact]
        public void DeserializeComponent_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/component.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType<Component>(result);
        }

        [Fact]
        public void DeserializeUser_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/user.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType<User>(result);
        }

        [Fact]
        public void DeserializeStatusLabel_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/statuslabel.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType<StatusLabel>(result);
        }

        [Fact]
        public void DeserializeStatusLicense_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/license.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType<License>(result);
        }

        [Fact]
        public void DeserializeStatusCategory_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/category.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType<Category>(result);
        }

        [Fact]
        public void DeserializeStatusManufacturer_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText("./Resources/manufacturer.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType<Manufacturer>(result);
        }
    }
}
