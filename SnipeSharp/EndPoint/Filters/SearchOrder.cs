using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.EndPoint.Filters
{
    /// <summary>
    /// Indicates the order to sort by.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
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
