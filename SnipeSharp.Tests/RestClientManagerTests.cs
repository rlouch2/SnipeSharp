using System.Net;
using RestSharp;
using SnipeSharp.Exceptions;
using SnipeSharp.Models;
using SnipeSharp.Serialization;
using Xunit;
using static SnipeSharp.Tests.Utility;

namespace SnipeSharp.Tests
{
    /// <summary>
    /// Specific tests to cover certain things in <see cref="SnipeSharp.RestClientManager"/>
    /// and <see cref="SnipeSharp.RestRequestExtensions"/>.
    /// </summary>
    public sealed class RestClientManagerTests
    {
        private const string REST_REQUEST_PATH = "https://fake.localhost/api/v1";
        [Fact]
        public void NonGet_UnsuccessfulRequest_ThrowsApiException()
        {
            var api = SingleUseApi("{\"message\": \"{\"general\": \"generic failure\"}, \"status\": \"error\"}", false, HttpStatusCode.InternalServerError);
            var ex = Assert.Throws<ApiErrorException>(() => api.Users.Update(new User(0)));
            Assert.True(ex.IsHttpError);
            Assert.Equal(HttpStatusCode.InternalServerError, ex.HttpStatusCode);
        }

        [Fact]
        public void NonGet_ErrorResponse_ThrowsApiException()
        {
            var api = SingleUseApi("{\"status\": \"error\"}");
            Assert.Throws<ApiErrorException>(() => api.Users.Delete(0));
        }

        [Fact]
        public void AddObject_SkipsIfSerializeAsIsNull()
        {
            var request = new RestClientManager(null, null).CreateRequest(REST_REQUEST_PATH, Method.GET, new AddObjectTestClassNullSerializeAs());
            Assert.Empty(request.Parameters);
        }

        [Fact]
        public void AddObject_ThrowsMissingRequiredFieldException()
        {
            Assert.Throws<MissingRequiredFieldException<object>>(()
                => new RestClientManager(null, null).CreateRequest(REST_REQUEST_PATH, Method.GET, new AddObjectTestClassIsRequired()));
        }

        [Fact]
        public void AddObject_UsesConverter()
        {
            var request = new RestClientManager(null, null).CreateRequest(REST_REQUEST_PATH, Method.GET, new AddObjectTestClassSerializeConverter { User = new User(0) });
            Assert.Single(request.Parameters);
            Assert.Equal(nameof(AddObjectTestClassSerializeConverter.User), request.Parameters[0].Name);
            Assert.Equal(0.ToString(), request.Parameters[0].Value);
        }
    }

    internal sealed class AddObjectTestClassNullSerializeAs
    {
        [Field(SerializeAs = null)]
        public string TestProperty { get; set; }
    }

    internal sealed class AddObjectTestClassIsRequired
    {
        [Field(SerializeAs = nameof(TestProperty), IsRequired = true)]
        public string TestProperty { get; set; }
    }

    internal sealed class AddObjectTestClassSerializeConverter
    {
        [Field(SerializeAs = nameof(User), Converter = FieldConverter.CommonModelConverter)]
        public User User { get; set; }
    }
}
