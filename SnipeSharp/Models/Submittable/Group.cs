using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A group.
    /// Groups are used to grant permissions to users in Snipe-IT.
    /// </summary>
    [PathSegment("groups")]
    public sealed class Group : CommonEndPointModel, IAvailableActions, IUpdatable<Group>
    {
        /// <summary>Create a new Group object.</summary>
        public Group() { }

        /// <summary>Create a new Group object with the supplied ID, for use with updating.</summary>
        internal Group(int id)
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

        /// <inheritdoc />
        // TODO: change this to a more explicit "GroupPermissions" type and make it required (I think it may need to be required)
        [Field(DeserializeAs = "permissions", Converter = PermissionsConverter)]
        public Dictionary<string, bool> Permissions { get; private set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "users_count")]
        public int? UsersCount { get; private set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; private set; }

        /// <inheritdoc />
        public Group CloneForUpdate() => new Group(this.Id);

        /// <inheritdoc />
        public Group WithValuesFrom(Group other)
            => new Group(this.Id)
            {
                Name = other.Name
            };
    }
}
