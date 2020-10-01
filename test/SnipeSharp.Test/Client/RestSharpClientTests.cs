using System.Net;
using Moq;
using RestSharp;
using SnipeSharp.Exceptions;
using SnipeSharp.Models;
using Xunit;

namespace SnipeSharp.Test
{
    using static Utility;
    /// <summary>
    /// Specific tests to cover certain things in <see cref="SnipeSharp.Client.RestSharpClient"/>.
    /// </summary>
    public sealed class RestSharpClientTests
    {
        [Fact]
        public void NonGet_UnsuccessfulRequest_ThrowsApiException()
        {
            var api = new SnipeItApi(MockClientFor(
                response: "{\"message\": \"{\"general\": \"generic failure\"}, \"status\": \"error\"}",
                isSuccessful: false,
                statusCode: HttpStatusCode.InternalServerError
            ))
            {
                Token = TEST_TOKEN,
                Uri = TEST_URI
            };
            var ex = Assert.Throws<ApiErrorException>(() => api.Users.Update(new User(0)));
            Assert.True(ex.IsHttpError);
            Assert.Equal(HttpStatusCode.InternalServerError, ex.HttpStatusCode);
        }

        [Fact]
        public void NonGet_ErrorResponse_ThrowsApiException()
        {
            var api = new SnipeItApi(MockClientFor("{\"status\": \"error\"}")){ Token = TEST_TOKEN, Uri = TEST_URI };
            Assert.Throws<ApiErrorException>(() => api.Users.Delete(0));
        }
    }
}
