using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    /// <summary>
    /// ApiObject for reordering custom fields in fieldsets.
    /// </summary>
    /// <remarks>This class is for internal use only.</remarks>
    internal sealed class CustomFieldReordering : ApiObject
    {
        /// <summary>
        /// The fields of the set, in the order they will appear.
        /// </summary>
        [SerializeAs("item", SerializeAs.IdValueArray, IsRequired = true)]
        public CustomField[] Fields { get; set; }
    }
}
