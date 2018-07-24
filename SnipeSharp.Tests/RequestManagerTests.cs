using System;
using SnipeSharp.Exceptions;
using SnipeSharp.Common;
using System.Reflection;
using System.Net.Http;
using Xunit;

namespace SnipeSharp.Tests
{
    public class RequestManagerTests
    {
        [Fact]
        [ExpectedException(typeof(NullApiTokenException), "No API Token Set")]
        public void CheckApiTokenAndUrl_NoTokenInApiSettings_ThrowException()
        {
            SnipeItApi snipe = new SnipeItApi();
            snipe.ApiSettings.BaseUrl = new Uri("http://google.com");
            snipe.ReqManager.CheckApiTokenAndUrl();
        }

        [Fact]
        [ExpectedException(typeof(NullApiBaseUrlException), "No API Base Url Set.")]
        public void CheckApiTokenAndUrl_NoUrlInApiSettings_ThrowException()
        {
            SnipeItApi snipe = new SnipeItApi();
            snipe.ApiSettings.ApiToken = "xxxxx";
            snipe.ReqManager.CheckApiTokenAndUrl();
        }

        [Fact]
        public void CheckApiTokenAndUrl_SetHttpClientBaseAddress_SetCorrectly()
        {
            SnipeItApi snipe = new SnipeItApi();
            Uri url = new Uri("http://google.com");
            snipe.ApiSettings.ApiToken = "xxxxx";
            snipe.ApiSettings.BaseUrl = url;
            snipe.ReqManager.CheckApiTokenAndUrl();

            // Get the Static property value
            Type type = typeof(RequestManager);
            FieldInfo prop = type.GetField("Client", BindingFlags.NonPublic | BindingFlags.Static);
            HttpClient value = prop.GetValue(snipe.ReqManager) as HttpClient;

            Assert.AreEqual(url, value.BaseAddress);
        }

        [Fact]
        public void CheckApiTokenAndUrl_SetAuthorizationHeader_SetCorrectly()
        {
            SnipeItApi snipe = new SnipeItApi();
            Uri url = new Uri("http://google.com");
            snipe.ApiSettings.ApiToken = "xxxxx";
            snipe.ApiSettings.BaseUrl = url;
            snipe.ReqManager.CheckApiTokenAndUrl();

            // Get the Static property value
            Type type = typeof(RequestManager);
            FieldInfo prop = type.GetField("Client", BindingFlags.NonPublic | BindingFlags.Static);
            HttpClient value = prop.GetValue(snipe.ReqManager) as HttpClient;

            Assert.IsTrue(value.DefaultRequestHeaders.Authorization.Scheme == "Bearer" &&
                value.DefaultRequestHeaders.Authorization.Parameter == "xxxxx");

        }
    }
}
