using System.Threading.Tasks;
using SnipeSharp.Models;

namespace SnipeSharp
{
    public sealed class AccountEndPoint
    {
        private readonly SnipeItApi Api;

        internal AccountEndPoint(SnipeItApi api)
            => Api = api;

        public Task<DataTable<RequestableAsset>?> FindRequestableAssetsAsync()
            => Api.Client.Get<DataTable<RequestableAsset>>("/account/requestable/hardware");

        public Task<DataTable<AssetRequest>?> FindRequestedAssetsAsync()
            => Api.Client.Get<DataTable<AssetRequest>>("/account/requests");
    }
}
