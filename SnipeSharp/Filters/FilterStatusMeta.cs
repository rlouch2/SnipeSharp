using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.Filters
{
    /// <summary>
    /// The status meta of an <see cref="Models.AssetStatus">AssetStatus</see>.
    /// </summary>
    /// <seealso cref="Filters.AbstractAssetSearchFilter" />
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FilterStatusMeta
    {
        /// <summary>Todo: what is this?</summary>
        [EnumMember(Value = "RTD")]
        RTD,
        /// <summary>The asset has been archived; it cannot be deployed, nor will it be included in normal searches.</summary>
        [EnumMember(Value = "Archived")]
        Archived,
        /// <summary>The asset is undeployable.</summary>
        [EnumMember(Value = "Unedeployable")]
        Undeployable,
        /// <summary>The asset is deployed.</summary>
        [EnumMember(Value = "Deployed")]
        Deployed,
        /// <summary>The asset has been deleted.</summary>
        [EnumMember(Value = "Deleted")]
        Deleted,
        /// <summary>The asset is requestable by users.</summary>
        [EnumMember(Value = "Requestable")]
        Requestable
    }
}
