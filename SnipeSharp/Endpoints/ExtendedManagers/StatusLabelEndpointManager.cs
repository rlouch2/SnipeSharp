using Newtonsoft.Json;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.Endpoints.ExtendedManagers
{
    public class StatusLabelEndpointManager<T> : EndPointManager<StatusLabel>
    {
        public StatusLabelEndpointManager(IRequestManager reqManager, string endPoint) : base(reqManager, "statuslabels")
        {
        }

        public ResponseCollection<StatusLabel> GetAssignedAssets(ICommonEndpointModel statusLabel)
        {
            var response = _reqManager.Get($"{_endPoint}/{statusLabel.Id}/assetlist");
            var results = JsonConvert.DeserializeObject<ResponseCollection<StatusLabel>>(response);
            return results;
        }
    }
}
