using System;
using System.Net;
using SnipeSharp.Exceptions;
using SnipeSharp.Models;
using SnipeSharp.Models.Enumerations;
using Xunit;

namespace SnipeSharp.Test
{
    using static Utility;
    public sealed class StatusLabelEndPointTests
    {
        [Theory]
        [InlineData("0\n", false)]
        [InlineData("1\n", true)]
        public void IsDeployable_ReturnsBoolean(string response, bool expected)
        {
            var api = new SnipeItApi(MockClientFor(response)){ Token = TEST_TOKEN, Uri = TEST_URI };
            Assert.Equal(expected, api.StatusLabels.IsDeployable(new StatusLabel()));
        }

        [Fact]
        public void IsDeployable_CanFail()
        {
            var api = new SnipeItApi(MockClientFor("{\"status\":\"error\"}", isSuccessful: false, statusCode: HttpStatusCode.NotFound)){ Token = TEST_TOKEN, Uri = TEST_URI };
            Assert.Throws<ApiErrorException>(() => api.StatusLabels.IsDeployable(new StatusLabel()));
        }

        [Fact]
        public void IsDeployable_DoesNotAcceptNull()
        {
            var api = new SnipeItApi(MockClientFor(out _)){ Token = TEST_TOKEN, Uri = TEST_URI };
            Assert.Throws<ArgumentNullException>(() => api.StatusLabels.IsDeployable(null));
        }

        [Fact]
        public void FromAssetStatus_DoesNotAcceptNull()
        {
            var api = new SnipeItApi(MockClientFor(out _)){ Token = TEST_TOKEN, Uri = TEST_URI };
            Assert.Throws<ArgumentNullException>(() => api.StatusLabels.FromAssetStatus(null));
        }

        [Fact]
        public void FromAssetStatus_AcceptsNonNull()
        {
            var api = new SnipeItApi(MockClientFor(@"
            {
                ""id"": 1,
                ""name"": ""Pending"",
                ""type"": ""pending"",
                ""color"": null,
                ""show_in_nav"": false,
                ""default_label"": false,
                ""assets_count"": 0,
                ""notes"": ""These assets are not yet ready to be deployed, usually because of configuration or waiting on parts."",
                ""created_at"": null,
                ""updated_at"": null,
                ""available_actions"": {
                    ""update"": true,
                    ""delete"": true
                }
            }
            ")){ Token = TEST_TOKEN, Uri = TEST_URI };
            var result = api.StatusLabels.FromAssetStatus(new AssetStatus { StatusId = 1 });
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(StatusType.Pending, result.Type);
        }

        [Fact]
        public void GetAssets_DoesNotAcceptNull()
        {
            var api = new SnipeItApi(MockClientFor(out _)){ Token = TEST_TOKEN, Uri = TEST_URI };
            Assert.Throws<ArgumentNullException>(() => api.StatusLabels.GetAssets(null));
        }

        [Fact]
        public void GetAssets()
        {
            var api = new SnipeItApi(MockClientFor(@"
            {
                ""total"": 1,
                ""rows"": [
                    {
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
                            ""name"": ""Archived"",
                            ""status_type"": ""archived"",
                            ""status_meta"": ""archived""
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
                        ""notes"": null,
                        ""order_number"": null,
                        ""company"": null,
                        ""location"": null,
                        ""rtd_location"": null,
                        ""image"": null,
                        ""assigned_to"": null,
                        ""warranty_months"": null,
                        ""warranty_expires"": null,
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
                    }
                ]
            }")){ Token = TEST_TOKEN, Uri = TEST_URI };
            var result = api.StatusLabels.GetAssets(new StatusLabel(3));
            Assert.Equal(1, result.Total);
            Assert.Collection(result, (Asset a) => {
                Assert.Equal(1, a.Id);
                Assert.Equal("test-asset", a.Name);
            });
        }
    }
}
