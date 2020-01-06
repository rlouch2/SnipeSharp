using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.Models.Enumerations
{
    /// <summary>
    /// The status meta of an <see cref="AssetStatus">AssetStatus</see>.
    /// </summary>
    /// <seealso cref="Filters.AbstractAssetSearchFilter" />
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FilterStatusMeta
    {
        /// <summary>Todo: what is this?</summary>
        [EnumMember(Value = "RTD")]
        RTD,
        /// <summary>The asset has been archived; it cannot be deployed, nor will it be included in normal searches.</summary>
        [EnumMember(Value = "archived")]
        Archived,
        /// <summary>The asset is undeployable.</summary>
        [EnumMember(Value = "unedeployable")]
        Undeployable,
        /// <summary>The asset is deployed.</summary>
        [EnumMember(Value = "deployed")]
        Deployed,
        /// <summary>The asset has been deleted.</summary>
        [EnumMember(Value = "deleted")]
        Deleted,
        /// <summary>The asset is requestable by users.</summary>
        [EnumMember(Value = "requestable")]
        Requestable
    }
}
