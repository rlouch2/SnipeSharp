using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A supplier.
    /// Suppliers sell assets, licenses, and accessories.
    /// </summary>
    [PathSegment("suppliers")]
    public sealed class Supplier : CommonEndPointModel, IAvailableActions
    {
        /// <inheritdoc />
        [Field(DeserializeAs = "id")]
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required and must be unique among undeleted suppliers.</remarks>
        [Field("name", IsRequired = true)]
        public override string Name { get; set; }

        /// <value>The URL of the image for this supplier.</value>
        [Field("image")]
        public Uri ImageUri { get; set; }

        /// <value>Gets/sets the first address line for this supplier.</value>
        [Field("address")]
        public string Address { get; set; }

        /// <value>Gets/sets the second address line for this supplier.</value>
        [Field("address2")]
        public string Address2 { get; set; }

        /// <value>Gets/sets the city this supplier is in.</value>
        [Field("city")]
        public string City { get; set; }

        /// <value>Gets/sets the state this supplier is in.</value>
        [Field("state")]
        public string State { get; set; }

        /// <value>Gets/sets the country this supplier is in.</value>
        [Field("country")]
        public string Country { get; set; }

        /// <value>Gets/sets the Zip Code area this supplier is in.</value>
        [Field("zip")]
        public string ZipCode { get; set; }

        /// <value>Gets/sets the fax number for this supplier.</value>
        [Field("fax")]
        public string FaxNumber { get; set; }

        /// <value>Gets/sets the phone number for this supplier.</value>
        [Field("phone")]
        public string PhoneNumber { get; set; }

        /// <value>Gets/sets the contact email address for this supplier.</value>
        [Field("email")]
        public string EmailAddress { get; set; }

        /// <value>Gets the contact for this supplier.</value>
        [Field("contact")]
        public string Contact { get; set; }

        /// <value>Gets the number of assets purchased from this supplier.</value>
        [Field(DeserializeAs = "assets_count")]
        public int? AssetsCount { get; private set; }

        /// <value>Gets the number of accessories purchased from this supplier.</value>
        [Field(DeserializeAs = "accessories_count")]
        public int? AccessoriesCount { get; private set; }

        /// <value>Gets the number of licenses purchased from this supplier</value>
        [Field(DeserializeAs = "licenses_count")]
        public int? LicensesCount { get; private set; }

        /// <value>Gets/sets the notes or description for this supplier.</value>
        [Field("notes")]
        public string Notes { get; set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }
        
        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }
    }
}
