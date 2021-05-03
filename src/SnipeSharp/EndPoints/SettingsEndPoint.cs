using System.Threading.Tasks;
using SnipeSharp.Exceptions;
using SnipeSharp.Models;

namespace SnipeSharp
{
    public sealed class SettingsEndPoint
    {
        private readonly SnipeItApi Api;

        internal SettingsEndPoint(SnipeItApi api)
            => Api = api;

        public Task<DataTable<LoginAttempt>?> FindLoginAttemptsAsync()
            => FindLoginAttemptsAsync(new BasicFilter<LoginAttempt>());
        public async Task<DataTable<LoginAttempt>?> FindLoginAttemptsAsync(IFilter<LoginAttempt> filter)
        {
            filter = filter.Clone();

            // get initial batch
            var result = await Api.Client.Get<DataTable<LoginAttempt>>($"settings/login-attempts?{filter.GetParameters().AsQueryParameters()}");
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
                var batch = await Api.Client.Get<DataTable<LoginAttempt>>($"settings/login-attempts?limit=1000&offset={offset}{parameters}");
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
    }
}
