using System;
using SnipeSharp.Models;
using Xunit;

namespace SnipeSharp.Test
{
    using static Utility;
    public sealed class LicenseEndPointTests
    {
        [Fact]
        public void GetSeats_DoesNotAcceptNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SnipeItApi(MockClientFor(out _)){ Token = TEST_TOKEN, Uri = TEST_URI }.Licenses.GetSeats(null));
        }

        [Fact]
        public void GetSeats_NoSeats()
        {
            var api = new SnipeItApi(MockClientFor(@"
            {
                ""total"": 0,
                ""rows"": []
            }")){ Token = TEST_TOKEN, Uri = TEST_URI };
            var results = api.Licenses.GetSeats(new License(1));
            Assert.Equal(0, results.Total);
            Assert.Empty(results);
        }

        [Fact]
        public void GetSeats_Mixed()
        {
            var api = new SnipeItApi(MockClientFor(@"
            {
                ""total"": 2,
                ""rows"": [
                    {
                        ""id"": 205,
                        ""license_id"": 1,
                        ""name"": ""Seat 1"",
                        ""assigned_user"": null,
                        ""assigned_asset"": null,
                        ""location"": null,
                        ""reassignable"": true,
                        ""user_can_checkout"": true,
                        ""available_actions"": {
                            ""checkout"": true,
                            ""checkin"": true,
                            ""clone"": true,
                            ""update"": true,
                            ""delete"": true
                        }
                    },
                    {
                        ""id"": 201,
                        ""license_id"": 1,
                        ""name"": ""Seat 2"",
                        ""assigned_user"": {
                            ""id"": 151,
                            ""name"": ""Test User"",
                            ""department"": null
                        },
                        ""assigned_asset"": null,
                        ""location"": {
                            ""id"": 1,
                            ""name"": ""Test Location""
                        },
                        ""reassignable"": true,
                        ""user_can_checkout"": false,
                        ""available_actions"": {
                            ""checkout"": true,
                            ""checkin"": true,
                            ""clone"": true,
                            ""update"": true,
                            ""delete"": true
                        }
                    }
                ]
            }")){ Token = TEST_TOKEN, Uri = TEST_URI };
            var results = api.Licenses.GetSeats(new License(1));
            Assert.Equal(2, results.Total);
            Assert.Collection(results,
                a => {
                    Assert.Equal("Seat 1", a.Name);
                    Assert.Null(a.AssignedUser);
                    Assert.Null(a.AssignedAsset);
                    Assert.Null(a.Location);
                    Assert.False(a.IsCheckedOut);
                },
                a => {
                    Assert.Equal("Seat 2", a.Name);
                    Assert.NotNull(a.AssignedUser);
                    Assert.Equal(151, a.AssignedUser.Id);
                    Assert.Equal("Test User", a.AssignedUser.Name);
                    Assert.Null(a.AssignedAsset);
                    Assert.NotNull(a.Location);
                    Assert.Equal(1, a.Location.Id);
                    Assert.True(a.IsCheckedOut);
                }
            );
        }
    }
}
