using System;
using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Endpoints.SearchFilters;
using RestSharp;
using RestSharp.Authenticators;
using SnipeSharp.Exceptions;
using Newtonsoft.Json;

namespace SnipeSharp.Common
{
    class RequestManager : IRequestManager
    {

        internal readonly SnipeItApi Api;
        internal readonly RestClient Client;

        public RequestManager(SnipeItApi api)
        {
            Api = api;
            Client = new RestClient();
            Client.AddDefaultHeader("Accept", "application/json");
        }

        public string Delete(string path)
        {
            CheckApiTokenAndUrl();
            var res = Client.Execute(new RestRequest(Method.DELETE) {
                Resource = path
            });

            return res.Content;
        }

        public string Get(string path)
        {
            CheckApiTokenAndUrl();
            var res = Client.Execute(new RestRequest {
                Resource = path,
                Timeout = 20000
            });

            return res.Content;
        }

        public string Get(string path, IQueryParameterProvider filter)
        {
            CheckApiTokenAndUrl();
            var req = new RestRequest {
                Resource = path,
                Timeout = 20000
            };
            foreach (var kvp in filter.QueryParameters)
            {
                req.AddParameter(kvp.Key, kvp.Value);
            }

            var res = Client.Execute(req);

            return res.Content;
        }

        public string Post(string path, IQueryParameterProvider item)
        {
            CheckApiTokenAndUrl();
            var req = new RestRequest(Method.POST) {
                Resource = path
            };

            foreach (var kvp in item.QueryParameters)
            {
                req.AddParameter(kvp.Key, kvp.Value);
            }
            var res = Client.Execute(req);

            return res.Content;
        }

        public string Put(string path, IQueryParameterProvider item)
        {
            // TODO: Make one method for post and put.
            CheckApiTokenAndUrl();
            var req = new RestRequest(Method.PUT) {
                Resource = path
            };

            foreach (var kvp in item.QueryParameters)
            {
                req.AddParameter(kvp.Key, kvp.Value);
            }
            // TODO: Add  error checking
            var res = Client.Execute(req);

            return res.Content;
        }

        // Since the Token and URL can be set anytime after the SnipApi object is created we need to check for these before sending a request
        public void CheckApiTokenAndUrl()
        {
            if (Api.ApiSettings.BaseUrl == null)
            {
                throw new NullApiBaseUrlException("No API Base Url Set.");
            }

            if (Api.ApiSettings.ApiToken == null)
            {
                throw new NullApiTokenException("No API Token Set");
            }

            if (Client.BaseUrl == null)
            {
                Client.BaseUrl = Api.ApiSettings.BaseUrl;
            }

            if (Client.Authenticator == null)
            {
                Client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(Api.ApiSettings.ApiToken, "Bearer");
            }
        }
    }
}
