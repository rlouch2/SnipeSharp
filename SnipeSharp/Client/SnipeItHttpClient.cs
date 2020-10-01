using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SnipeSharp.Exceptions;
using SnipeSharp.Filters;
using SnipeSharp.Models;
/*
#nullable enable
namespace SnipeSharp.Client
{
    public sealed class SnipeItHttpClient: ISnipeItClient
    {
        private readonly HttpClient client;

        public SnipeItHttpClient(): this(new HttpClient())
        {
        }
        public SnipeItHttpClient(HttpClient client)
        {
            this.client = client;
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true };
            this.client.DefaultRequestHeaders.Add("Content-Type", "application/json");
        }

        public string Token {
            set => client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", value ?? throw new NullApiTokenException());
        }

        public Uri Uri {
            set => client.BaseAddress = value ?? throw new NullApiUriException();
        }

        public bool HasToken => null != client.DefaultRequestHeaders.Authorization;

        public bool HasUri => null != client.BaseAddress;

        public ApiOptionalResponse<RequestResponse<R>> Delete<R>(string relativePath) where R : ApiObject
            => ProcessResponse<ApiOptionalResponse<RequestResponse<R>>>(client.DeleteAsync(relativePath));

        public ApiOptionalResponse<R> Get<R>(string relativePath, ISearchFilter? filter = null) where R : ApiObject
        {
            throw new NotImplementedException();
        }

        public ApiOptionalMultiResponse<R> GetMultiple<R>(string relativePath, ISearchFilter? filter = null) where R : ApiObject
        {
            var result = Get<ResponseCollection<R>>(relativePath, filter);
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
                    var batch = Get<ResponseCollection<R>>(relativePath, filter);
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

        public string GetRaw(string relativePath)
        {
            throw new NotImplementedException();
        }

        public ApiOptionalResponse<RequestResponse<R>> Patch<R>(string relativePath, R obj) where R : ApiObject
        {
            throw new NotImplementedException();
        }

        public ApiOptionalResponse<RequestResponse<R>> Post<R>(string relativePath, R obj) where R : ApiObject
        {
            throw new NotImplementedException();
        }

        public ApiOptionalResponse<RequestResponse<R>> Post<T, R>(string relativePath, T obj)
            where T : ApiObject
            where R : ApiObject
        {
            throw new NotImplementedException();
        }

        public ApiOptionalResponse<RequestResponse<R>> Put<R>(string relativePath, R obj) where R : ApiObject
        {
            throw new NotImplementedException();
        }

        private R ProcessResponse<R>(Task<HttpResponseMessage> messageTask)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
*/
