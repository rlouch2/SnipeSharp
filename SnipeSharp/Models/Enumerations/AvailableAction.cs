using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.Models.Enumerations
{
    /// <summary>
    /// Members of this enumeration are operations that may be performed through the API.
    /// </summary>
    /// <seealso cref="IAvailableActions"/>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AvailableAction
    {
        /// <summary>The associated object may be checked out.</summary>
        [EnumMember(Value = "checkout")]
        CheckOut,
        /// <summary>The associated object may be checked in.</summary>
        [EnumMember(Value = "checkin")]
        CheckIn,
        /// <summary>The associated object may be cloned.</summary>
        [EnumMember(Value = "clone")]
        Clone,
        /// <summary>The associated object may be deleted from the database.</summary>
        /// <remarks>Deleting may not be a full deletion, but merely an assigning of the "Deleted" status.</remarks>
        [EnumMember(Value = "delete")]
        Delete,
        /// <summary>The associated object may be restored.</summary>
        // TODO: what does this mean?
        [EnumMember(Value = "restore")]
        Restore,
        /// <summary>The associated object may have its properties set and updated.</summary>
        [EnumMember(Value = "update")]
        Update
    }
}
