using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A Category.
    /// Categories may be checked out to Assets, Accessories, Consumables and Components.
    /// </summary>
    [PathSegment("categories")]
    public sealed class Category : CommonEndPointModel, IAvailableActions, IUpdatable<Category>
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
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("name", IsRequired = true)]
        public override string Name { get; set; }

        /// <summary>
        /// Indicates the type of objects this category may contain.
        /// </summary>
        /// <remarks>Thsi field is required.</remarks>
        [Field("category_type", IsRequired = true)]
        public CategoryType? CategoryType { get; set; }

        /// <summary>
        /// If true, this Category has a Eula or there is a default Eula.
        /// </summary>
        [Field("eula")]
        public bool? HasEula { get; set; }

        /// <value>Sets the Eula text for the Category.</value>
        /// <remarks>Can only be used to set the Eula text; this field will never have content after deserialization.</remarks>
        [Field(SerializeAs = "eula_text")]
        public string EulaText { get; set; }

        /// <value>Sets whether the Category uses the default Eula or its own.</value>
        /// <remarks>
        /// <para>Can only be used to set the Eula text; this field will never have content after deserialization.</para>
        /// <para>(TODO: check)Setting this to true while there is no default Eula set will not throw an error.</para>
        /// </remarks>
        [Field(SerializeAs = "use_default_eula")]
        public bool? UsesDefaultEula { get; set; }

        /// <value>If true, then the user will be emailed with details when the asset is checked in or out.</value>
        [Field("checkin_email")]
        public bool? EmailUserOnCheckInOrOut { get; set; }

        /// <value>If true, then the user must confirm acceptance of assets in this category.</value>
        [Field("require_acceptance")]
        public bool? IsAcceptanceRequired { get; set; }

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
        public HashSet<AvailableAction> AvailableActions { get; set; }

        /// <inheritdoc />
        public Category CloneForUpdate() => new Category(this.Id);

        /// <inheritdoc />
        public Category WithValuesFrom(Category other)
            => new Category(this.Id)
            {
                Name = other.Name,
                CategoryType = other.CategoryType,
                HasEula = other.HasEula,
                EulaText = other.EulaText,
                UsesDefaultEula = other.UsesDefaultEula,
                EmailUserOnCheckInOrOut = other.EmailUserOnCheckInOrOut,
                IsAcceptanceRequired = other.IsAcceptanceRequired
            };
    }
}
