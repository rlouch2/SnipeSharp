using SnipeSharp.Models;

namespace SnipeSharp
{
    public sealed class DepreciationEndPoint: EndPoint<Depreciation>
    {
        internal DepreciationEndPoint(SnipeItApi api): base(api, "depreciations")
        {
        }
    }
}