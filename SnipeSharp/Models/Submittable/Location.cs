using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A Location.
    /// </summary>
    [PathSegment("locations")]
    public sealed class Location : CommonEndPointModel, IAvailableActions, IUpdatable<Location>
    {
        /// <summary>Create a new Location object.</summary>
        public Location() { }

        /// <summary>Create a new Location object with the supplied ID, for use with updating.</summary>
        internal Location(int id)
        {
            Id = id;
        }

        /// <inheritdoc />
        [Field(DeserializeAs = "id")]
        public override int Id { get; set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("name", IsRequired = true)]
        public override string Name { get; set; }

        /// <value>The URL of the image for this location.</value>
        [Field("image")]
        public Uri ImageUri { get; set; }

        /// <value>Gets/sets the first address line for this location.</value>
        [Field("address")]
        public string Address { get; set; }

        /// <value>Gets/sets the second address line for this location.</value>
        [Field("address2")]
        public string Address2 { get; set; }

        /// <value>Gets/sets the city this location is in.</value>
        [Field("city")]
        public string City { get; set; }

        /// <value>Gets/sets the city this location is in.</value>
        [Field("state")]
        public string State { get; set; }

        /// <value>Gets/sets the city this location is in.</value>
        [Field("country")]
        public string Country { get; set; }

        /// <value>Gets/sets the Zip Code area this location is in.</value>
        [Field("zip")]
        public string ZipCode { get; set; }

        /// <value>The number of assets assigned to this location.</value>
        [Field(DeserializeAs = "assigned_assets_count")]
        public int? AssignedAssetsCount { get; private set; }

        /// <value>The number of assets at this location.</value>
        [Field(DeserializeAs = "assets_count")]
        public int? AssetsCount { get; private set; }

        /// <value>The number of users at this location.</value>
        [Field(DeserializeAs = "users_count")]
        public int? UsersCount { get; private set; }

        /// <value>Gets/sets the type of currency used at this location.</value>
        [Field("currency")]
        public string Currency { get; set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <value>Gets/sets the parent location for this location.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "parent", SerializeAs = "parent_id", Converter = CommonModelConverter)]
        public Location ParentLocation { get; set; }

        /// <value>The manager for this location.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "manager", SerializeAs = "manager_id", Converter = CommonModelConverter)]
        public User Manager { get; set; }

        /// <value>The list of child locations for this location.</value>
        /// <remarks>When deserialized, these values do not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</remarks>
        [Field(DeserializeAs = "children")]
        public List<Location> ChildLocations { get; private set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; private set; }

        /// <inheritdoc />
        public Location CloneForUpdate() => new Location(this.Id);

        /// <inheritdoc />
        public Location WithValuesFrom(Location other)
            => new Location(this.Id)
            {
                Name = other.Name,
                ImageUri = other.ImageUri,
                Address = other.Address,
                Address2 = other.Address2,
                City = other.City,
                State = other.State,
                Country = other.Country,
                ZipCode = other.ZipCode,
                Currency = other.Currency,
                ParentLocation = other.ParentLocation,
                Manager = other.Manager
            };
    }
}
