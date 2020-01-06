using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A Department.
    /// Departments structure Users within a Company.
    /// </summary>
    [PathSegment("departments")]
    public sealed class Department : CommonEndPointModel, IAvailableActions, IUpdatable<Department>
    {
        /// <summary>Create a new Department object.</summary>
        public Department() { }

        /// <summary>Create a new Department object with the supplied ID, for use with updating.</summary>
        internal Department(int id)
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

        /// <value>The url for the image of the department.</value>
        [Field("image")]
        public Uri ImageUri { get; set; }

        /// <value>The company this department is a part of.</value>
        [Field(DeserializeAs = "company", SerializeAs = "company_id", Converter = CommonModelConverter)]
        public Company Company { get; set; }

        /// <value>The manager of the department.</value>
        [Field(DeserializeAs = "manager", SerializeAs = "manager_id", Converter = CommonModelConverter)]
        public User Manager { get; set; }

        /// <value>Where this department is located.</value>
        [Field(DeserializeAs = "location", SerializeAs = "location_id", Converter = CommonModelConverter)]
        public Location Location { get; set; }

        /* Disabled here until we can also read it from the API.
         * /// <value>The description for this department.</value>
         * [Field("notes", true)]
         * public string Notes { get; set; }
         */

        /// <value>The number of users in this department.</value>
        [Field(DeserializeAs = "users_count")]
        public int UsersCount { get; private set; }

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
        public Department CloneForUpdate() => new Department(this.Id);

        /// <inheritdoc />
        public Department WithValuesFrom(Department other)
            => new Department(this.Id)
            {
                Name = other.Name,
                ImageUri = other.ImageUri,
                Company = other.Company,
                Manager = other.Manager,
                Location = other.Location
            };
    }
}
