using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using SnipeSharp.Serialization;

namespace SnipeSharp
{
    [JsonConverter(typeof(EnumJsonConverter<StatusLabelType>))]
    public enum StatusLabelType
    {
        [EnumMember(Value = "pending")]
        Pending,

        [EnumMember(Value = "archived")]
        Archived,

        [EnumMember(Value = "undeployable")]
        Undeployable,

        [EnumMember(Value = "deployable")]
        Deployable,
    }

    [JsonConverter(typeof(EnumJsonConverter<StatusMeta>))]
    public enum StatusMeta
    {

        [EnumMember(Value = "pending")]
        Pending = StatusLabelType.Pending,

        [EnumMember(Value = "archived")]
        Archived = StatusLabelType.Archived,

        [EnumMember(Value = "undeployable")]
        Undeployable = StatusLabelType.Undeployable,

        [EnumMember(Value = "deployable")]
        Deployable = StatusLabelType.Deployable,

        [EnumMember(Value = "deployed")]
        Deployed,
    }
}
