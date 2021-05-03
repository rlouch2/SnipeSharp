using System;
using System.Threading.Tasks;
using SnipeSharp.Models;

namespace SnipeSharp
{
    public sealed class StatusLabelEndPoint : EndPoint<StatusLabel>
    {
        public StatusLabelEndPoint(SnipeItApi api) : base(api, "statuslabels")
        {
        }

        public Task<SelectList<Asset>?> GetAssetsAsync(IApiObject<StatusLabel> label, string? search = null)
            => Api.Client.Get<SelectList<Asset>>($"{BaseUri}/{label.Id}/assetlist");

        public async Task<bool?> IsDeployable(IApiObject<StatusLabel> label)
        {
            // this is stupid and I hate it.
            var response = await Api.Client.Get<string>($"{BaseUri}/{label.Id}/deployable");
            if(null == response)
                return null;
            return response.Length > 0 && response[0] == '1';
        }
    }
}
