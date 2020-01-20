using System;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using static SnipeSharp.Serialization.FieldConverter;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A field set.
    /// Field sets determine the custom fields that are available on asset Models.
    /// </summary>
    /// <seealso cref="Model" />
    /// <seealso cref="Asset.CustomFields" />
    [PathSegment("fieldsets")]
    public sealed class FieldSet : CommonEndPointModel, IPatchable
    {
        /// <summary>Create a new FieldSet object.</summary>
        public FieldSet() { }

        /// <summary>Create a new FieldSet object with the supplied ID, for use with updating.</summary>
        internal FieldSet(int id)
        {
            Id = id;
        }

        /// <inheritdoc />
        [Field(DeserializeAs = "id")]
        public override int Id { get; set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("name", IsRequired = true)]
        [Patch(nameof(isNameModified))]
        public override string Name
        {
            get => name;
            set
            {
                isNameModified = true;
                name = value;
            }
        }
        private bool isNameModified = false;
        private string name;

        /// <value>Gets the CustomFields in this FieldSet.</value>
        /// <remarks>To set the fields in a set, see <see cref="CustomFieldEndPoint.Associate(CustomField, FieldSet, bool, int?)"/> and <see cref="CustomFieldEndPoint.Disassociate(CustomField, FieldSet)" />.</remarks>
        [Field(DeserializeAs = "fields")]
        public IReadOnlyCollection<CustomField> Fields { get; private set; }

        /// <value>Gets the Models this FieldSet applies to.</value>
        [Field(DeserializeAs = "models", Converter = ReadOnlyResponseCollectionConverter)]
        public IReadOnlyCollection<Model> Models { get; private set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        void IPatchable.SetAllModifiedState(bool isModified)
        {
            isNameModified = isModified;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            ((IPatchable)this).SetAllModifiedState(false);
        }
    }
}
