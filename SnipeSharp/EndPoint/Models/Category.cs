using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// A Category.
    /// Categories may be checked out to Assets, Accessories, Consumables and Components.
    /// </summary>
    [PathSegment("categories")]
    public sealed class Category : CommonEndPointModel, IAvailableActions
    {
        /// <inheritdoc />

        [Field("id")]
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("name", true, required: true)]
        public override string Name { get; set; }

        /// <summary>
        /// Indicates the type of objects this category may contain.
        /// </summary>
        /// <remarks>Thsi field is required.</remarks>
        [Field("category_type", true, required: true)]
        public CategoryType? CategoryType { get; set; }

        /// <summary>
        /// If true, this Category has a Eula or there is a default Eula.
        /// </summary>
        [Field("eula")]
        public bool? HasEula { get; set; }

        /// <value>Sets the Eula text for the Category.</value>
        /// <remarks>Can only be used to set the Eula text; this field will never have content after deserialization.</remarks>
        [Field(null, "eula_text")]
        public string EulaText { get; set; }

        /// <value>Sets whether the Category uses the default Eula or its own.</value>
        /// <remarks>
        /// <para>Can only be used to set the Eula text; this field will never have content after deserialization.</para>
        /// <para>(TODO: check)Setting this to true while there is no default Eula set will not throw an error.</para>
        /// </remarks>
        [Field(null, "use_default_eula")]
        public bool? UsesDefaultEula { get; set; }

        /// <value>If true, then the user will be emailed with details when the asset is checked in or out.</value>
        [Field("checkin_email", true)]
        public bool? EmailUserOnCheckInOrOut { get; set; }

        /// <value>If true, then the user must confirm acceptance of assets in this category.</value>
        [Field("require_acceptance", true)]
        public bool? IsAcceptanceRequired { get; set; }

        /// <value>The number of assets in this category.</value>
        [Field("assets_count")]
        public int? AssetsCount { get; private set; }

        /// <value>The number of accessories in this category.</value>
        [Field("accessories_count")]
        public int? AccessoriesCount { get; private set; }

        /// <value>The number of consumables in this category.</value>
        [Field("consumables_count")]
        public int? ConsumablesCount { get; private set; }

        /// <value>The number of components in this category.</value>
        [Field("copmonents_count")]
        public int? ComponentsCount { get; private set; }

        /// <value>The number of licenses in this category.</value>
        [Field("licenses_count")]
        public int? LicensesCount { get; private set; }

        /// <inheritdoc />
        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }
        
        /// <inheritdoc />
        [Field("available_actions", converter: AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }
    }
}
