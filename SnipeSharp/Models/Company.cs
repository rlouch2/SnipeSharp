using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A Company.
    /// Companies own assets, licenses, components, etc., and has users that work for it.
    /// </summary>
    [PathSegment("companies")]
    public sealed class Company : CommonEndPointModel, IAvailableActions
    {
        /// <inheritdoc />
        [Field(DeserializeAs = "id")]
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required, and must be unique.</remarks>
        [Field("name", IsRequired = true)]
        public override string Name { get; set; }

        /// <summary>
        /// The url for the image of this company.
        /// </summary>
        [Field(DeserializeAs = "image")]
        public Uri ImageUri { get; set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <value>The number of assets this company owns.</value>
        [Field(DeserializeAs = "assets_count")]
        public int AssetsCount { get; set; }

        /// <value>The number of licenses this company owns.</value>
        [Field(DeserializeAs = "licenses_count")]
        public int LicensesCount { get; set; }

        /// <value>The number of accessories this company owns.</value>
        [Field(DeserializeAs = "accessories_count")]
        public int AccessoriesCount { get; set; }

        /// <value>The number of consumables this company owns.</value>
        [Field(DeserializeAs = "consumables_count")]
        public int ConsumablesCount { get; set; }

        /// <value>The number of components this company owns.</value>
        [Field(DeserializeAs = "components_count")]
        public int ComponentsCount { get; set; }

        /// <value>The number of users in this company.</value>
        [Field(DeserializeAs = "users_count")]
        public int UsersCount { get; set; }
        
        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }
    }
}
