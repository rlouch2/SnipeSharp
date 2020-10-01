using System;
using SnipeSharp.Models;
using SnipeSharp.Models.Enumerations;
using Xunit;
using static SnipeSharp.Models.Enumerations.AvailableAction;

namespace SnipeSharp.Test
{
    using static Utility;
    public class AssetTest
    {
        private const string DEMO_ASSET_JSON_RESPONSE = @"{
    ""id"": 1,
    ""name"": ""test-asset"",
    ""asset_tag"": ""1234"",
    ""serial"": ""ABCDEFGHIJKLM"",
    ""model"": {
        ""id"": 1,
        ""name"": ""Test Model""
    },
    ""model_number"": ""Test Model"",
    ""eol"": null,
    ""status_label"": {
        ""id"": 3,
        ""name"": ""Deployable"",
        ""status_type"": ""deployable"",
        ""status_meta"": ""deployed""
    },
    ""category"": {
        ""id"": 1,
        ""name"": ""Test Category""
    },
    ""manufacturer"": {
        ""id"": 1,
        ""name"": ""Test Manufacturer""
    },
    ""supplier"": {
        ""id"": 1,
        ""name"": ""Test Supplier""
    },
    ""notes"": ""This is a note"",
    ""order_number"": ""abc12345"",
    ""company"": {
        ""id"": 3,
        ""name"": "" test corp""
    },
    ""location"": {
        ""id"": 2,
        ""name"": ""Maine""
    },
    ""rtd_location"": {
        ""id"": 2,
        ""name"": ""Maine""
    },
    ""image"": null,
    ""assigned_to"": null,
    ""warranty_months"": ""36 months"",
    ""warranty_expires"": {
        ""date"": ""2021-06-01"",
        ""formatted"": ""2021-06-01""
    },
    ""created_at"": {
        ""datetime"": ""2020-01-01 12:00:00"",
        ""formatted"": ""2020-01-01 12:00 AM""
    },
    ""updated_at"": {
        ""datetime"": ""2020-01-01 12:00:00"",
        ""formatted"": ""2020-01-01 12:00 AM""
    },
    ""last_audit_date"": null,
    ""next_audit_date"": null,
    ""deleted_at"": null,
    ""purchase_date"": {
        ""date"": ""2019-01-01"",
        ""formatted"": ""2019-01-01""
    },
    ""last_checkout"": null,
    ""expected_checkin"": null,
    ""purchase_cost"": ""970.00"",
    ""checkin_counter"": 0,
    ""checkout_counter"": 0,
    ""requests_counter"": 0,
    ""user_can_checkout"": false,
    ""custom_fields"": {
        ""LAN MAC Address"": {
            ""field"": ""_snipeit_lan_mac_address_1"",
            ""value"": ""00:11:22:33:44:55"",
            ""field_format"": ""MAC""
        },
        ""IPv4 Address"": {
            ""field"": ""_snipeit_ipv4_address_3"",
            ""value"": null,
            ""field_format"": ""ANY""
        }
    },
    ""available_actions"": {
        ""checkout"": true,
        ""checkin"": true,
        ""clone"": true,
        ""restore"": false,
        ""update"": true,
        ""delete"": true
    }
}";
        [Fact]
        public void DeserializeAsset()
        {
            var result = new SnipeItApi(MockClientFor(DEMO_ASSET_JSON_RESPONSE)){
                Token = TEST_TOKEN,
                Uri = TEST_URI
            }.Assets.Get(0);
            Assert.NotNull(result);
            Assert.IsType<Asset>(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("test-asset", result.Name);
            Assert.Equal("1234", result.AssetTag);
            Assert.Equal("ABCDEFGHIJKLM", result.Serial);
            Assert.NotNull(result.Model);
                Assert.Equal(1, result.Model.Id);
                Assert.Equal("Test Model", result.Model.Name);
            Assert.Equal("Test Model", result.ModelNumber);
            Assert.Null(result.EndOfLife);
            Assert.NotNull(result.Status);
                Assert.Equal(3, result.Status.StatusId);
                Assert.Equal("Deployable", result.Status.Name);
                Assert.Equal(StatusType.Deployable, result.Status.StatusType);
                Assert.Equal(StatusMeta.Deployed, result.Status.StatusMeta);
            Assert.NotNull(result.Category);
                Assert.Equal(1, result.Category.Id);
                Assert.Equal("Test Category", result.Category.Name);
            Assert.NotNull(result.Manufacturer);
                Assert.Equal(1, result.Manufacturer.Id);
                Assert.Equal("Test Manufacturer", result.Manufacturer.Name);
            Assert.NotNull(result.Supplier);
                Assert.Equal(1, result.Supplier.Id);
                Assert.Equal("Test Supplier", result.Supplier.Name);
            Assert.Equal("This is a note", result.Notes);
            Assert.Equal("abc12345", result.OrderNumber);
            Assert.NotNull(result.Company);
                Assert.Equal(3, result.Company.Id);
                Assert.Equal(" test corp", result.Company.Name);
            Assert.NotNull(result.Location);
                Assert.Equal(2, result.Location.Id);
                Assert.Equal("Maine", result.Location.Name);
            Assert.NotNull(result.DefaultLocation);
                Assert.Equal(2, result.DefaultLocation.Id);
                Assert.Equal("Maine", result.DefaultLocation.Name);
            Assert.Null(result.ImageUri);
            Assert.Null(result.AssignedTo);
            Assert.Equal(36, result.WarrantyMonths);
            Assert.Equal(new DateTime(2021, 6, 1), result.WarrantyExpires);
            Assert.Equal(new DateTime(2020, 1, 1, 12, 0, 0), result.CreatedAt);
            Assert.Equal(new DateTime(2020, 1, 1, 12, 0, 0), result.UpdatedAt);
            Assert.Null(result.LastAuditDate);
            Assert.Null(result.NextAuditDate);
            Assert.Null(result.DeletedAt);
            Assert.False(result.IsDeleted);
            Assert.Equal(new DateTime(2019, 1, 1), result.PurchaseDate);
            Assert.Null(result.LastCheckOut);
            Assert.Null(result.ExpectedCheckIn);
            Assert.Equal(970.00M, result.PurchaseCost);
            Assert.Equal(0, result.CheckInCounter);
            Assert.Equal(0, result.CheckOutCounter);
            Assert.Equal(0, result.RequestsCounter);
            Assert.False(result.UserCanCheckOut);
            Assert.True(result.CustomFields.Models.TryGetValue("_snipeit_lan_mac_address_1", out var macVal));
                Assert.Equal("LAN MAC Address", macVal.FriendlyName);
                Assert.Equal("_snipeit_lan_mac_address_1", macVal.Field);
                Assert.Equal("00:11:22:33:44:55", macVal.Value);
                Assert.Equal("MAC", macVal.Format);
            Assert.True(result.CustomFields.Models.TryGetValue("_snipeit_ipv4_address_3", out var ipVal));
                Assert.Equal("IPv4 Address", ipVal.FriendlyName);
                Assert.Equal("_snipeit_ipv4_address_3", ipVal.Field);
                Assert.Null(ipVal.Value);
                Assert.Equal("ANY", ipVal.Format);
            Assert.Equal(CheckOut | CheckIn | Clone | Update | Delete, result.AvailableActions);
        }
    }
}
