using System;
using System.Threading.Tasks;
using SnipeSharp.Models;

namespace SnipeSharp
{
    public sealed class SupplierEndPoint: EndPoint<Company> {
        internal SupplierEndPoint(SnipeItApi api): base(api, "suppliers"){}

        public Task<SelectList<Supplier>?> SelectAsync(string? search = null)
            => Api.Client.Get<SelectList<Supplier>>($"{BaseUri}/selectlist{((null == search) ? "" : $"?search={Uri.EscapeUriString(search)}")}");
    }
}
