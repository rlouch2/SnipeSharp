using System;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;
using System.Runtime.Serialization;

namespace SnipeSharp.Models
{
    /// <summary>
    /// An Asset Model.
    /// All Assets have a model that assigns further properties and defines which FieldSet applies.
    /// </summary>
    [PathSegment("models")]
    public sealed class Model : CommonEndPointModel, IAvailableActions, IPatchable
    {
        /// <summary>Create a new Model object.</summary>
        public Model() { }

        /// <summary>Create a new Model object with the supplied ID, for use with updating.</summary>
        internal Model(int id)
        {
            Id = id;
        }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [DeserializeAs("name")]
        [SerializeAs("name", IsRequired = true)]
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

        /// <value>The manufacturer for this model.</value>
        /// <remarks>
        /// <para>This field is required, and will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [DeserializeAs("manufacturer")]
        [SerializeAs("manufacturer_id", CommonModelConverter, IsRequired = true)]
        [Patch(nameof(isManufacturerModified))]
        public Manufacturer Manufacturer
        {
            get => manufacturer;
            set
            {
                isManufacturerModified = true;
                manufacturer = value;
            }
        }
        private bool isManufacturerModified = false;
        private Manufacturer manufacturer;

        /// <value>The url for the image of the asset.</value>
        [DeserializeAs("image")]
        [SerializeAs("image")]
        [Patch(nameof(isImageUriModified))]
        public Uri ImageUri
        {
            get => imageUri;
            set
            {
                isImageUriModified = true;
                imageUri = value;
            }
        }
        private bool isImageUriModified = false;
        private Uri imageUri;

        /// <value>The model number for this asset.</value>
        [DeserializeAs("model_number")]
        [SerializeAs("model_number")]
        [Patch(nameof(isModelNumberModified))]
        public string ModelNumber
        {
            get => modelNumber;
            set
            {
                isModelNumberModified = true;
                modelNumber = value;
            }
        }
        private bool isModelNumberModified = false;
        private string modelNumber;

        /// <value>Gets/sets the depreciation for this model.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [DeserializeAs("depreciation")]
        [SerializeAs("depreciation_id", CommonModelConverter)]
        [Patch(nameof(isDepreciationModified))]
        public Depreciation Depreciation
        {
            get => depreciation;
            set
            {
                isDepreciationModified = true;
                depreciation = value;
            }
        }
        private bool isDepreciationModified = false;
        private Depreciation depreciation;

        /// <value>The number of assets with this model.</value>
        [DeserializeAs("assets_count")]
        public int? AssetsCount { get; private set; }

        /// <value>Gets/sets the category for this model</value>
        /// <remarks>
        /// <para>This field is required, and will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [DeserializeAs("category")]
        [SerializeAs("category_id", CommonModelConverter, IsRequired = true)]
        [Patch(nameof(isCategoryModified))]
        public Category Category
        {
            get => category;
            set
            {
                isCategoryModified = true;
                category = value;
            }
        }
        private bool isCategoryModified = false;
        private Category category;

        /// <value>Gets/sets the fieldset for this model.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        // TODO: update function has "custom_fieldset_id" as request name. Is this compatible w/ store? What changes need to be made for that?
        [DeserializeAs("fieldset")]
        [SerializeAs("fieldset_id", CommonModelConverter)]
        [Patch(nameof(isFieldSetModified))]
        public FieldSet FieldSet
        {
            get => fieldSet;
            set
            {
                isFieldSetModified = true;
                fieldSet = value;
            }
        }
        private bool isFieldSetModified = false;
        private FieldSet fieldSet;

        /// <value>Gets/sets the lifetime for this model in months.</value>
        [DeserializeAs("eol", MonthsConverter)]
        [SerializeAs("eol", MonthsConverter)]
        [Patch(nameof(isEndOfLifeModified))]
        public int? EndOfLife
        {
            get => endOfLife;
            set
            {
                isEndOfLifeModified = true;
                endOfLife = value;
            }
        }
        private bool isEndOfLifeModified = false;
        private int? endOfLife;

        /// <value>Gets/sets the notes for this model.</value>
        [DeserializeAs("notes")]
        [SerializeAs("notes")]
        [Patch(nameof(isNotesModified))]
        public string Notes
        {
            get => notes;
            set
            {
                isNotesModified = true;
                notes = value;
            }
        }
        private bool isNotesModified = false;
        private string notes;

        /// <value>The date this object was soft-deleted in Snipe-IT, or null if it has not been deleted.</value>
        [DeserializeAs("deleted_at", DateTimeConverter)]
        public DateTime? DeletedAt { get ;set; }

        /// <inheritdoc />
        [DeserializeAs("available_actions", DeserializeAs.AvailableActions)]
        public AvailableAction AvailableActions { get; private set; }

        void IPatchable.SetAllModifiedState(bool isModified)
        {
            isNameModified = isModified;
            isManufacturerModified = isModified;
            isImageUriModified = isModified;
            isModelNumberModified = isModified;
            isDepreciationModified = isModified;
            isCategoryModified = isModified;
            isFieldSetModified = isModified;
            isEndOfLifeModified = isModified;
            isNotesModified = isModified;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            ((IPatchable)this).SetAllModifiedState(false);
        }
    }
}
