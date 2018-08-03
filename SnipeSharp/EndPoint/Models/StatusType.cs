using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// The status type of a <see cref="StatusLabel">StatusLabel</see> or <see cref="AssetStatus">AssetStatus</see>.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusType
    {
        /// <summary>The status if of type pending. The associated object is in limbo.</summary>
        [EnumMember(Value = "pending")]
        Pending,
        /// <summary>The status is of type undeployable; the associated object cannot be deployed, nor will it be included in normal searches.</summary>
        [EnumMember(Value = "archived")]
        Archived,
        /// <summary>The status is of type undeployable; the associated object cannot be deployed.</summary>
        [EnumMember(Value = "unedeployable")]
        Undeployable,
        /// <summary>The status if of type deployable; the associated object may be deployed.</summary>
        [EnumMember(Value = "deployable")]
        Deployable,
        /// <summary>The status is of type deployable, but the associated object has been deployed.</summary>
        /// <remarks>This status type only occurs in <see cref="AssetStatus.StatusMeta">AssetStatus.StatusMeta</see>.</remarks>
        [EnumMember(Value = "deployed")]
        Deployed
    }
}
