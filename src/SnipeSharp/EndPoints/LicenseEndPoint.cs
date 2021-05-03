using System;
using System.Threading.Tasks;
using SnipeSharp.Exceptions;
using SnipeSharp.Models;

namespace SnipeSharp
{
    public sealed class LicenseEndPoint: EndPoint<License>
    {
        internal LicenseEndPoint(SnipeItApi api): base(api, "licenses")
        {
        }

        public Task<SelectList<License>?> SelectAsync(string? search = null)
            => Api.Client.Get<SelectList<License>>($"{BaseUri}/selectlist{((null == search) ? "" : $"?search={Uri.EscapeUriString(search)}")}");

        public Task<DataTable<LicenseSeat>?> FindSeatsAsync(IApiObject<License> license)
            => FindSeatsAsync(license, new BasicFilter<LicenseSeat>());
        public async Task<DataTable<LicenseSeat>?> FindSeatsAsync(IApiObject<License> license, IFilter<LicenseSeat> filter)
        {
            // duplicate the filter so if we change properties the original isn't affected.
            filter = filter.Clone();

            // get initial batch
            var result = await Api.Client.Get<DataTable<LicenseSeat>>($"{BaseUri}?{filter.GetParameters().AsQueryParameters()}");
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
                var batch = await Api.Client.Get<DataTable<LicenseSeat>>($"{BaseUri}?limit=1000&offset={offset}{parameters}");
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
