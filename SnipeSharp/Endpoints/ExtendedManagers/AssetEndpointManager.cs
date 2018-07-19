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

        public T GetByAssetTag(string name)
        {
            var response = _reqManager.Get($"{_endPoint}/bytag/{name}");
            var result = JsonConvert.DeserializeObject<T>(response);
            return result;
        }

        public T GetBySerial(string serial)
        {
            var response = _reqManager.Get($"{_endPoint}/byserial/{serial}");
            var result = JsonConvert.DeserializeObject<T>(response);
            return result;
        }

        public IRequestResponse Checkout(ICommonEndpointModel item)
        {
            IRequestResponse result;
            string response = _reqManager.Post(string.Format("{0}/{1}/checkout", _endPoint, item.Id), item);
            result = JsonConvert.DeserializeObject<RequestResponse>(response);
            return result;
        }

        public IRequestResponse Checkin(ICommonEndpointModel item)
        {
            IRequestResponse result;
            string response = _reqManager.Post(string.Format("{0}/{1}/checkin",_endPoint, item.Id), item);
            result = JsonConvert.DeserializeObject<RequestResponse>(response);
            return result;
        }

    }
}
