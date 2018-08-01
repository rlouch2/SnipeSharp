using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.EndPoint
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CategoryType
    {
        [EnumMember(Value = "accessory")]
        Accessory,
        [EnumMember(Value = "asset")]
        Asset,
        [EnumMember(Value = "consumable")]
        Consumable,
        [EnumMember(Value = "component")]
        Component
    }
}
