using Newtonsoft.Json;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.Endpoints.ExtendedManagers
{
    public class UserEndpointManager : EndPointManager<User>
    {
        public UserEndpointManager(IRequestManager reqManager, string endPoint) : base(reqManager, "users")
        {
        }

        public ResponseCollection<User> GetAssignedAssets(ICommonEndpointModel user)
        {
            var response = _reqManager.Get($"{_endPoint}/{user.Id}/assets");
            var results = JsonConvert.DeserializeObject<ResponseCollection<User>>(response);
            return results;
        }
    }
}
