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
            var snipe = new SnipeItApi();
            var url = new Uri("http://google.com");
            snipe.ApiSettings.ApiToken = "xxxxx";
            snipe.ApiSettings.BaseUrl = url;
            snipe.ReqManager.CheckApiTokenAndUrl();

            // Get the Static property value
            var prop = typeof(RequestManagerRestSharp).GetField("Client", BindingFlags.NonPublic | BindingFlags.Static);
            var client = prop.GetValue(snipe.ReqManager) as RestClient;

            Assert.Equal<Uri>(url, client.BaseUrl);
        }

        [Fact(Skip = "Needs a Mock or something to work right.")]
        public void CheckApiTokenAndUrl_SetAuthorizationHeader_SetCorrectly()
        {
            var snipe = new SnipeItApi();
            var url = new Uri("http://google.com");
            snipe.ApiSettings.ApiToken = "xxxxx";
            snipe.ApiSettings.BaseUrl = url;
            snipe.ReqManager.CheckApiTokenAndUrl();

            // Get the Static property value
            var prop = typeof(RequestManagerRestSharp).GetField("Client", BindingFlags.NonPublic | BindingFlags.Static);
            var client = prop.GetValue(snipe.ReqManager) as RestClient;

            // NOTE: This test depends on the internal implementation of RestSharp not changing. Check there if you update that dependency!
            //var value = new PrivateObject(client.Authenticator).GetField("authorizationValue") as string;
            
            //Assert.Equal<string>("Bearer xxxxx", value);
        }
    }
}