using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.EndPoint
{
    /// <summary>
    /// <para>Indicates the type of a <see cref="SnipeSharp.EndPoint.Models.Category">Category</see>.</para>
    /// <para>Categories for objects can only be retrieved when the CategoryType matches the object type, but the API won't stop you from setting it wrong.</para>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CategoryType
    {
        /// <summary>This Category is for an <see cref="SnipeSharp.EndPoint.Models.Accessory">Accessory</see>.</summary>
        [EnumMember(Value = "accessory")]
        Accessory,
        /// <summary>This Category is for an <see cref="SnipeSharp.EndPoint.Models.Asset">Asset</see>.</summary>
        [EnumMember(Value = "asset")]
        Asset,
        /// <summary>This Category is for a <see cref="SnipeSharp.EndPoint.Models.Consumable">Consumable</see>.</summary>
        [EnumMember(Value = "consumable")]
        Consumable,
        /// <summary>This Category is for a <see cref="SnipeSharp.EndPoint.Models.Component">Component</see>.</summary>
        [EnumMember(Value = "component")]
        Component
    }
}
