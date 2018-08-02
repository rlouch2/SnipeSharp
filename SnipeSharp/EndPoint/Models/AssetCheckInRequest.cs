namespace SnipeSharp.EndPoint.Models
{
    internal sealed class AssetCheckInRequest : ApiObject
    {
        public string Note { get; set; }
        public Location Location { get; set; }
    }
}