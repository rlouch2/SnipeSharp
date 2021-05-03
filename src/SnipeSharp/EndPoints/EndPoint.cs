using System.Collections.Generic;
using System.Threading.Tasks;
using SnipeSharp.Exceptions;
using SnipeSharp.Models;

namespace SnipeSharp
{
    public abstract class EndPoint<T>
        where T: class, IApiObject<T>
    {
        protected readonly SnipeItApi Api;
        protected readonly string BaseUri;

        internal EndPoint(SnipeItApi api, string baseUri)
        {
            Api = api;
            BaseUri = baseUri;
        }

        public Task<T?> GetAsync(IApiObject<T> origin) => GetAsync(origin.Id);
        public Task<T?> GetAsync(int id) => Api.Client.Get<T>($"{BaseUri}/{id}");

        public async IAsyncEnumerable<T?> GetAsync(IEnumerable<T> ids)
        {
            foreach(var id in ids)
                yield return await GetAsync(id);
        }
        public async IAsyncEnumerable<T?> GetAsync(IEnumerable<int> ids)
        {
            foreach(var id in ids)
                yield return await GetAsync(id);
        }

        public Task<DataTable<T>?> FindAsync() => FindAsync(new BasicFilter<T>());
        public async Task<DataTable<T>?> FindAsync(IFilter<T> filter)
        {
            // duplicate the filter so if we change properties the original isn't affected.
            filter = filter.Clone();

            // get initial batch
            var result = await Api.Client.Get<DataTable<T>>($"{BaseUri}?{filter.GetParameters().AsQueryParameters()}");
            if(null == result)
                return null;
            var baseOffset = filter.Offset ?? 0;
            // if we already have what we need, leave.
            if(null != filter.Limit || baseOffset + result.Count >= result.Total)
                return result;

            // otherwise, get subsequent batches.
            filter.Limit = null; // use limit hard-coded in request URI
            filter.Offset = null; // use offset variable below, encoded directly into request URI
            var offset = baseOffset + result.Count;// start here.
            var parameters = filter.GetParameters().AsQueryParameters();
            if(parameters.Length > 0)
                parameters = "&" + parameters;
            while(baseOffset + result.Count < result.Total)
            {
                var batch = await Api.Client.Get<DataTable<T>>($"{BaseUri}?limit=1000&offset={offset}{parameters}");
                // these shouldn't happen -- if it did, something went wrong.
                if(null == batch)
                    throw new ApiNullException();
                if(0 == batch.Count)
                    throw new ApiReturnedInsufficientValuesForRequestException();

                // add the batch to the ongoing result and increase offset.
                result.Value.AddRange(batch.Value);
                offset += batch.Count;
            }

            return result;
        }

        public Task<ApiResult<T?>?> CreateAsync(IPostable<T> properties)
            => Api.Client.Post<T>(BaseUri, properties);

        public Task<ApiResult<T?>?> SetAsync(T item, IPutable<T> properties)
            => Api.Client.Put<T>($"{BaseUri}/{item.Id}", properties);

        public Task<ApiResult<T?>?> UpdateAsync(T item, IPatchable<T> properties)
            => Api.Client.Patch<T>($"{BaseUri}/{item.Id}", properties, item);

        public Task<SimpleApiResult?> DeleteAsync(T item)
            => Api.Client.Delete($"{BaseUri}/{item.Id}");
    }
}
