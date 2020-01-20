using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SnipeSharp.Serialization;
using System.Runtime.Serialization;

namespace SnipeSharp.Filters
{
    /// <summary>
    /// Columns a license seat search can be sorted on.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [EnumNameConverter]
    public enum LicenseSeatSearchColumn
    {
        /// <summary>The internal Id number.</summary>
        [EnumMember(Value = "id")]
        Id,
        /// <summary>The assigned user's department.</summary>
        [EnumMember(Value = "department")]
        Department
    }
}
