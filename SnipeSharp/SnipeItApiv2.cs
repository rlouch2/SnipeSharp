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
    }

    internal sealed class RestClientManager
    {
        private readonly SnipeItApiv2 api;
        private readonly RestClient client;

        private readonly NewtonsoftJsonSerializer serializerDeserializer = new NewtonsoftJsonSerializer();

        internal RestClientManager(SnipeItApiv2 api)
        {
            this.api = api;
            client = new RestClient();
            client.AddDefaultHeader("Accept", "application/json");
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

        internal R Get<R>(string path, ISearchFilter filter = null) where R: ApiObject
        {
            var request = new RestRequest(path, Method.GET){
                JsonSerializer = serializerDeserializer
            };
            if(!(filter is null))
                request.AddObject(filter);
            return ExecuteRequest<R>(request);
        }

        internal RequestResponse Post<T>(string path, T @object) where T: ApiObject
        {
            return null; //TODO
        }

        private R ExecuteRequest<R>(RestRequest request) where R: ApiObject
        {
            SetTokenAndUri();
            var response = client.Execute<ApiObject>(request);
            if(response is RequestResponse)
            {
                // TODO: error handling/etc
            }
            return response as R;
        }
    }
}
