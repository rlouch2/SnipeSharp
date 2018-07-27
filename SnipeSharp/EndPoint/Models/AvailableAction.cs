using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SnipeSharp.EndPoint.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AvailableAction
    {
        [JsonProperty("checkout")]
        CheckOut,
        [JsonProperty("checkin")]
        CheckIn,
        [JsonProperty("clone")]
        Clone,
        [JsonProperty("delete")]
        Delete,
        [JsonProperty("restore")]
        Restore,
        [JsonProperty("update")]
        Update
    }
}