using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// What the field type of the custom field is.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CustomFieldElement
    {
        /// <summary>The field type is a list selection.</summary>
        [EnumMember(Value = "list")]
        List,
        /// <summary>The field type is a text field.</summary>
        [EnumMember(Value = "text")]
        Text,
        /// <summary>The field type is a text area, with newline support.</summary>
        [EnumMember(Value = "textarea")]
        TextArea
    }
}
