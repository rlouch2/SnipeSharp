using System;
using System.Collections.Generic;
using System.IO;
using RestSharp;
using RestSharp.Authenticators;
using SnipeSharp.EndPoint;
using SnipeSharp.EndPoint.Filters;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.Exceptions;
using SnipeSharp.Serialization;

namespace SnipeSharp
{
    public sealed class SnipeItApiv2
    {
        private string _token;
        public string Token
        {
            get => _token;
            set
            {
                _token = value;
                RequestManager.ResetToken();
            }
        }

        private Uri _uri;
        public Uri Uri
        {
            get => _uri;
            set
            {
                _uri = value;
                RequestManager.ResetUri();
            }
        }

        internal readonly RestClientManager RequestManager;

        private Dictionary<Type, object> endpoints = new Dictionary<Type, object>();

        public IEndPoint<T> GetEndPoint<T>() where T: CommonEndPointModel
        {
            var type = typeof(T);
            if(!endpoints.ContainsKey(type))
                endpoints[type] = new EndPoint<T>(this);
            return endpoints[type] as IEndPoint<T>;
        }

        public IEndPoint<Accessory> Accessories => GetEndPoint<Accessory>();

        public SnipeItApiv2()
        {
            RequestManager = new RestClientManager(this);
        }

        internal SnipeItApiv2(IRestClient client)
        {
            RequestManager = new RestClientManager(this, client);
        }
    }

    internal sealed class RestClientManager
    {
        private readonly SnipeItApiv2 api;
        private readonly IRestClient client;

        private readonly NewtonsoftJsonSerializer serializerDeserializer = new NewtonsoftJsonSerializer();

        internal RestClientManager(SnipeItApiv2 api): this(api, new RestClient())
        {
            client.AddDefaultHeader("Accept", "application/json");
        }

        internal RestClientManager(SnipeItApiv2 api, IRestClient client)
        {
            this.api = api;
            this.client = client;
        }

        internal void SetTokenAndUri()
        {
            if(api.Uri is null)
                throw new NullApiBaseUrlException("No API Uri set.");
            if(api.Token is null)
                throw new NullApiTokenException("No API Token set.");
            if(client.BaseUrl is null)
                client.BaseUrl = api.Uri;
            if(client.Authenticator is null)
                client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(api.Token, "Bearer");
        }

        internal void ResetToken() => client.Authenticator = null;
        internal void ResetUri() => client.BaseUrl = null;

        internal string GetRaw(string path)
        {
            var response = client.Execute(new RestRequest(path, Method.GET));
            if(!response.IsSuccessful)
            {
                // TODO: error
            }
            return response.Content;
        }

        internal R Get<R>(string path, ISearchFilter filter = null) where R: ApiObject
        {
            var request = new RestRequest(path, Method.GET);
            if(!(filter is null))
                request.AddObject(filter);
            return ExecuteRequest<R>(request);
        }

        internal ResponseCollection<R> GetAll<R>(string path, ISearchFilter filter = null) where R: ApiObject
        {
            var result = Get<ResponseCollection<R>>(path, filter);
            var offset = filter?.Offset == null ? 0 : filter.Offset;
            if(filter?.Limit == null && offset + result.Count < result.Total)
            {
                if(filter == null)
                    filter = new SearchFilter();
                filter.Limit = 1000;
                filter.Offset = offset + result.Count;
                while(offset + result.Count < result.Total)
                {
                    var batch = Get<ResponseCollection<R>>(path, filter);
                    result.AddRange(batch);
                    filter.Offset += 1000;
                }
            }
            return result;
        }

        internal RequestResponse Post<T>(string path, T @object) where T: ApiObject
        {
            return null; //TODO
        }

        private R ExecuteRequest<R>(RestRequest request) where R: ApiObject
        {
            SetTokenAndUri();
            var response = client.Execute(request);
            if(!response.IsSuccessful)
            {
                // TODO: error
            }
            var asRequestResponse = serializerDeserializer.Deserialize<RequestResponse>(response);
            // Check if this is actually a RequestResponse
            if(!string.IsNullOrWhiteSpace(asRequestResponse.Status))
            {
                // It is, do stuff
                // TODO: error handling/etc
            }
            return serializerDeserializer.Deserialize<R>(response);
        }
    }
}
