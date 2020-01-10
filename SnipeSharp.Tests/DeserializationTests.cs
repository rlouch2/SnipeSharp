using RestSharp;
using SnipeSharp.Models;
using Xunit;

namespace SnipeSharp.Tests
{
    // Test object detection
    public class DeserializationTests
    {
        [Fact]
        public void DeserializeModel()
        {
            var result = Utility.SingleUseApiFromFile(Resources.IndividualModels.Model).Models.Get(0);
            Assert.NotNull(result);
            Assert.IsType<Model>(result);
        }

        [Fact]
        public void DeserializeCompany()
        {
            var result = Utility.SingleUseApiFromFile(Resources.IndividualModels.Company).Companies.Get(0);
            Assert.NotNull(result);
            Assert.IsType<Company>(result);
        }

        [Fact]
        public void DeserializeLocation()
        {
            var result = Utility.SingleUseApiFromFile(Resources.IndividualModels.Location).Locations.Get(0);
            Assert.NotNull(result);
            Assert.IsType<Location>(result);
        }

        [Fact]
        public void DeserializeAccessory()
        {
            var result = Utility.SingleUseApiFromFile(Resources.IndividualModels.Accessory).Accessories.Get(0);
            Assert.NotNull(result);
            Assert.IsType<Accessory>(result);
        }

        [Fact]
        public void DeserializeConsumable()
        {
            var result = Utility.SingleUseApiFromFile(Resources.IndividualModels.Consumable).Consumables.Get(0);
            Assert.NotNull(result);
            Assert.IsType<Consumable>(result);
        }

        [Fact]
        public void DeserializeComponent()
        {
            var result = Utility.SingleUseApiFromFile(Resources.IndividualModels.Component).Components.Get(0);
            Assert.NotNull(result);
            Assert.IsType<Component>(result);
        }

        [Fact]
        public void DeserializeUser()
        {
            var result = Utility.SingleUseApiFromFile(Resources.IndividualModels.User).Users.Get(0);
            Assert.NotNull(result);
            Assert.IsType<User>(result);
        }

        [Fact]
        public void DeserializeStatusLabel()
        {
            var result = Utility.SingleUseApiFromFile(Resources.IndividualModels.StatusLabel).StatusLabels.Get(0);
            Assert.NotNull(result);
            Assert.IsType<StatusLabel>(result);
        }

        [Fact]
        public void DeserializeStatusLicense()
        {
            var result = Utility.SingleUseApiFromFile(Resources.IndividualModels.License).Licenses.Get(0);
            Assert.NotNull(result);
            Assert.IsType<License>(result);
        }

        [Fact]
        public void DeserializeStatusCategory()
        {
            var result = Utility.SingleUseApiFromFile(Resources.IndividualModels.Category).Categories.Get(0);
            Assert.NotNull(result);
            Assert.IsType<Category>(result);
        }

        [Fact]
        public void DeserializeStatusManufacturer()
        {
            var result = Utility.SingleUseApiFromFile(Resources.IndividualModels.Manufacturer).Manufacturers.Get(0);
            Assert.NotNull(result);
            Assert.IsType<Manufacturer>(result);
        }
    }
}
