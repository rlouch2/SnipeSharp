using Newtonsoft.Json;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.Endpoints.ExtendedManagers
{
    public class AssetEndpointManager<T> : EndPointManager<Asset>
    {
        // Explicitly pass hardware as the endpoint, ignoring what the client gives us
        public AssetEndpointManager(IRequestManager reqManager, string endPoint) : base(reqManager, "hardware")
        {
        }

        public IRequestResponse Checkout(ICommonEndpointModel item)
        {
            var response = _reqManager.Post($"{_endPoint}/{item.Id}/checkout", item);
            var result = JsonConvert.DeserializeObject<RequestResponse>(response);
            return result;
        }

        public IRequestResponse Checkin(ICommonEndpointModel item)
        {
            var response = _reqManager.Post($"{_endPoint}/{item.Id}/checkin", item);
            var result = JsonConvert.DeserializeObject<RequestResponse>(response);
            return result;
        }
    }
}
