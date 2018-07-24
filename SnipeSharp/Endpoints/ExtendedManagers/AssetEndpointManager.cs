using Newtonsoft.Json;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.Endpoints.ExtendedManagers
{
    public class AssetEndpointManager : EndPointManager<Asset>
    {
        // Explicitly pass hardware as the endpoint, ignoring what the client gives us
        public AssetEndpointManager(IRequestManager reqManager) : base(reqManager)
        {
        }

        public IRequestResponse CheckOut(AssetCheckoutRequest request)
        {
            var response = RequestManager.Post($"{BaseUri}/{request.AssignedAsset.Id}/checkout", request);
            var result = JsonConvert.DeserializeObject<RequestResponse>(response);
            return result;
        }

        public IRequestResponse CheckIn(ICommonEndpointModel item)
        {
            var response = RequestManager.Post($"{BaseUri}/{item.Id}/checkin", item);
            var result = JsonConvert.DeserializeObject<RequestResponse>(response);
            return result;
        }
    }
}