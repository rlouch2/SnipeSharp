using System;
using System.Net;
using SnipeSharp.Exceptions;
using SnipeSharp.Models;
using Xunit;
using static SnipeSharp.Tests.Utility;

namespace SnipeSharp.Tests
{
    public sealed class SnipeItApiTests
    {
        [Fact]
        public void Init_MissingToken_ThrowsException()
        {
            Assert.Throws<NullApiTokenException>(() => {
                var snipe = new SnipeItApi();
                snipe.Uri = TEST_URI;
                snipe.RequestManager.SetTokenAndUri();
            });
        }

        [Fact]
        public void Init_MissingURI_ThrowsException()
        {
            Assert.Throws<NullApiUriException>(() => {
                var snipe = new SnipeItApi();
                snipe.Token = TEST_TOKEN;
                snipe.RequestManager.SetTokenAndUri();
            });
        }

        [Fact]
        public void Init_NoneMissing_NotThrowsException()
        {
            var snipe = new SnipeItApi
            {
                Token = TEST_TOKEN,
                Uri = TEST_URI
            };
            snipe.RequestManager.SetTokenAndUri();
            Assert.True(true);
        }

        [Fact]
        public void TestConnection_Successful()
        {
            Assert.True(SingleUseApi(@"{""id"":1}").TestConnection());
        }

        [Fact]
        public void TestConnection_Unsuccessful()
        {
            Assert.False(SingleUseApi(@"<!DOCTYPE html><html>Nope.</html>").TestConnection());
        }
    }

    public sealed class SnipeItApiGetEndPointTests
    {
        private readonly SnipeItApi Api = new SnipeItApi();

        [Fact]
        public void GenericEndPoint_RetrievesAssets()
            => Assert.Same(Api.Assets, Api.GetEndPoint<Asset>());

        [Fact]
        public void GenericEndPoint_RetrievesAccessories()
            => Assert.Same(Api.Accessories, Api.GetEndPoint<Accessory>());

        [Fact]
        public void GenericEndPoint_RetrievesCategories()
            => Assert.Same(Api.Categories, Api.GetEndPoint<Category>());

        [Fact]
        public void GenericEndPoint_RetrievesCompanies()
            => Assert.Same(Api.Companies, Api.GetEndPoint<Company>());

        [Fact]
        public void GenericEndPoint_RetrievesComponents()
            => Assert.Same(Api.Components, Api.GetEndPoint<Component>());

        [Fact]
        public void GenericEndPoint_RetrievesConsumables()
            => Assert.Same(Api.Consumables, Api.GetEndPoint<Consumable>());

        [Fact]
        public void GenericEndPoint_RetrievesCustomFields()
            => Assert.Same(Api.CustomFields, Api.GetEndPoint<CustomField>());

        [Fact]
        public void GenericEndPoint_RetrievesDepartments()
            => Assert.Same(Api.Departments, Api.GetEndPoint<Department>());

        [Fact]
        public void GenericEndPoint_RetrievesDepreciations()
            => Assert.Same(Api.Depreciations, Api.GetEndPoint<Depreciation>());

        [Fact]
        public void GenericEndPoint_RetrievesFieldSets()
            => Assert.Same(Api.FieldSets, Api.GetEndPoint<FieldSet>());

        [Fact]
        public void GenericEndPoint_RetrievesGroups()
            => Assert.Same(Api.Groups, Api.GetEndPoint<Group>());

        [Fact]
        public void GenericEndPoint_RetrievesLicenses()
            => Assert.Same(Api.Licenses, Api.GetEndPoint<License>());

        [Fact]
        public void GenericEndPoint_RetrievesLocations()
            => Assert.Same(Api.Locations, Api.GetEndPoint<Location>());

        [Fact]
        public void GenericEndPoint_RetrievesMaintenances()
            => Assert.Same(Api.Maintenances, Api.GetEndPoint<Maintenance>());

        [Fact]
        public void GenericEndPoint_RetrievesManufacturers()
            => Assert.Same(Api.Manufacturers, Api.GetEndPoint<Manufacturer>());

        [Fact]
        public void GenericEndPoint_RetrievesModels()
            => Assert.Same(Api.Models, Api.GetEndPoint<Model>());

        [Fact]
        public void GenericEndPoint_RetrievesStatusLabels()
            => Assert.Same(Api.StatusLabels, Api.GetEndPoint<StatusLabel>());

        [Fact]
        public void GenericEndPoint_RetrievesSuppliers()
            => Assert.Same(Api.Suppliers, Api.GetEndPoint<Supplier>());

        [Fact]
        public void GenericEndPoint_RetrievesUsers()
            => Assert.Same(Api.Users, Api.GetEndPoint<User>());

        [Fact]
        public void GenericEndPoint_FailsOnOther()
            => Assert.Throws<ArgumentException>(() => Api.GetEndPoint<AbstractBaseModel>() );
    }
}
