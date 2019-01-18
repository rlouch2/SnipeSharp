using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A Manufacturer.
    /// Manufacturers create accessories, consumables, licenses, and models (models are associated with assets).
    /// </summary>
    [PathSegment("manufacturers")]
    public sealed class Manufacturer : CommonEndPointModel, IAvailableActions
    {
        /// <inheritdoc />
        [Field(DeserializeAs = "id")]
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("name", IsRequired = true)]
        public override string Name { get; set; }

        /// <value>Gets/sets the URL for the Manufacturer's website.</value>
        [Field("url")]
        public Uri Url { get; set; }

        /// <value>Gets/sets the URL of the image for the Manufacturer.</value>
        [Field("image")]
        public Uri ImageUri { get; set; }

        /// <value>Gets/sets the url of the manufacturer's support site.</value>
        [Field("support_url")]
        public Uri SupportUrl { get; set; }

        
        /// <value>Gets/sets the manufacturer's support phone number.</value>
        [Field("support_phone")]
        public string SupportPhoneNumber { get; set; }

        /// <value>Gets/sets the manufacturer's support email address.</value>
        [Field("support_email")]
        public string SupportEmailAddress { get; set; }

        /// <value>The number of assets produced by this manufacturer.</value>
        [Field(DeserializeAs = "assets_count")]
        public int? AssetsCount { get; private set; }

        /// <value>The number of licenses produced by this manufacturer.</value>
        [Field(DeserializeAs = "licenses_count")]
        public int? LicensesCount { get; private set; }

        /// <value>The number of consumables produced by this manufacturer.</value>
        [Field(DeserializeAs = "consumables_count")]
        public int? ConsumablesCount { get; private set; }

        /// <value>The number of accessories produced by this manufacturer.</value>
        [Field(DeserializeAs = "accessories_count")]
        public int? AccessoriesCount { get; private set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <value>Gets the date this manufacturer was deleted.</value>
        [Field(DeserializeAs = "deleted_at", Converter = DateTimeConverter)]
        public DateTime? DeletedAt { get; private set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }
    }
}
