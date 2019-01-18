using RestSharp;
using RestSharp.Authenticators;
using SnipeSharp.Filters;
using SnipeSharp.Models;
using SnipeSharp.Exceptions;
using SnipeSharp.Serialization;
using Newtonsoft.Json;

using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace SnipeSharp
{
    internal sealed class RestClientManager
    {
        private readonly SnipeItApi Api;
        private readonly IRestClient Client;

        private readonly NewtonsoftJsonSerializer serializerDeserializer = new NewtonsoftJsonSerializer();

        internal RestClientManager(SnipeItApi api)
        {
            this.Api = api;
            this.Client = Utility.Instance.NewRestClient();

            Client.AddDefaultHeader("Accept", "application/json");
            Client.AddDefaultHeader("Cache-Control", "no-cache");
            Client.AddDefaultHeader("Content-type", "application/json");
        }

        internal void SetTokenAndUri()
        {
            if(Api.Uri is null)
                throw new NullApiUriException();
            if(Api.Token is null)
                throw new NullApiTokenException();
            if(Client.BaseUrl is null)
                Client.BaseUrl = Api.Uri;
            if(Client.Authenticator is null)
                Client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(Api.Token, "Bearer");
        }

        internal void ResetToken()
            => Client.Authenticator = null;
        internal void ResetUri()
            => Client.BaseUrl = null;

        internal string GetRaw(string path)
        {
            var response = Client.Execute(new RestRequest(path));
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
            var uri = Client.BuildUri(request);
            Api.DebugList.Add(uri.ToString());
            var response = Client.Execute(request);
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
            var uri = Client.BuildUri(request);
            Api.DebugList.Add(uri.ToString());
            var response = Client.Execute(request);
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
                        if(property.GetCustomAttribute<FieldAttribute>(true) is FieldAttribute attribute && !string.IsNullOrEmpty(attribute.SerializeAs))
                        {
                            var value = property.GetValue(@object);
                            if(attribute.IsRequired && value is null)
                            {
                                throw new MissingRequiredFieldException<object>(type.Name, property.Name);
                            } else
                            {
                                var converter = SerializationContractResolver.GetConverter(attribute);
                                if(converter != null && value != null)
                                {
                                    var stringBuilder = new StringBuilder();
                                    using(var stringWriter = new StringWriter(stringBuilder))
                                    using(var jsonWriter = new JsonTextWriter(stringWriter))
                                    {
                                        converter.WriteJson(jsonWriter, value, JsonSerializer.CreateDefault(NewtonsoftJsonSerializer.SerializerSettings));
                                    }
                                    value = stringBuilder.ToString();
                                    if(string.IsNullOrEmpty((string) value) && attribute.IsRequired)
                                    {
                                        throw new MissingRequiredFieldException<object>(nameof(String), property.Name);
                                    }
                                }
                                if(value != null)
                                    request.AddParameter(attribute.SerializeAs, value);
                            }
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
