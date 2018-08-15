using RestSharp;
using RestSharp.Authenticators;
using SnipeSharp.EndPoint.Filters;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.Exceptions;
using SnipeSharp.Serialization;
using Newtonsoft.Json;

using System.Reflection;

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
            client.AddDefaultHeader("Content-type", "application/json");
        }

        internal RestClientManager(SnipeItApi api, IRestClient client)
        {
            this.api = api;
            this.client = client;
        }

        internal void SetTokenAndUri()
        {
            if(api.Uri is null)
                throw new NullApiUriException();
            if(api.Token is null)
                throw new NullApiTokenException();
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
            var response = client.Execute(new RestRequest(path));
            if(!response.IsSuccessful)
                throw new ApiErrorException(response.StatusCode, response.Content);
            return response.Content;
        }

        internal R Get<R>(string path, ISearchFilter filter = null) where R: ApiObject
            => ExecuteRequest<R>(CreateRequest(path, Method.GET).Add(filter));

        internal ResponseCollection<R> GetAll<R>(string path, ISearchFilter filter = null) where R: ApiObject
        {
            var result = Get<ResponseCollection<R>>(path, filter);
            var offset = filter?.Offset is null ? 0 : filter.Offset;
            if(filter?.Limit is null && offset + result.Count < result.Total)
            {
                if(filter is null)
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
            => ExecuteRequest2<R>(CreateRequest(path, Method.POST).Add(@object));

        internal RequestResponse<R> Patch<R>(string path, R @object) where R: ApiObject
            => ExecuteRequest2<R>(CreateRequest(path, Method.PATCH).Add(@object));

        internal RequestResponse<R> Delete<R>(string path) where R: ApiObject
            => ExecuteRequest2<R>(CreateRequest(path, Method.DELETE));

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

        private RestRequest CreateRequest(string path, Method method)
            => new RestRequest(path, method)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = serializerDeserializer
            };
    }

    internal static class RestRequestExtensions
    {
        internal static RestRequest Add(this RestRequest request, object @object)
        {
            if(!(@object is null))
            {
                if(request.Method == Method.GET)
                {
                    var type = @object.GetType();
                    foreach(var property in type.GetProperties())
                    {
                        if(property.GetCustomAttribute<FieldAttribute>(true) is FieldAttribute attribute && attribute.ShouldSerialize)
                        {
                            var value = property.GetValue(@object);
                            if(attribute.IsRequired && value is null)
                                throw new MissingRequiredFieldException<object>(type.Name, property.Name);
                            else
                                request.AddParameter(attribute.SerializeAs, property.GetValue(@object));
                        }
                    }
                } else
                {
                    request.AddBody(@object);
                }
            }
            return request;
        }
    }
}
