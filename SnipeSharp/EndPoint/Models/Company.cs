using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// A Company.
    /// Companies own assets, licenses, components, etc., and has users that work for it.
    /// </summary>
    [PathSegment("companies")]
    public sealed class Company : CommonEndPointModel, IAvailableActions
    {
        /// <inheritdoc />
        [Field("id")]
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required, and must be unique.</remarks>
        [Field("name", true, required: true)]
        public override string Name { get; set; }

        /// <summary>
        /// The url for the image of this company.
        /// </summary>
        [Field("image")]
        public Uri ImageUri { get; set; }

        /// <inheritdoc />
        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <value>The number of assets this company owns.</value>
        [Field("assets_count")]
        public int AssetsCount { get; set; }

        /// <value>The number of licenses this company owns.</value>
        [Field("licenses_count")]
        public int LicensesCount { get; set; }

        /// <value>The number of accessories this company owns.</value>
        [Field("accessories_count")]
        public int AccessoriesCount { get; set; }

        /// <value>The number of consumables this company owns.</value>
        [Field("consumables_count")]
        public int ConsumablesCount { get; set; }

        /// <value>The number of components this company owns.</value>
        [Field("components_count")]
        public int ComponentsCount { get; set; }

        /// <value>The number of users in this company.</value>
        [Field("users_count")]
        public int UsersCount { get; set; }
        
        /// <inheritdoc />
        [Field("available_actions", converter: AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }
    }
}
