using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// ApiObject for reordering custom fields in fieldsets.
    /// </summary>
    internal sealed class CustomFieldReordering : ApiObject
    {
        /// <summary>
        /// The fields of the set, in the order they will appear.
        /// </summary>
        [Field("item", Converter = CommonModelArrayConverter, IsRequired = true)]
        public CustomField[] Fields;
    }
}
