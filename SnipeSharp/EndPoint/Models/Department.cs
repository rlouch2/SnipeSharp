using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// A Department.
    /// Departments structure Users within a Company.
    /// </summary>
    [PathSegment("departments")]
    public sealed class Department : CommonEndPointModel, IAvailableActions
    {
        /// <inheritdoc />
        [Field("id")]
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("name", true, required: true)]
        public override string Name { get; set; }

        /// <value>The url for the image of the department.</value>
        [Field("image", true)]
        public Uri ImageUri { get; set; }

        /// <value>The company this department is a part of.</value>
        [Field("company", "company_id", converter: CommonModelConverter)]
        public Company Company { get; set; }

        /// <value>The manager of the department.</value>
        [Field("manager", "manager_id", converter: CommonModelConverter)]
        public User Manager { get; set; }

        /// <value>Where this department is located.</value>
        [Field("location", "location_id", converter: CommonModelConverter)]
        public Location Location { get; set; }

        /* Disabled here until we can also read it from the API.
         * /// <value>The description for this department.</value>
         * [Field("notes", true)]
         * public string Notes { get; set; }
         */

        /// <value>The number of users in this department.</value>
        [Field("users_count")]
        public int UsersCount { get; private set; }

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
