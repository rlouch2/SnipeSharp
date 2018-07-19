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
    class RequestManagerRestSharp : IRequestManager
    {

        public ApiSettings _apiSettings { get; set; }
        static RestClient Client;

        public RequestManagerRestSharp(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
            Client = new RestClient();
            Client.AddDefaultHeader("Accept", "application/json");

        }

        public string Delete(string path)
        {
            CheckApiTokenAndUrl();
            var req = new RestRequest(Method.DELETE); 
            req.Resource = path;
            var res = Client.Execute(req);

            return res.Content;
        }

        public string Get(string path)
        {
            CheckApiTokenAndUrl();
            var req = new RestRequest();
            req.Resource = path; // Test
            req.Timeout = 200000;
            var res = Client.Execute(req);

            return res.Content;
        }

        public string Get(string path, ISearchFilter filter)
        {
            CheckApiTokenAndUrl();
            var req = new RestRequest();
            req.Resource = path;
            req.Timeout = 200000; // TODO: We should probably breakup large requests
            foreach (KeyValuePair<string, string> kvp in filter.GetQueryString())
            {
                req.AddParameter(kvp.Key, kvp.Value);
            }

            var res = Client.Execute(req);

            return res.Content;
        }

        public string Post(string path, ICommonEndpointModel item)
        {
            CheckApiTokenAndUrl();
            var req = new RestRequest(Method.POST);
            req.Resource = path;

            var parameters = item.BuildQueryString();

            foreach (KeyValuePair<string, string> kvp in parameters)
            {
                req.AddParameter(kvp.Key, kvp.Value);
            }
            // TODO: Add error checking
            var res = Client.Execute(req);

            return res.Content;
        }

        public string Put(string path, ICommonEndpointModel item)
        {
            // TODO: Make one method for post and put.
            CheckApiTokenAndUrl();
            var req = new RestRequest(Method.PUT);
            req.Resource = path;

            var parameters = item.BuildQueryString();

            foreach (KeyValuePair<string, string> kvp in parameters)
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
            if (_apiSettings.BaseUrl == null)
            {
                throw new NullApiBaseUrlException("No API Base Url Set.");
            }

            if (_apiSettings.ApiToken == null)
            {
                throw new NullApiTokenException("No API Token Set");
            }

            if (Client.BaseUrl == null)
            {
                Client.BaseUrl = _apiSettings.BaseUrl;
            }

            if (Client.Authenticator == null)
            {
                Client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(_apiSettings.ApiToken, "Bearer");
            }
        }
    }
}
