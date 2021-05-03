using SnipeSharp.Models;

namespace SnipeSharp
{
    public sealed class GroupEndPoint: EndPoint<Group> {
        internal GroupEndPoint(SnipeItApi api): base(api, "groups"){}
    }
}
