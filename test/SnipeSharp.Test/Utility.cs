using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Moq;
using RestSharp;
using RestSharp.Authenticators;

#nullable enable
namespace SnipeSharp.Test
{
    internal static class Utility
    {
        internal static string TEST_URI_STRING { get; } = Environment.GetEnvironmentVariable("SnipeSharp_TestSite") ?? throw new Exception("Could not find environment variable SnipeSharp_TestSite.");
        internal static string TEST_TOKEN { get; } = Environment.GetEnvironmentVariable("SnipeSharp_TestToken") ?? throw new Exception("Could not find environment variable SnipeSharp_TestToken.");
        internal static Uri TEST_URI { get; } = new Uri(TEST_URI_STRING);

        internal static IRestClient MockClientFor(string response, bool isSuccessful = true, HttpStatusCode? statusCode = null)
        {
            var mockResponse = new Mock<IRestResponse>();
            mockResponse.Setup(_ => _.Content).Returns(response);
            mockResponse.Setup(_ => _.IsSuccessful).Returns(isSuccessful);
            if(statusCode.HasValue)
                mockResponse.Setup(_ => _.StatusCode).Returns(statusCode.Value);
            var mockClient = new Mock<IRestClient>(MockBehavior.Loose);
            mockClient
                .Setup(_ => _.Execute(It.IsAny<IRestRequest>()))
                .Returns(mockResponse.Object);
            // need to do this too because we set default parameters in the constructor for RestSharpClient
            var defaultHeadersList = new List<Parameter>();
            mockClient
                .Setup(_ => _.DefaultParameters)
                .Returns(defaultHeadersList);
            // and also these because we want everything to think the request is valid
            var mockAuthenticator = new Mock<IAuthenticator>();
            mockClient.Setup(_ => _.Authenticator).Returns(mockAuthenticator.Object);
            mockClient.Setup(_ => _.BaseUrl).Returns(TEST_URI);
            return mockClient.Object;
        }

        internal static IRestClient MockClientFor(out MockResponseQueue queue)
        {
            queue = new MockResponseQueue();
            var mockClient = new Mock<IRestClient>(MockBehavior.Loose);
            mockClient
                .Setup(_ => _.Execute(It.IsAny<IRestRequest>()))
                .Returns(queue.Dequeue);
            // need to do this too because we set default parameters in the constructor for RestSharpClient
            var defaultHeadersList = new List<Parameter>();
            mockClient
                .Setup(_ => _.DefaultParameters)
                .Returns(defaultHeadersList);
            // and also these because we want everything to think the request is valid
            var mockAuthenticator = new Mock<IAuthenticator>();
            mockClient.Setup(_ => _.Authenticator).Returns(mockAuthenticator.Object);
            mockClient.Setup(_ => _.BaseUrl).Returns(TEST_URI);
            return mockClient.Object;
        }
    }

    internal sealed class MockResponseQueue: IEnumerable<IRestResponse>
    {
        private Queue<IRestResponse> internalQueue = new Queue<IRestResponse>();
        internal MockResponseQueue Enqueue(string response, bool isSuccessful = true, HttpStatusCode? statusCode = null)
        {
            var mockResponse = new Mock<IRestResponse>();
            mockResponse.Setup(_ => _.Content).Returns(response);
            mockResponse.Setup(_ => _.IsSuccessful).Returns(isSuccessful);
            if(statusCode.HasValue)
                mockResponse.Setup(_ => _.StatusCode).Returns(statusCode.Value);
            internalQueue.Enqueue(mockResponse.Object);
            return this;
        }

        internal IRestResponse Dequeue() => internalQueue.Dequeue();

        public IEnumerator<IRestResponse> GetEnumerator() => ((IEnumerable<IRestResponse>)internalQueue).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)internalQueue).GetEnumerator();
    }
}
