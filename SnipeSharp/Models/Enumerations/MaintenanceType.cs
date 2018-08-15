using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SnipeSharp.Models.Enumerations
{
    /// <summary>
    /// The type of an asset maintenance.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MaintenanceType
    {
        /// <summary>A general Maintenance.</summary>
        [EnumMember(Value = "Maintenance")]
        Maintenance,
        /// <summary>Repairs.</summary>
        [EnumMember(Value = "Repair")]
        Repair,
        /// <summary>Upgrades.</summary>
        [EnumMember(Value = "Upgrade")]
        Upgrade,
        /// <summary>PAT tests.</summary>
        [EnumMember(Value = "PAT test")]
        PATTest
    }
}
