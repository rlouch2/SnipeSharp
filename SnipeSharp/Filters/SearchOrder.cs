using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SnipeSharp.Serialization;
using System.Runtime.Serialization;

namespace SnipeSharp.Filters
{
    /// <summary>
    /// Indicates the order to sort by.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [EnumNameConverter]
    public enum SearchOrder
    {
        /// <summary>Sort the request in ascending order according to the sort column.</summary>
        [EnumMember(Value = "asc")]
        Ascending,
        /// <summary>Sort the request in descending order according to the sort column.</summary>
        [EnumMember(Value = "desc")]
        Descending
    }
}
