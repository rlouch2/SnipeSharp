using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.Models.Enumerations
{
    /// <summary>
    /// The status type of a <see cref="StatusLabel">StatusLabel</see> or <see cref="AssetStatus">AssetStatus</see>.
    /// </summary>
    /// <seealso cref="StatusMeta" />
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusType
    {
        /// <summary>The status is of type undeployable; the associated object cannot be deployed.</summary>
        [EnumMember(Value = "unedeployable")]
        Undeployable = 0,
        /// <summary>The status if of type pending. The associated object is in limbo.</summary>
        [EnumMember(Value = "pending")]
        Pending,
        /// <summary>The status is of type undeployable; the associated object cannot be deployed, nor will it be included in normal searches.</summary>
        [EnumMember(Value = "archived")]
        Archived,
        /// <summary>The status if of type deployable; the associated object may be deployed.</summary>
        [EnumMember(Value = "deployable")]
        Deployable
    }
}
