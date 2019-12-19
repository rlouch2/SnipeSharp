using System;
using System.Net;

namespace SnipeSharp.Tests
{
    internal static class Utility
    {
        internal const string TEST_URI_STRING = "http://test.example.net";
        internal const string TEST_TOKEN = "xxxxx";
        internal static readonly Uri TEST_URI = new Uri(TEST_URI_STRING);

        internal static SnipeItApi SingleUseApi()
        {
            return new SnipeItApi(new FakeRestClient()) { Token = TEST_TOKEN, Uri = TEST_URI };
        }

        internal static SnipeItApi SingleUseApi(string response, bool isSuccessful = true, HttpStatusCode? statusCode = null)
        {
            var client = new FakeRestClient();
            client.Responses.Enqueue(new FakeResponse(response, isSuccessful, statusCode));
            return new SnipeItApi(restClient: client) { Token = TEST_TOKEN, Uri = TEST_URI };
        }

        internal static SnipeItApi SingleUseApiFromFile(string filePath, bool isSuccessful = true, HttpStatusCode? statusCode = null)
        {
            var client = new FakeRestClient();
            client.Responses.Enqueue(FakeResponse.FromFile(filePath, isSuccessful, statusCode));
            return new SnipeItApi(restClient: client) { Token = TEST_TOKEN, Uri = TEST_URI };
        }

        internal static SnipeItApi OneUseApi(string responsePath = null, bool isSuccessful = true, HttpStatusCode? statusCode = null)
        {
            var client = new FakeRestClient();
            client.Responses.Enqueue(FakeResponse.FromFile(responsePath, isSuccessful, statusCode));
            return new SnipeItApi(restClient: client) { Token = "xxxx", Uri = new Uri("http://localhost/api/v1") };
        }

        internal static (FakeRestClient, SnipeItApi) MultiUseApi()
        {
            var client = new FakeRestClient();
            return (client, new SnipeItApi(client) { Token = "xxxx", Uri = new Uri("http://localhost/api/v1") });
        }
    }
}
