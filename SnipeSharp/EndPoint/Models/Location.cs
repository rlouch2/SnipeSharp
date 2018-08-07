using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// A Location.
    /// </summary>
    [PathSegment("locations")]
    public sealed class Location : CommonEndPointModel, IAvailableActions
    {
        /// <inheritdoc />
        [Field("id")]
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("name", true, required: true)]
        public override string Name { get; set; }

        /// <value>The URL of the image for this location.</value>
        [Field("image", true)]
        public Uri ImageUri { get; set; }

        /// <value>Gets/sets the first address line for this location.</value>
        [Field("address", true)]
        public string Address { get; set; }

        /// <value>Gets/sets the second address line for this location.</value>
        [Field("address2", true)]
        public string Address2 { get; set; }

        /// <value>Gets/sets the city this location is in.</value>
        [Field("city", true)]
        public string City { get; set; }

        /// <value>Gets/sets the city this location is in.</value>
        [Field("state", true)]
        public string State { get; set; }

        /// <value>Gets/sets the city this location is in.</value>
        [Field("country", true)]
        public string Country { get; set; }

        /// <value>Gets/sets the Zip Code area this location is in.</value>
        [Field("zip", true)]
        public string ZipCode { get; set; }

        /// <value>The number of assets assigned to this location.</value>
        [Field("assigned_assets_count")]
        public int? AssignedAssetsCount { get; private set; }

        /// <value>The number of assets at this location.</value>
        [Field("assets_count")]
        public int? AssetsCount { get; private set; }

        /// <value>The number of users at this location.</value>
        [Field("users_count")]
        public int? UsersCount { get; private set; }

        /// <value>Gets/sets the type of currency used at this location.</value>
        [Field("currency", true)]
        public string Currency { get; set; }

        /// <inheritdoc />
        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <value>Gets/sets the parent location for this location.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("parent", "parent_id", converter: CommonModelConverter)]
        public Location ParentLocation { get; set; }

        /// <value>The manager for this location.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// <para>This is not currently setable.</para>
        /// </remarks>
        [Field("manager", converter: CommonModelConverter)]
        public User Manager { get; private set; }

        /// <value>The list of child locations for this location.</value>
        /// <remarks>When deserialized, these values do not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</remarks>
        [Field("children")]
        public List<Location> ChildLocations { get; private set; }

        /// <inheritdoc />
        [Field("available_actions", converter: AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }

        /* TODO: not currently possible to get the LDAP OU.
         * /// <value>Gets/sets the LDAP OU associated with this location.</value>
         * [Field("ldap_ou", true)]
         * public string LDAPOU { get; set; }
         */
    }
}
