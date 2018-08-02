using SnipeSharp.Serialization;

namespace SnipeSharp.EndPoint.Models
{
    public sealed class AssetStatus
    {
        [Field("id", true)]
        public int StatusId { get; set; }
        
        [Field("name")]
        public string Name { get; set; }

        [Field("status_type")]
        public StatusType StatusType { get; set; }

        [Field("status_meta")]
        public StatusType StatusMeta { get; set; }
    }
}
