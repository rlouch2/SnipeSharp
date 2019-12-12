using SnipeSharp.Serialization;
using IsRequiredType = SnipeSharp.Models.Enumerations.IsRequired;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// ApiObject for (dis)associating custom fields to/from fieldsets.
    /// </summary>
    internal sealed class CustomFieldAssociation : ApiObject
    {
        /// <summary>
        /// FieldSet to (dis)associate to/from.
        /// </summary>
        [Field("fieldset_id", Converter =  CommonModelConverter, IsRequired = true)]
        public FieldSet FieldSet { get; set; }

        /// <summary>
        /// Backing field for <see cref="IsRequired"/>
        /// </summary>
        [Field("required")]
        private IsRequiredType _isRequired;

        /// <summary>
        /// Whether or not the field is required in the fieldset.
        /// </summary>
        public bool IsRequired {
            get => _isRequired == IsRequiredType.On;
            set => _isRequired = value ? IsRequiredType.On : IsRequiredType.Off;
        }

        /// <summary>
        /// The order of the field in the fieldset.
        /// </summary>
        [Field("order")]
        public int Order { get; set ;}
    }
}
