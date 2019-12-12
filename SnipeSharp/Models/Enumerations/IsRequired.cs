using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.Models.Enumerations
{
    /// <summary>
    /// If a <see cref="CustomField"/> is required in a <see cref="FieldSet"/> or not.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IsRequired
    {
        /// <summary>The field is required.</summary>
        [EnumMember(Value = "on")]
        On = 1,
        /// <summary>The field is not required.</summary>
        [EnumMember(Value = "off")]
        Off = 0
    }
}
