using System;
using System.Threading.Tasks;
using SnipeSharp.Models;

namespace SnipeSharp
{
    public sealed class CompanyEndPoint: EndPoint<Company>
    {
        internal CompanyEndPoint(SnipeItApi api): base(api, "companies"){}

        public Task<SelectList<Company>?> SelectAsync(string? search = null)
            => Api.Client.Get<SelectList<Company>>($"{BaseUri}/selectlist{((null == search) ? "" : $"?search={Uri.EscapeUriString(search)}")}");
    }
}
