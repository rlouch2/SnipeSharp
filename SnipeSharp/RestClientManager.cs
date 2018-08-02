using RestSharp;
using RestSharp.Authenticators;
using SnipeSharp.EndPoint.Filters;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.Exceptions;
using SnipeSharp.Serialization;

namespace SnipeSharp
{
    internal sealed class RestClientManager
    {
        private readonly SnipeItApi api;
        private readonly IRestClient client;

        private readonly NewtonsoftJsonSerializer serializerDeserializer = new NewtonsoftJsonSerializer();

        internal RestClientManager(SnipeItApi api): this(api, new RestClient())
        {
            client.AddDefaultHeader("Accept", "application/json");
            client.AddDefaultHeader("Cache-Control", "no-cache");
        }

        internal RestClientManager(SnipeItApi api, IRestClient client)
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

        internal void ResetToken()
            => client.Authenticator = null;
        internal void ResetUri()
            => client.BaseUrl = null;

        internal string GetRaw(string path)
        {
            var response = client.Execute(new RestRequest(path, Method.GET) { JsonSerializer = serializerDeserializer });
            if(!response.IsSuccessful)
                throw new ApiErrorException(response.StatusCode, response.Content);
            return response.Content;
        }

        internal R Get<R>(string path, ISearchFilter filter = null) where R: ApiObject
        {
            var request = new RestRequest(path, Method.GET) { JsonSerializer = serializerDeserializer };
            if(!(filter is null))
                request.AddJsonBody(filter);
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
                    result.AddRange(batch.Rows);
                    filter.Offset += 1000;
                }
            }
            return result;
        }

        internal RequestResponse<R> Post<R>(string path, R @object) where R: ApiObject
            => Post<R, R>(path, @object);
        
        internal RequestResponse<R> Post<T, R>(string path, T @object) where T: ApiObject where R: ApiObject
        {
            var request = new RestRequest(path, Method.POST) { JsonSerializer = serializerDeserializer };
            if(@object != null)
                request.AddJsonBody(@object);
            return ExecuteRequest2<R>(request);
        }

        internal RequestResponse<R> Patch<R>(string path, R @object) where R: ApiObject
        {
            var request = new RestRequest(path, Method.PATCH) { JsonSerializer = serializerDeserializer };
            if(@object != null)
                request.AddJsonBody(@object);
            return ExecuteRequest2<R>(request);
        }

        internal RequestResponse<R> Delete<R>(string path) where R: ApiObject
            => ExecuteRequest2<R>(new RestRequest(path, Method.DELETE) { JsonSerializer = serializerDeserializer });

        private R ExecuteRequest<R>(RestRequest request) where R: ApiObject
        {
            SetTokenAndUri();
            var response = client.Execute(request);
            if(!response.IsSuccessful)
                throw new ApiErrorException(response.StatusCode, response.Content);
            var asRequestResponse = serializerDeserializer.Deserialize<RequestResponse<R>>(response);
            // Check if this is actually a RequestResponse
            if(!string.IsNullOrWhiteSpace(asRequestResponse.Status))
            {
                // It is, do stuff
                if(asRequestResponse.Status == "error")
                {
                    if(asRequestResponse.Messages.ContainsKey("general"))
                        throw new ApiErrorException(asRequestResponse.Messages["general"]);
                    else
                        throw new ApiErrorException(asRequestResponse.Messages);
                }
            }
            return serializerDeserializer.Deserialize<R>(response);
        }
        private RequestResponse<R> ExecuteRequest2<R>(RestRequest request) where R: ApiObject
        {
            SetTokenAndUri();
            var response = client.Execute(request);
            if(!response.IsSuccessful)
                throw new ApiErrorException(response.StatusCode, response.Content);
            var asRequestResponse = serializerDeserializer.Deserialize<RequestResponse<R>>(response);
            // Check if this is actually a RequestResponse
            if(!string.IsNullOrWhiteSpace(asRequestResponse.Status))
            {
                // It is, do stuff
                if(asRequestResponse.Status == "error")
                {
                    if(asRequestResponse.Messages.ContainsKey("general"))
                        throw new ApiErrorException(asRequestResponse.Messages["general"]);
                    else
                        throw new ApiErrorException(asRequestResponse.Messages);
                }
            }
            return asRequestResponse;
        }

        public string Serialize(object @object)
            => serializerDeserializer.Serialize(@object);
    }
}
