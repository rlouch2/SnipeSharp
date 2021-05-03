using System;
using System.Threading.Tasks;
using SnipeSharp.Models;

namespace SnipeSharp
{
    public sealed class ManufacturerEndPoint : EndPoint<Manufacturer>
    {
        internal ManufacturerEndPoint(SnipeItApi api) : base(api, "manufacturers")
        {
        }

        public Task<SelectList<Manufacturer>?> SelectAsync(string? search = null)
            => Api.Client.Get<SelectList<Manufacturer>>($"{BaseUri}/selectlist{((null == search) ? "" : $"?search={Uri.EscapeUriString(search)}")}");
    }
}
