using RestSharp;
using System;
using System.IO;
using System.Net;
using SnipeSharp.Tests.Mock;

namespace SnipeSharp.Tests
{
    internal static class Utility
    {
        internal static void ReplaceSnipeSharpUtility()
        {
            if(!(SnipeSharp.Utility.Instance is Mock.FakeUtility))
                SnipeSharp.Utility.Instance = new Mock.FakeUtility();
        }
        internal static void ResetSnipeSharpUtility()
        {
            SnipeSharp.Utility.Instance = new SnipeSharp.Utility();
        }
        internal static void QueueResponse(string content, bool isSuccessful = true, HttpStatusCode? statusCode = null)
        {
            ReplaceSnipeSharpUtility();
            ((Mock.FakeUtility) SnipeSharp.Utility.Instance).RestClient.Responses.Enqueue(new FakeResponse(content, isSuccessful, statusCode));
        }
        internal static void QueueResponseFromFile(string path, bool isSuccessful = true, HttpStatusCode? statusCode = null)
            => QueueResponse(path is null ? "" : File.ReadAllText(path), isSuccessful, statusCode);
        internal static void ResetQueue()
        {
            ReplaceSnipeSharpUtility();
            ((Mock.FakeUtility) SnipeSharp.Utility.Instance).RestClient.Responses.Clear();
        }
        internal static SnipeItApi OneUseApi(string responsePath = null, bool isSuccessful = true, HttpStatusCode? statusCode = null)
        {
            ReplaceSnipeSharpUtility();
            ResetQueue();
            QueueResponseFromFile(responsePath);
            return new SnipeItApi { Token = "xxxx", Uri = new Uri("http://localhost/api/v1") };
        }
    }
}
