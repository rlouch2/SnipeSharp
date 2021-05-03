using SnipeSharp.Models;

namespace SnipeSharp
{
    public sealed class MaintenanceEndPoint: EndPoint<Maintenance>
    {
        internal MaintenanceEndPoint(SnipeItApi api): base(api, "maintenances")
        {
        }
    }
}
