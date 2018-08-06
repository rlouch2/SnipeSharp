using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// A Manufacturer.
    /// Manufacturers create accessories, consumables, licenses, and models (models are associated with assets).
    /// </summary>
    [PathSegment("manufacturers")]
    public sealed class Manufacturer : CommonEndPointModel, IAvailableActions
    {
        /// <inheritdoc />
        [Field("id")]
        public override int Id { get; protected set; }

        [Field("name")]
        public override string Name { get; set; }

        [Field("url")]
        public Uri Url { get; set; }

        [Field("image")]
        public Uri ImageUri { get; set; }

        [Field("support_url")]
        public Uri SupportUrl { get; set; }

        [Field("support_phone")]
        public string SupportPhoneNumber { get; set; }

        [Field("support_email")]
        public string SupportEmailAddress { get; set; }

        [Field("assets_count")]
        public int? AssetsCount { get; set; }

        [Field("licenses_count")]
        public int? LicensesCount { get; set; }

        [Field("consumables_count")]
        public int? ConsumablesCount { get; set; }

        [Field("accessories_count")]
        public int? AccessoriesCount { get; set; }

        /// <inheritdoc />
        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        [Field("deleted_at", converter: DateTimeConverter)]
        public DateTime? DeletedAt { get; set; }

        /// <inheritdoc />
        [Field("available_actions", converter: AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }
    }
}
