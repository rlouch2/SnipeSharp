using RestSharp;
using SnipeSharp.Models;
using Xunit;

namespace SnipeSharp.Tests
{
    // Test object detection
    public class DeserializationTests
    {
        [Fact]
        public void DeserializeAsset()
        {
            var result = Utility.SingleUseApiFromFile("./Resources/IndividualModels/asset.json").Assets.Get(0);
            Assert.NotNull(result);
            Assert.IsType<Asset>(result);
        }

        [Fact]
        public void DeserializeModel()
        {
            var result = Utility.SingleUseApiFromFile("./Resources/IndividualModels/model.json").Models.Get(0);
            Assert.NotNull(result);
            Assert.IsType<Model>(result);
        }

        [Fact]
        public void DeserializeCompany()
        {
            var result = Utility.SingleUseApiFromFile("./Resources/IndividualModels/company.json").Companies.Get(0);
            Assert.NotNull(result);
            Assert.IsType<Company>(result);
        }

        [Fact]
        public void DeserializeLocation()
        {
            var result = Utility.SingleUseApiFromFile("./Resources/IndividualModels/location.json").Locations.Get(0);
            Assert.NotNull(result);
            Assert.IsType<Location>(result);
        }

        [Fact]
        public void DeserializeAccessory()
        {
            var result = Utility.SingleUseApiFromFile("./Resources/IndividualModels/accessory.json").Accessories.Get(0);
            Assert.NotNull(result);
            Assert.IsType<Accessory>(result);
        }

        [Fact]
        public void DeserializeConsumable()
        {
            var result = Utility.SingleUseApiFromFile("./Resources/IndividualModels/consumable.json").Consumables.Get(0);
            Assert.NotNull(result);
            Assert.IsType<Consumable>(result);
        }

        [Fact]
        public void DeserializeComponent()
        {
            var result = Utility.SingleUseApiFromFile("./Resources/IndividualModels/component.json").Components.Get(0);
            Assert.NotNull(result);
            Assert.IsType<Component>(result);
        }

        [Fact]
        public void DeserializeUser()
        {
            var result = Utility.SingleUseApiFromFile("./Resources/IndividualModels/user.json").Users.Get(0);
            Assert.NotNull(result);
            Assert.IsType<User>(result);
        }

        [Fact]
        public void DeserializeStatusLabel()
        {
            var result = Utility.SingleUseApiFromFile("./Resources/IndividualModels/statuslabel.json").StatusLabels.Get(0);
            Assert.NotNull(result);
            Assert.IsType<StatusLabel>(result);
        }

        [Fact]
        public void DeserializeStatusLicense()
        {
            var result = Utility.SingleUseApiFromFile("./Resources/IndividualModels/license.json").Licenses.Get(0);
            Assert.NotNull(result);
            Assert.IsType<License>(result);
        }

        [Fact]
        public void DeserializeStatusCategory()
        {
            var result = Utility.SingleUseApiFromFile("./Resources/IndividualModels/category.json").Categories.Get(0);
            Assert.NotNull(result);
            Assert.IsType<Category>(result);
        }

        [Fact]
        public void DeserializeStatusManufacturer()
        {
            var result = Utility.SingleUseApiFromFile("./Resources/IndividualModels/manufacturer.json").Manufacturers.Get(0);
            Assert.NotNull(result);
            Assert.IsType<Manufacturer>(result);
        }
    }
}
