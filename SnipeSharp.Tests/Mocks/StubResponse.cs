using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace SnipeSharp.Tests
{
    internal class StubResponse : IRestResponse
    {
        public StubResponse(string content, bool isSuccessful = true)
        {
            Content = content;
            IsSuccessful = isSuccessful;
        }
        public IRestRequest Request { get; set; }
        public string ContentType { get; set; }
        public long ContentLength { get; set; }
        public string ContentEncoding { get; set; }
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public string StatusDescription { get; set; }
        public byte[] RawBytes { get; set; }
        public Uri ResponseUri { get; set; }
        public string Server { get; set; }
        public IList<RestResponseCookie> Cookies => throw new NotImplementedException();
        public IList<Parameter> Headers => throw new NotImplementedException();
        public ResponseStatus ResponseStatus { get; set; }
        public string ErrorMessage { get; set; }
        public Exception ErrorException { get; set; }
        public Version ProtocolVersion { get; set; }
    }
}
