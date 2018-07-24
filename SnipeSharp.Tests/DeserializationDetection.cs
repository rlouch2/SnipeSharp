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
            var obj = File.ReadAllText(@"..\..\TestObjs\asset.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType(typeof(Asset), result);
        }

        [Fact]
        public void DeserializeModel_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText(@"..\..\TestObjs\model.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType(typeof(Model), result);
        }

        [Fact]
        public void DeserializeCompany_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText(@"..\..\TestObjs\company.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType(typeof(Company), result);
        }

        [Fact]
        public void DeserializeLocation_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText(@"..\..\TestObjs\location.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType(typeof(Location), result);
        }

        [Fact]
        public void DeserializeAccessory_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText(@"..\..\TestObjs\accessory.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType(typeof(Accessory), result);
        }

        [Fact]
        public void DeserializeConsumable_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText(@"..\..\TestObjs\consumable.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType(typeof(Consumable), result);
        }

        [Fact]
        public void DeserializeComponent_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText(@"..\..\TestObjs\component.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType(typeof(Component), result);
        }

        [Fact]
        public void DeserializeUser_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText(@"..\..\TestObjs\user.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType(typeof(User), result);
        }

        [Fact]
        public void DeserializeStatusLabel_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText(@"..\..\TestObjs\statuslabel.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType(typeof(StatusLabel), result);
        }

        [Fact]
        public void DeserializeStatusLicense_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText(@"..\..\TestObjs\license.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType(typeof(License), result);
        }

        [Fact]
        public void DeserializeStatusCategory_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText(@"..\..\TestObjs\category.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType(typeof(Category), result);
        }

        [Fact]
        public void DeserializeStatusManufacturer_ValidObject_ReturnAsset()
        {
            var obj = File.ReadAllText(@"..\..\TestObjs\manufacturer.json");
            var result = JsonConvert.DeserializeObject<ICommonEndpointModel>(obj, new DetectJsonObjectType());
            Assert.IsType(typeof(Manufacturer), result);
        }
    }
}
