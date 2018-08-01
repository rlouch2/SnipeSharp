using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.EndPoint
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AssignedToType
    {
        [EnumMember(Value = "user")]
        User,
        [EnumMember(Value = "location")]
        Location,
        [EnumMember(Value = "asset")]
        Asset
    }
}
