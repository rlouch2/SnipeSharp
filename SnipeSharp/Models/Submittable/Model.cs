using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// An Asset Model.
    /// All Assets have a model that assigns further properties and defines which FieldSet applies.
    /// </summary>
    [PathSegment("models")]
    public sealed class Model : CommonEndPointModel, IAvailableActions
    {
        /// <inheritdoc />
        [Field(DeserializeAs = "id")]
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("name", IsRequired = true)]
        public override string Name { get; set; }

        /// <value>The manufacturer for this model.</value>
        /// <remarks>
        /// <para>This field is required, and will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "manufacturer", SerializeAs = "manufacturer_id", Converter = CommonModelConverter, IsRequired = true)]
        public Manufacturer Manufacturer { get; set; }

        /// <value>The url for the image of the asset.</value>
        [Field("image")]
        public Uri ImageUri { get; set; }

        /// <value>The model number for this asset.</value>
        [Field("model_number")]
        public string ModelNumber { get; set; }

        /// <value>Gets/sets the depreciation for this model.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "depreciation", SerializeAs = "depreciation_id", Converter = CommonModelConverter)]
        public Depreciation Depreciation { get; set; }

        /// <value>The number of assets with this model.</value>
        [Field(DeserializeAs = "assets_count")]
        public int? AssetsCount { get; private set; }

        /// <value>Gets/sets the category for this model</value>
        /// <remarks>
        /// <para>This field is required, and will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "category", SerializeAs = "category_id", Converter = CommonModelConverter, IsRequired = true)]
        public Category Category { get; set; }

        /// <value>Gets/sets the fieldset for this model.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "fieldset", SerializeAs = "fieldset_id", Converter = CommonModelConverter)]
        public FieldSet FieldSet { get; set; }

        /// <value>Gets/sets the lifetime for this model in months.</value>
        [Field("eol", Converter = MonthsConverter)]
        public int? EndOfLife { get; set; }

        /// <value>Gets/sets the notes for this model.</value>
        [Field("notes")]
        public string Notes { get; set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <value>The date this object was soft-deleted in Snipe-IT, or null if it has not been deleted.</value>
        [Field(DeserializeAs = "deleted_at", Converter = DateTimeConverter)]
        public DateTime? DeletedAt { get ;set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }
    }
}
