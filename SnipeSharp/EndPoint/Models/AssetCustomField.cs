using SnipeSharp.Serialization;

namespace SnipeSharp.EndPoint.Models
{
    public sealed class AssetCustomField : ApiObject
    {
        [Field("field")]
        public string Field { get; set; }

        [Field("value")]
        public string Value { get; set; }

        [Field("field_format")]
        public string Format { get; set; }
    }
}