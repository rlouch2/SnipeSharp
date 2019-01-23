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

        internal ApiOptionalResponse<R> Get<R>(string path, ISearchFilter filter = null) where R: ApiObject
            => ExecuteRequest<R>(CreateRequest(path, Method.GET).Add(filter));

        internal ApiOptionalResponse<ResponseCollection<R>> GetAll<R>(string path, ISearchFilter filter = null) where R: ApiObject
        {
            var result = Get<ResponseCollection<R>>(path, filter);
            if(result.HasValue)
                return result;
            var offset = filter?.Offset is null ? 0 : filter.Offset;
            if(filter?.Limit is null && offset + result.Value.Count < result.Value.Total)
            {
                if(filter is null)
                    filter = new SearchFilter();
                filter.Limit = 1000;
                filter.Offset = offset + result.Value.Count;
                while(offset + result.Value.Count < result.Value.Total)
                {
                    var batch = Get<ResponseCollection<R>>(path, filter);
                    if(!batch.HasValue)
                        return batch;
                    result.Value.AddRange(batch.Value.Rows);
                    filter.Offset += 1000;
                }
            }
            return result;
        }

        internal ApiOptionalResponse<RequestResponse<R>> Post<R>(string path, R @object) where R: ApiObject
            => Post<R, R>(path, @object);
        
        internal ApiOptionalResponse<RequestResponse<R>> Post<T, R>(string path, T @object) where T: ApiObject where R: ApiObject
            => ExecuteRequest2<R>(CreateRequest(path, Method.POST).Add(@object));

        internal ApiOptionalResponse<RequestResponse<R>> Patch<R>(string path, R @object) where R: ApiObject
            => ExecuteRequest2<R>(CreateRequest(path, Method.PATCH).Add(@object));

        internal ApiOptionalResponse<RequestResponse<R>> Delete<R>(string path) where R: ApiObject
            => ExecuteRequest2<R>(CreateRequest(path, Method.DELETE));

        private ApiOptionalResponse<R> ExecuteRequest<R>(RestRequest request)
            where R: ApiObject
        {
            SetTokenAndUri();
#if DEBUG
            var uri = Client.BuildUri(request);
            Api.DebugList.Add(uri.ToString());
#endif
            var response = Client.Execute(request);
            if(!response.IsSuccessful)
                throw new ApiErrorException(response.StatusCode, response.Content);
#if DEBUG
            Api.DebugResponseList.Add(response);
#endif
            var asRequestResponse = serializerDeserializer.Deserialize<RequestResponse<R>>(response);
            
            if(!string.IsNullOrWhiteSpace(asRequestResponse.Status) && asRequestResponse.Status == "error")
            {
                return new ApiOptionalResponse<R>
                {
                    Exception = asRequestResponse.Messages.ContainsKey("general")
                        ? new ApiErrorException(asRequestResponse.Messages["general"])
                        : new ApiErrorException(asRequestResponse.Messages)
                };
            }

            return new ApiOptionalResponse<R> { Value = serializerDeserializer.Deserialize<R>(response) };
        }

        private ApiOptionalResponse<RequestResponse<R>> ExecuteRequest2<R>(RestRequest request)
            where R: ApiObject
        {
            SetTokenAndUri();
#if DEBUG
            var uri = Client.BuildUri(request);
            Api.DebugList.Add(uri.ToString());
#endif
            var response = Client.Execute(request);
            if(!response.IsSuccessful)
                throw new ApiErrorException(response.StatusCode, response.Content);
#if DEBUG
            Api.DebugResponseList.Add(response);
#endif
            var asRequestResponse = serializerDeserializer.Deserialize<RequestResponse<R>>(response);
            
            if(!string.IsNullOrWhiteSpace(asRequestResponse.Status) && asRequestResponse.Status == "error")
            {
                return new ApiOptionalResponse<RequestResponse<R>>
                {
                    Exception = asRequestResponse.Messages.ContainsKey("general")
                        ? new ApiErrorException(asRequestResponse.Messages["general"])
                        : new ApiErrorException(asRequestResponse.Messages)
                };
            }
            return new ApiOptionalResponse<RequestResponse<R>> { Value = asRequestResponse };
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
