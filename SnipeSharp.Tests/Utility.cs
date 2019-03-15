using RestSharp;
using System;
using System.IO;
using System.Net;
using SnipeSharp.Tests.Mock;

namespace SnipeSharp.Tests
{
    internal static class Utility
    {
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
