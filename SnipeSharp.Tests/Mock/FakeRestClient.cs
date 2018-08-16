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

namespace SnipeSharp.Tests.Mock
{
    internal class FakeRestClient : IRestClient
    {
        internal readonly Queue<IRestResponse> Responses = new Queue<IRestResponse>();

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
        public IList<Parameter> DefaultParameters { get; } = new List<Parameter>();
        public string BaseHost { get; set; }
        public X509CertificateCollection ClientCertificates { get; set; }
        public IWebProxy Proxy { get; set; }
        public RequestCachePolicy CachePolicy { get; set; }
        public bool Pipelined { get; set; } = false;
        public bool FollowRedirects { get; set; } = false;
        public RemoteCertificateValidationCallback RemoteCertificateValidationCallback { get; set; }

        public IRestResponse Response { get => Responses.Dequeue(); set {} }
        public string ConnectionGroupName { get; set; }
        public bool UnsafeAuthenticatedConnectionSharing { get; set; }
        public bool AllowMultipleDefaultParametersWithSameName { get; set; }

        public void AddHandler(string contentType, IDeserializer deserializer)
        {
        }

        public Uri BuildUri(IRestRequest request)
            => null;

        public void ClearHandlers()
        {
        }

        public void ConfigureWebRequest(Action<HttpWebRequest> configurator)
        {
        }

        public IRestResponse<T> Deserialize<T>(IRestResponse response)
            => null;

        public byte[] DownloadData(IRestRequest request)
            => null;

        public byte[] DownloadData(IRestRequest request, bool throwOnError)
            => null;

        public IRestResponse Execute(IRestRequest request)
            => Response;

        public IRestResponse<T> Execute<T>(IRestRequest request) where T : new()
            => null;

        public IRestResponse ExecuteAsGet(IRestRequest request, string httpMethod)
            => null;

        public IRestResponse<T> ExecuteAsGet<T>(IRestRequest request, string httpMethod) where T : new()
            => null;

        public IRestResponse ExecuteAsPost(IRestRequest request, string httpMethod)
            => null;

        public IRestResponse<T> ExecuteAsPost<T>(IRestRequest request, string httpMethod) where T : new()
            => null;

        public RestRequestAsyncHandle ExecuteAsync(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
            => null;

        public RestRequestAsyncHandle ExecuteAsync<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback)
            => null;

        public RestRequestAsyncHandle ExecuteAsyncGet(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, string httpMethod)
            => null;

        public RestRequestAsyncHandle ExecuteAsyncGet<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, string httpMethod)
            => null;

        public RestRequestAsyncHandle ExecuteAsyncPost(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, string httpMethod)
            => null;

        public RestRequestAsyncHandle ExecuteAsyncPost<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, string httpMethod)
            => null;

        public Task<IRestResponse<T>> ExecuteGetTaskAsync<T>(IRestRequest request)
            => null;

        public Task<IRestResponse<T>> ExecuteGetTaskAsync<T>(IRestRequest request, CancellationToken token)
            => null;

        public Task<IRestResponse> ExecuteGetTaskAsync(IRestRequest request)
            => null;

        public Task<IRestResponse> ExecuteGetTaskAsync(IRestRequest request, CancellationToken token)
            => null;

        public Task<IRestResponse<T>> ExecutePostTaskAsync<T>(IRestRequest request)
            => null;

        public Task<IRestResponse<T>> ExecutePostTaskAsync<T>(IRestRequest request, CancellationToken token)
            => null;
        public Task<IRestResponse> ExecutePostTaskAsync(IRestRequest request)
            => null;

        public Task<IRestResponse> ExecutePostTaskAsync(IRestRequest request, CancellationToken token)
            => null;

        public Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request, CancellationToken token)
            => null;

        public Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request)
            => null;

        public Task<IRestResponse> ExecuteTaskAsync(IRestRequest request, CancellationToken token)
            => null;
        public Task<IRestResponse> ExecuteTaskAsync(IRestRequest request)
            => null;

        public void RemoveHandler(string contentType)
        {
        }
    }
}
