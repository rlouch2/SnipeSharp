using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Cache;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;

namespace SnipeSharp.Tests
{
    internal class StubRestClient : IRestClient
    {
        public CookieContainer CookieContainer { get; set; } = new CookieContainer();
        public bool AutomaticDecompression { get; set; } = false;
        public int? MaxRedirects { get; set; }
        public string UserAgent { get; set; } = "StubRestClient";
        public int Timeout { get; set; } = 0;
        public int ReadWriteTimeout { get; set; } = 0;
        public bool UseSynchronizationContext { get; set; } = false;
        public IAuthenticator Authenticator { get; set; }
        public Uri BaseUrl { get; set; }
        public Encoding Encoding { get; set; }
        public bool PreAuthenticate { get; set; } = false;
        public IList<Parameter> DefaultParameters => throw new NotImplementedException();
        public string BaseHost { get; set; }
        public X509CertificateCollection ClientCertificates { get; set; }
        public IWebProxy Proxy { get; set; }
        public RequestCachePolicy CachePolicy { get; set; }
        public bool Pipelined { get; set; } = false;
        public bool FollowRedirects { get; set; } = false;
        public RemoteCertificateValidationCallback RemoteCertificateValidationCallback { get; set; }

        public StubResponse Response { get; set; }

        public void AddHandler(string contentType, IDeserializer deserializer)
            => throw new NotImplementedException();

        public Uri BuildUri(IRestRequest request)
            => throw new NotImplementedException();

        public void ClearHandlers()
            => throw new NotImplementedException();

        public IRestResponse<T> Deserialize<T>(IRestResponse response)
            => throw new NotImplementedException();

        public byte[] DownloadData(IRestRequest request)
            => throw new NotImplementedException();

        public IRestResponse Execute(IRestRequest request)
            => Response;

        public IRestResponse<T> Execute<T>(IRestRequest request) where T : new()
            => throw new NotImplementedException();

        public IRestResponse ExecuteAsGet(IRestRequest request, string httpMethod)
            => throw new NotImplementedException();

        public IRestResponse<T> ExecuteAsGet<T>(IRestRequest request, string httpMethod) where T : new()
            => throw new NotImplementedException();

        public IRestResponse ExecuteAsPost(IRestRequest request, string httpMethod)
            => throw new NotImplementedException();

        public IRestResponse<T> ExecuteAsPost<T>(IRestRequest request, string httpMethod) where T : new()
            => throw new NotImplementedException();

        public RestRequestAsyncHandle ExecuteAsync(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
            => throw new NotImplementedException();

        public RestRequestAsyncHandle ExecuteAsync<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback)
            => throw new NotImplementedException();

        public RestRequestAsyncHandle ExecuteAsyncGet(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, string httpMethod)
            => throw new NotImplementedException();

        public RestRequestAsyncHandle ExecuteAsyncGet<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, string httpMethod)
            => throw new NotImplementedException();

        public RestRequestAsyncHandle ExecuteAsyncPost(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, string httpMethod)
            => throw new NotImplementedException();

        public RestRequestAsyncHandle ExecuteAsyncPost<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, string httpMethod)
            => throw new NotImplementedException();

        public Task<IRestResponse<T>> ExecuteGetTaskAsync<T>(IRestRequest request)
            => throw new NotImplementedException();

        public Task<IRestResponse<T>> ExecuteGetTaskAsync<T>(IRestRequest request, CancellationToken token)
            => throw new NotImplementedException();

        public Task<IRestResponse> ExecuteGetTaskAsync(IRestRequest request)
            => throw new NotImplementedException();

        public Task<IRestResponse> ExecuteGetTaskAsync(IRestRequest request, CancellationToken token)
            => throw new NotImplementedException();

        public Task<IRestResponse<T>> ExecutePostTaskAsync<T>(IRestRequest request)
            => throw new NotImplementedException();

        public Task<IRestResponse<T>> ExecutePostTaskAsync<T>(IRestRequest request, CancellationToken token)
            => throw new NotImplementedException();
        public Task<IRestResponse> ExecutePostTaskAsync(IRestRequest request)
            => throw new NotImplementedException();

        public Task<IRestResponse> ExecutePostTaskAsync(IRestRequest request, CancellationToken token)
            => throw new NotImplementedException();

        public Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request, CancellationToken token)
            => throw new NotImplementedException();

        public Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request)
            => throw new NotImplementedException();

        public Task<IRestResponse> ExecuteTaskAsync(IRestRequest request, CancellationToken token)
            => throw new NotImplementedException();
        public Task<IRestResponse> ExecuteTaskAsync(IRestRequest request)
            => throw new NotImplementedException();

        public void RemoveHandler(string contentType)
            => throw new NotImplementedException();
    }
}