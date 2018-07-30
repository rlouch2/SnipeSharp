using System;
using System.Reflection;
using SnipeSharp.Exceptions;
using SnipeSharp.Common;
using Xunit;
using RestSharp;
using RestSharp.Authenticators;

namespace SnipeSharp.Tests
{
    public class RequestManagerTests
    {
        [Fact]
        public void CheckApiTokenAndUrl_NoTokenInApiSettings_ThrowException()
        {
            var exception = Assert.Throws<NullApiTokenException>(() => {
                var snipe = new SnipeItApi();
                snipe.ApiSettings.BaseUrl = new Uri("http://google.com");
                snipe.ReqManager.CheckApiTokenAndUrl();
            });
            Assert.Equal("No API Token Set", exception.Message);
        }

        [Fact]
        public void CheckApiTokenAndUrl_NoUrlInApiSettings_ThrowException()
        {
            var exception = Assert.Throws<NullApiBaseUrlException>(() => {
                var snipe = new SnipeItApi();
                snipe.ApiSettings.ApiToken = "xxxxx";
                snipe.ReqManager.CheckApiTokenAndUrl();
            });
            Assert.Equal("No API Base Url Set.", exception.Message);
        }

        [Fact]
        public void CheckApiTokenAndUrl_SetHttpClientBaseAddress_SetCorrectly()
        {
            var url = new Uri("http://google.com");
            var snipe = new SnipeItApi {
                ApiSettings = new ApiSettings {
                    ApiToken = "xxxxx",
                    BaseUrl = url
                }
            };
            snipe.ReqManager.CheckApiTokenAndUrl();
            Assert.Equal<Uri>(url, snipe.ReqManager.Client.BaseUrl);
        }

        [Fact]
        public void CheckApiTokenAndUrl_SetAuthorizationHeader_SetCorrectly()
        {
            var url = new Uri("http://google.com");
            var snipe = new SnipeItApi {
                ApiSettings = new ApiSettings {
                    ApiToken = "xxxxx",
                    BaseUrl = url
                }
            };
            snipe.ReqManager.CheckApiTokenAndUrl();
            // the best we can do.
            Assert.NotNull(snipe.ReqManager.Client.Authenticator);
        }
    }
}