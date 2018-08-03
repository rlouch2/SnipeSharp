using System;
using System.Reflection;
using SnipeSharp.Exceptions;
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
            Assert.Throws<NullApiTokenException>(() => {
                var snipe = new SnipeItApi();
                snipe.Uri = new Uri("http://google.com");
                snipe.RequestManager.SetTokenAndUri();
            });
        }

        [Fact]
        public void CheckApiTokenAndUrl_NoUrlInApiSettings_ThrowException()
        {
            Assert.Throws<NullApiUriException>(() => {
                var snipe = new SnipeItApi();
                snipe.Token = "xxxxx";
                snipe.RequestManager.SetTokenAndUri();
            });
        }

        [Fact(Skip = "New API does not expose Client")]
        public void CheckApiTokenAndUrl_SetHttpClientBaseAddress_SetCorrectly()
        {
            var url = new Uri("http://google.com");
            var snipe = new SnipeItApi {
                Token = "xxxxx",
                Uri = url
            };
            snipe.RequestManager.SetTokenAndUri();
            //Assert.Equal<Uri>(url, snipe.RequestManager.Client.Uri);
        }

        [Fact(Skip = "New API does not expose Client")]
        public void CheckApiTokenAndUrl_SetAuthorizationHeader_SetCorrectly()
        {
            var snipe = new SnipeItApi {
                Token = "xxxxx",
                Uri = new Uri("http://google.com")
            };
            snipe.RequestManager.SetTokenAndUri();
            // the best we can do.
            //Assert.NotNull(snipe.RequestManager.Client.Authenticator);
        }
    }
}
