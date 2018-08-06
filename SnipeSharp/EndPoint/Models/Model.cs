using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// An Asset Model.
    /// All Assets have a model that assigns further properties and defines which FieldSet applies.
    /// </summary>
    [PathSegment("models")]
    public sealed class Model : CommonEndPointModel, IAvailableActions
    {
        /// <inheritdoc />
        [Field("id")]
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("name", true, required: true)]
        public override string Name { get; set; }

        /// <value>The manufacturer for this model.</value>
        /// <remarks>
        /// <para>This field is required, and will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("manufacturer", "manufacturer_id", converter: CommonModelConverter, required: true)]
        public Manufacturer Manufacturer { get; set; }

        /// <value>The url for the image of the asset.</value>
        [Field("image", true)]
        public Uri ImageUri { get; set; }

        /// <value>The model number for this asset.</value>
        [Field("model_number", true)]
        public string ModelNumber { get; set; }

        /// <value>Gets/sets the depreciation for this model.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("depreciation", "depreciation_id", converter: CommonModelConverter)]
        public Depreciation Depreciation { get; set; }

        /// <value>The number of assets with this model.</value>
        [Field("assets_count")]
        public int? AssetsCount { get; private set; }

        /// <value>Gets/sets the category for this model</value>
        /// <remarks>
        /// <para>This field is required, and will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("category", "category_id", converter: CommonModelConverter, required: true)]
        public Category Category { get; set; }

        /// <value>Gets/sets the fieldset for this model.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("fieldset", "fieldset_id", converter: CommonModelConverter)]
        public FieldSet FieldSet { get; set; }

        /// <value>Gets/sets the lifetime for this model in months.</value>
        [Field("eol", true, converter: MonthsConverter)]
        public int? EndOfLife { get; set; }

        /// <value>Gets/sets the notes for this model.</value>
        [Field("notes", true)]
        public string Notes { get; set; }

        /// <inheritdoc />
        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <value>The date this object was soft-deleted in Snipe-IT, or null if it has not been deleted.</value>
        [Field("deleted_at", converter: DateTimeConverter)]
        public DateTime? DeletedAt { get ;set; }

        /// <inheritdoc />
        [Field("available_actions", converter: AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }
    }
}
