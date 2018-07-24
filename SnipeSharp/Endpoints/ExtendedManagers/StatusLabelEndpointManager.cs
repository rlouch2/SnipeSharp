using Newtonsoft.Json;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.Endpoints.ExtendedManagers
{
    public class StatusLabelEndpointManager : EndPointManager<StatusLabel>
    {
        public StatusLabelEndpointManager(IRequestManager reqManager) : base(reqManager)
        {
        }

        public ResponseCollection<StatusLabel> GetAssignedAssets(ICommonEndpointModel statusLabel)
        {
            var response = RequestManager.Get($"{BaseUri}/{statusLabel.Id}/assetlist");
            var results = JsonConvert.DeserializeObject<ResponseCollection<StatusLabel>>(response);
            return results;
        }
    }
}