using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SnipeSharp.Exceptions;
using SnipeSharp.Models;

namespace SnipeSharp.Client
{
    public sealed class SnipeItHttpClient: ISnipeItClient, IDisposable
    {
        private readonly HttpClient client;
        private static readonly HttpMethod PATCH = new HttpMethod("PATCH");
        public Uri Uri { get; }

        public SnipeItHttpClient(Uri uri, string token): this(new HttpClient(), uri, token)
        {
        }
        public SnipeItHttpClient(HttpClient client, Uri uri, string token)
        {
            this.Uri = uri.ToString().EndsWith("/") ? uri : new Uri($"{uri}/");
            this.client = client;
            this.client.BaseAddress = this.Uri;
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true };
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token ?? throw new NullApiTokenException());
        }

        public async Task<string> GetRaw(string relativePath)
            => await client.GetStringAsync(relativePath);

        public async Task<R?> Get<R>(string relativePath)
            where R: class
            => await ProcessGetResponse<R>(await client.GetAsync(relativePath));

        public async Task<ApiResult<R?>?> Post<R>(string relativePath, IPostable<R> body)
            where R: class
            => await ProcessApiResponse<R?>(await client.PostAsync(relativePath, body.AsHttpContent()));

        public async Task<ApiResult<R?>?> Put<R>(string relativePath, IPutable<R> body)
            where R: class
            => await ProcessApiResponse<R?>(await client.PutAsync(relativePath, body.AsHttpContent()));

        public async Task<ApiResult<R?>?> Patch<R>(string relativePath, IPatchable<R> body, R from)
            where R: class
            => await ProcessApiResponse<R?>(await client.SendAsync(new HttpRequestMessage(PATCH, relativePath)
                {
                    Content = body.GetPatchable(from).AsHttpContent()
                }));

        public async Task<SimpleApiResult?> Delete(string relativePath)
            => await ProcessApiResponse(await client.DeleteAsync(relativePath));

        private async Task<SimpleApiResult?> ProcessApiResponse(HttpResponseMessage message)
            => new SimpleApiResult(await ProcessApiResponse<object>(message));
        
        private async Task<ApiResult<R>?> ProcessApiResponse<R>(HttpResponseMessage message)
            where R: class?
        {
            var bytes = await message.Content.ReadAsByteArrayAsync();
            if(!message.IsSuccessStatusCode)
            {
                if(message.StatusCode == HttpStatusCode.Unauthorized)
                    throw new ApiUnauthorizedException(message.StatusCode, Encoding.UTF8.GetString(bytes));
                else
                    throw new ApiHttpException(message.StatusCode, Encoding.UTF8.GetString(bytes));
            }
            var response = JsonSerializer.Deserialize<ApiResult<R>>(bytes) ?? throw new ApiNullException();
            if(response.Status == ApiResultStatus.Error)
                throw new ApiException<R>(response);
            return response.Validate();
        }

        private async Task<R?> ProcessGetResponse<R>(HttpResponseMessage message)
            where R: class
        {
            var bytes = await message.Content.ReadAsByteArrayAsync();
            if(!message.IsSuccessStatusCode)
            {
                if(message.StatusCode == HttpStatusCode.Unauthorized)
                    throw new ApiUnauthorizedException(message.StatusCode, Encoding.UTF8.GetString(bytes));
                else
                    throw new ApiHttpException(message.StatusCode, Encoding.UTF8.GetString(bytes));
            }
            var response = JsonSerializer.Deserialize<ApiResult<R>>(bytes) ?? throw new ApiNullException();
            if(response.Status == ApiResultStatus.Error)
                throw new ApiException<R>(response);
            return JsonSerializer.Deserialize<R>(bytes);
        }

        void IDisposable.Dispose() => client.Dispose();
    }
}
