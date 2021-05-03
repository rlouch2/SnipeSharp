using SnipeSharp.Models;

namespace SnipeSharp
{
    public sealed class LocationEndPoint : EndPoint<Location>
    {
        internal LocationEndPoint(SnipeItApi api): base(api, "locations")
        {
        }
    }
}
