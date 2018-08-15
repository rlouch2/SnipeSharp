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
        [Field("id")]
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required and must be unique among undeleted suppliers.</remarks>
        [Field("name", true, required: true)]
        public override string Name { get; set; }

        /// <value>The URL of the image for this supplier.</value>
        [Field("image", true)]
        public Uri ImageUri { get; set; }

        /// <value>Gets/sets the first address line for this supplier.</value>
        [Field("address", true)]
        public string Address { get; set; }

        /// <value>Gets/sets the second address line for this supplier.</value>
        [Field("address2", true)]
        public string Address2 { get; set; }

        /// <value>Gets/sets the city this supplier is in.</value>
        [Field("city", true)]
        public string City { get; set; }

        /// <value>Gets/sets the state this supplier is in.</value>
        [Field("state", true)]
        public string State { get; set; }

        /// <value>Gets/sets the country this supplier is in.</value>
        [Field("country", true)]
        public string Country { get; set; }

        /// <value>Gets/sets the Zip Code area this supplier is in.</value>
        [Field("zip", true)]
        public string ZipCode { get; set; }

        /// <value>Gets/sets the fax number for this supplier.</value>
        [Field("fax", true)]
        public string FaxNumber { get; set; }

        /// <value>Gets/sets the phone number for this supplier.</value>
        [Field("phone", true)]
        public string PhoneNumber { get; set; }

        /// <value>Gets/sets the contact email address for this supplier.</value>
        [Field("email", true)]
        public string EmailAddress { get; set; }

        /// <value>Gets the contact for this supplier.</value>
        [Field("contact", true)]
        public string Contact { get; set; }

        /// <value>Gets the number of assets purchased from this supplier.</value>
        [Field("assets_count")]
        public int? AssetsCount { get; private set; }

        /// <value>Gets the number of accessories purchased from this supplier.</value>
        [Field("accessories_count")]
        public int? AccessoriesCount { get; private set; }

        /// <value>Gets the number of licenses purchased from this supplier</value>
        [Field("licenses_count")]
        public int? LicensesCount { get; private set; }

        /// <value>Gets/sets the notes or description for this supplier.</value>
        [Field("notes", true)]
        public string Notes { get; set; }

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
