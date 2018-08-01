using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.EndPoint.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AvailableAction
    {
        [EnumMember(Value = "checkout")]
        CheckOut,
        [EnumMember(Value = "checkin")]
        CheckIn,
        [EnumMember(Value = "clone")]
        Clone,
        [EnumMember(Value = "delete")]
        Delete,
        [EnumMember(Value = "restore")]
        Restore,
        [EnumMember(Value = "update")]
        Update
    }
}