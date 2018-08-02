using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.EndPoint.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusType
    {
        [EnumMember(Value = "pending")]
        Pending,
        [EnumMember(Value = "archived")]
        Archived,
        [EnumMember(Value = "unedeployable")]
        Undeployable,
        [EnumMember(Value = "deployable")]
        Deployable
    }
}
