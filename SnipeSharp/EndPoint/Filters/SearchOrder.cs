using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SnipeSharp.EndPoint.Filters
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SearchOrder
    {
        [JsonProperty("asc")]
        Ascending,
        [JsonProperty("desc")]
        Descending
    }
}