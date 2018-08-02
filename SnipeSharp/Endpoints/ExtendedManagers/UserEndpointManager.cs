using Newtonsoft.Json;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.Endpoints.ExtendedManagers
{
    public class UserEndpointManager : EndPointManager<User>
    {
        public UserEndpointManager(IRequestManager reqManager) : base(reqManager)
        {
        }

        public ResponseCollection<User> GetAssignedAssets(User user)
        {
            var response = RequestManager.Get($"{BaseUri}/{user.Id}/assets");
            var results = JsonConvert.DeserializeObject<ResponseCollection<User>>(response);
            return results;
        }
    }
}
