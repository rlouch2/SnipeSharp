using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.Models.Enumerations
{
    /// <summary>
    /// Indicates what type an Asset or other object is assigned to: a User, a Location, or an Asset.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AssignedToType
    {
        /// <summary>The object is assigned to a User.</summary>
        [EnumMember(Value = "user")]
        User,
        /// <summary>The object is assigned to a Location.</summary>
        [EnumMember(Value = "location")]
        Location,
        /// <summary>The object is assigned to an Asset.</summary>
        [EnumMember(Value = "asset")]
        Asset
    }
}
