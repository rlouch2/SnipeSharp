using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    /// <summary>
    /// <para>A custom field on an <see cref="Asset">Asset</see> object.</para>
    /// </summary>
    /// <remarks>
    /// <para>These are store in <see cref="Asset.CustomFields">Asset.CustomFields</see>.</para>
    /// </remarks>
    public sealed class AssetCustomField : ApiObject
    {
        /// <summary>
        /// The Database column name in SnipeIT.
        /// </summary>
        [Field("field")]
        public string Field { get; set; }

        /// <summary>
        /// The value of the field.
        /// </summary>
        [Field("value")]
        public string Value { get; set; }

        /// <summary>
        /// The format the field must fit, specified by SnipeIT.
        /// </summary>
        // TODO: Parse this into a special object that will verify the value matches before updating?
        [Field("field_format")]
        public string Format { get; set; }
    }
}
