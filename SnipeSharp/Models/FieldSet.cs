using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A field set.
    /// Field sets determine the custom fields that are available on asset Models.
    /// </summary>
    /// <seealso cref="Model" />
    /// <seealso cref="Asset.CustomFields" />
    [PathSegment("fieldsets")]
    public sealed class FieldSet : CommonEndPointModel
    {
        /// <inheritdoc />
        [Field("id")]
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("name", true, required: true)]
        public override string Name { get; set; }

        /// <value>Gets the CustomFields in this FieldSet.</value>
        /// <remarks>To set the fields in a set, see <see cref="EndPointExtensions.Associate(EndPoint{CustomField}, CustomField, FieldSet, bool, int?)"/> and <see cref="EndPointExtensions.Disassociate(EndPoint{CustomField}, CustomField, FieldSet)" />.</remarks>
        [Field("fields")]
        public ResponseCollection<CustomField> Fields { get; private set; }

        /// <value>Gets the Models this FieldSet applies to.</value>
        [Field("models")]
        public ResponseCollection<Model> Models { get; private set; }

        /// <inheritdoc />
        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }
    }
}
