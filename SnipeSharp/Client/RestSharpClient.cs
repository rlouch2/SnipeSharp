using RestSharp;
using RestSharp.Authenticators;
using SnipeSharp.Filters;
using SnipeSharp.Models;
using SnipeSharp.Exceptions;
using SnipeSharp.Serialization;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Runtime.Serialization;
using System;

#nullable enable
namespace SnipeSharp.Client
{
    internal sealed class RestSharpClient: ISnipeItClient
    {
        private readonly IRestClient Client;

        private readonly NewtonsoftJsonSerializer serializerDeserializer = new NewtonsoftJsonSerializer();

        internal RestSharpClient(IRestClient client)
        {
            this.Client = client;

            Client.AddDefaultHeader("Accept", "application/json");
            Client.AddDefaultHeader("Cache-Control", "no-cache");
            Client.AddDefaultHeader("Content-type", "application/json");
        }

        private void TestUriAndToken()
        {
            if(!HasUri)
                throw new NullApiUriException();
            if(!HasToken)
                throw new NullApiTokenException();
        }

        public string Token { set => Client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(value ?? throw new NullApiTokenException(), "Bearer"); }
        public Uri Uri { set => Client.BaseUrl = value; }
        public bool HasToken => null != Client.Authenticator;
        public bool HasUri => null != Client.BaseUrl;

        public string GetRaw(string path)
        {
            TestUriAndToken();
            var response = Client.Execute(new RestRequest(path));
            if(!response.IsSuccessful)
                throw new ApiErrorException(response.StatusCode, response.Content);
            return response.Content;
        }

        public ApiOptionalResponse<R> Get<R>(string path, ISearchFilter? filter = null)
            where R: ApiObject
        {
            TestUriAndToken();
            var request = CreateRequest(path, Method.GET, filter);
            var response = Client.Execute(request);
            if(!response.IsSuccessful)
                throw new ApiErrorException(response.StatusCode, response.Content);
            var asRequestResponse = serializerDeserializer.Deserialize<RequestResponse<R>>(response);

            if("error" == asRequestResponse.Status)
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

        public ApiOptionalMultiResponse<R> GetMultiple<R>(string path, ISearchFilter? filter = null) where R: ApiObject
        {
            var result = Get<ResponseCollection<R>>(path, filter);
            // if we couldn't find a result, don't try to get more.
            if(!result.HasValue)
                return result;
            var offset = filter?.Offset ?? 0;

            if((null == filter?.Limit) && offset + result.Value.Count < result.Value.Total)
            {
                if(null == filter)
                    filter = new SearchFilter();
                filter.Limit = 1000;
                filter.Offset = offset + result.Value.Count;
                while(offset + result.Value.Count < result.Value.Total)
                {
                    var batch = Get<ResponseCollection<R>>(path, filter);
                    if(!batch.HasValue)
                        return batch;
                    if(0 == batch.Value.Count)
                        throw new ApiReturnedInsufficientValuesForRequestException();
                    result.Value.AddRange(batch.Value.Rows);
                    filter.Offset += batch.Value.Count;
                }
            }
            return result;
        }

        public ApiOptionalResponse<RequestResponse<R>> Post<R>(string path, R obj)
            where R: ApiObject
            => ExecuteRequest<R>(Method.POST, path, obj);

        public ApiOptionalResponse<RequestResponse<R>> Post<T, R>(string path, T obj)
            where T: ApiObject
            where R: ApiObject
            => ExecuteRequest<R>(Method.POST, path, obj);

        public ApiOptionalResponse<RequestResponse<R>> Put<R>(string path, R obj)
            where R: ApiObject
            => ExecuteRequest<R>(Method.PUT, path, obj);

        public ApiOptionalResponse<RequestResponse<R>> Patch<R>(string path, R obj)
            where R: ApiObject
            => ExecuteRequest<R>(Method.PATCH, path, obj);

        public ApiOptionalResponse<RequestResponse<R>> Delete<R>(string path)
            where R: ApiObject
            => ExecuteRequest<R>(Method.DELETE, path);

        private ApiOptionalResponse<RequestResponse<R>> ExecuteRequest<R>(Method method, string path, ApiObject? obj = null)
            where R: ApiObject
        {
            TestUriAndToken();
            var request = CreateRequest(path, method, obj);
            var response = Client.Execute(request);
            if(!response.IsSuccessful)
                throw new ApiErrorException(response.StatusCode, response.Content);
            var asRequestResponse = serializerDeserializer.Deserialize<RequestResponse<R>>(response);

            if("error" == asRequestResponse.Status)
            {
                return new ApiOptionalResponse<RequestResponse<R>>
                {
                    Exception = null != asRequestResponse.Messages && asRequestResponse.Messages.ContainsKey("general")
                        ? new ApiErrorException(asRequestResponse.Messages["general"])
                        : new ApiErrorException(asRequestResponse.Messages)
                };
            }
            return new ApiOptionalResponse<RequestResponse<R>> { Value = asRequestResponse };
        }

        private RestRequest CreateRequest(string path, Method method, object? obj)
        {
            var request = new RestRequest(path, method)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = serializerDeserializer
            };

            if(null == obj)
                return request;
            if(Method.GET != method)
            {
                request.AddJsonBody(obj);
                return request;
            }
            var type = obj.GetType();
            foreach(var property in type.GetProperties())
            {
                var attribute = property.GetCustomAttribute<SerializeAsAttribute>(inherit: false);
                if(null == attribute)
                    continue;
                // don't need to bother with PatchAttribute because it only applies to Post and Put (this is Get).
                var value = property.GetValue(obj);
                if(attribute.IsRequired && null == value)
                    throw new MissingRequiredFieldException<object>(type.Name, property.Name);
                if(null == value)
                    // early-out, don't try to use converter, don't add parameter
                    continue;
                if(SerializationContractResolver.TryGetConverter(property, attribute, out var converter))
                {
                    var stringBuilder = new StringBuilder();
                    using(var stringWriter = new StringWriter(stringBuilder))
                    using(var jsonWriter = new JsonTextWriter(stringWriter))
                        converter.WriteJson(jsonWriter, value, NewtonsoftJsonSerializer.Serializer);
                    value = stringBuilder.ToString();
                } else if(value.GetType().IsEnum && null != value.GetType().GetCustomAttribute<EnumNameConverterAttribute>())
                {
                    value = value.GetType().GetMember(value.ToString(), BindingFlags.Static | BindingFlags.Public).FirstOrDefault()
                                ?.GetCustomAttribute<EnumMemberAttribute>()?.Value
                                ?? value.ToString();
                }
                request.AddParameter(attribute.Key, value);
            }
            return request;
        }
    }
}
