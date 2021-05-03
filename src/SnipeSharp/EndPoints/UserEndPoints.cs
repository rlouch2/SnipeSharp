using System;
using System.Threading.Tasks;
using SnipeSharp.Models;

namespace SnipeSharp
{
    public sealed class UserEndPoint: EndPoint<User> {
        internal UserEndPoint(SnipeItApi api): base(api, "users"){}
        // TODO

        public Task<User?> Me => Api.Client.Get<User>($"{BaseUri}/me");

        public Task<DataTable<Asset>?> GetAssets(IApiObject<User> obj)
            => Api.Client.Get<DataTable<Asset>>($"{BaseUri}/{obj.Id}/assets");

        public Task<DataTable<License>?> GetLicenses(IApiObject<User> obj)
            => Api.Client.Get<DataTable<License>>($"{BaseUri}/{obj.Id}/licenses");

        public Task<SelectList<User>?> SelectAsync(string? search = null)
            => Api.Client.Get<SelectList<User>>($"{BaseUri}/selectlist{((null == search) ? "" : $"?search={Uri.EscapeUriString(search)}")}");
    }
}
