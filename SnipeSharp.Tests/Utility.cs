using System;
using System.IO;
using System.Net;
using RestSharp;

namespace SnipeSharp.Tests
{
    internal static class Utility
    {
        internal static SnipeItApi OneUseApi(string responsePath, bool isSuccessful = true, HttpStatusCode? statusCode = null)
        {
            var client = new StubRestClient();
            client.Responses.Enqueue(new StubResponse(File.ReadAllText(responsePath), isSuccessful, statusCode));
            return NewApi(client);
        }
        internal static SnipeItApi NewApi(IRestClient client = null, string token = "xxxx", string uri = "http://localhost/api/v1")
            => new SnipeItApi(client ?? NewRestClient())
            {
                Token = token,
                Uri = new Uri(uri)
            };
        internal static StubRestClient NewRestClient()
            => new StubRestClient();
    }
}
