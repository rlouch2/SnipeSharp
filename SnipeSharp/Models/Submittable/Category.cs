using System;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;
using System.Runtime.Serialization;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A Category.
    /// Categories may be checked out to Assets, Accessories, Consumables and Components.
    /// </summary>
    [PathSegment("categories")]
    public sealed class Category : CommonEndPointModel, IAvailableActions, IPatchable
    {
        /// <summary>Create a new Category object.</summary>
        public Category() { }

        /// <summary>Create a new Category object with the supplied ID, for use with updating.</summary>
        internal Category(int id)
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

        /// <summary>
        /// Indicates the type of objects this category may contain.
        /// </summary>
        /// <remarks>Thsi field is required.</remarks>
        [Field("category_type", IsRequired = true)]
        [Patch(nameof(isCategoryTypeModified))]
        public CategoryType? CategoryType
        {
            get => categoryType;
            set
            {
                isCategoryTypeModified = true;
                categoryType = value;
            }
        }
        private bool isCategoryTypeModified = false;
        private CategoryType? categoryType;

        /// <summary>
        /// If true, this Category has a Eula or there is a default Eula.
        /// </summary>
        [Field("eula")]
        [Patch(nameof(isHasEulaModified))]
        public bool? HasEula
        {
            get => hasEula;
            set
            {
                isHasEulaModified = true;
                hasEula = value;
            }
        }
        private bool isHasEulaModified = false;
        private bool? hasEula;

        /// <value>Sets the Eula text for the Category.</value>
        /// <remarks>Can only be used to set the Eula text; this field will never have content after deserialization.</remarks>
        [Field(SerializeAs = "eula_text")]
        [Patch(nameof(isEulaTextModified))]
        public string EulaText
        {
            get => eulaText;
            set
            {
                isEulaTextModified = true;
                eulaText = value;
            }
        }
        private bool isEulaTextModified = false;
        private string eulaText;

        /// <value>Sets whether the Category uses the default Eula or its own.</value>
        /// <remarks>
        /// <para>Can only be used to set the Eula text; this field will never have content after deserialization.</para>
        /// <para>(TODO: check)Setting this to true while there is no default Eula set will not throw an error.</para>
        /// </remarks>
        [Field(SerializeAs = "use_default_eula")]
        [Patch(nameof(isUsesDefaultEulaModified))]
        public bool? UsesDefaultEula
        {
            get => usesDefaultEula;
            set
            {
                isUsesDefaultEulaModified = true;
                usesDefaultEula = value;
            }
        }
        private bool isUsesDefaultEulaModified = false;
        private bool? usesDefaultEula;

        /// <value>If true, then the user will be emailed with details when the asset is checked in or out.</value>
        [Field("checkin_email")]
        [Patch(nameof(isEmailUserOnCheckInOrOutModified))]
        public bool? EmailUserOnCheckInOrOut
        {
            get => emailUserOnCheckInOrOut;
            set
            {
                isEmailUserOnCheckInOrOutModified = true;
                emailUserOnCheckInOrOut = value;
            }
        }
        private bool isEmailUserOnCheckInOrOutModified = false;
        private bool? emailUserOnCheckInOrOut;

        /// <value>If true, then the user must confirm acceptance of assets in this category.</value>
        [Field("require_acceptance")]
        [Patch(nameof(isIsAcceptanceRequiredModified))]
        public bool? IsAcceptanceRequired
        {
            get => isAcceptanceRequired;
            set
            {
                isIsAcceptanceRequiredModified = true;
                isAcceptanceRequired = value;
            }
        }
        private bool isIsAcceptanceRequiredModified = false;
        private bool? isAcceptanceRequired;

        /// <value>The number of assets in this category.</value>
        [Field(DeserializeAs = "assets_count")]
        public int? AssetsCount { get; private set; }

        /// <value>The number of accessories in this category.</value>
        [Field(DeserializeAs = "accessories_count")]
        public int? AccessoriesCount { get; private set; }

        /// <value>The number of consumables in this category.</value>
        [Field(DeserializeAs = "consumables_count")]
        public int? ConsumablesCount { get; private set; }

        /// <value>The number of components in this category.</value>
        [Field(DeserializeAs = "components_count")]
        public int? ComponentsCount { get; private set; }

        /// <value>The number of licenses in this category.</value>
        [Field(DeserializeAs = "licenses_count")]
        public int? LicensesCount { get; private set; }

        /// <value>The number of items in this category</value>
        public int? ItemCount
        {
            get
            {
                switch(CategoryType)
                {
                    case Enumerations.CategoryType.Accessory:
                        return AccessoriesCount;
                    case Enumerations.CategoryType.Asset:
                        return AssetsCount;
                    case Enumerations.CategoryType.Component:
                        return ComponentsCount;
                    case Enumerations.CategoryType.Consumable:
                        return ConsumablesCount;
                    case Enumerations.CategoryType.License:
                        return LicensesCount;
                    default:
                        return null;
                }
            }
        }

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public AvailableAction AvailableActions { get; private set; }

        void IPatchable.SetAllModifiedState(bool isModified)
        {
            isNameModified = isModified;
            isCategoryTypeModified = isModified;
            isHasEulaModified = isModified;
            isEulaTextModified = isModified;
            isUsesDefaultEulaModified = isModified;
            isEmailUserOnCheckInOrOutModified = isModified;
            isIsAcceptanceRequiredModified = isModified;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            ((IPatchable)this).SetAllModifiedState(false);
        }
    }
}
