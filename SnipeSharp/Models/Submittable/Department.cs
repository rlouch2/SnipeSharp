using System;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;
using System.Runtime.Serialization;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A Department.
    /// Departments structure Users within a Company.
    /// </summary>
    [PathSegment("departments")]
    public sealed class Department : CommonEndPointModel, IAvailableActions, IPatchable
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
        [Patch(nameof(isNameModified))]
        public override string Name
        {
            get => name;
            set
            {
                isNameModified = true;
                name = value;
            }
        }
        private bool isNameModified = false;
        private string name;

        /// <value>The url for the image of the department.</value>
        [Field("image")]
        [Patch(nameof(isImageUriModified))]
        public Uri ImageUri
        {
            get => imageUri;
            set
            {
                isImageUriModified = true;
                imageUri = value;
            }
        }
        private bool isImageUriModified = false;
        private Uri imageUri;

        /// <value>The company this department is a part of.</value>
        [Field(DeserializeAs = "company", SerializeAs = "company_id", Converter = CommonModelConverter)]
        [Patch(nameof(isCompanyModified))]
        public Company Company
        {
            get => company;
            set
            {
                isCompanyModified = true;
                company = value;
            }
        }
        private bool isCompanyModified = false;
        private Company company;

        /// <value>The manager of the department.</value>
        [Field(DeserializeAs = "manager", SerializeAs = "manager_id", Converter = CommonModelConverter)]
        [Patch(nameof(isManagerModified))]
        public User Manager
        {
            get => manager;
            set
            {
                isManagerModified = true;
                manager = value;
            }
        }
        private bool isManagerModified = false;
        private User manager;

        /// <value>Where this department is located.</value>
        [Field(DeserializeAs = "location", SerializeAs = "location_id", Converter = CommonModelConverter)]
        [Patch(nameof(isLocationModified))]
        public Location Location
        {
            get => location;
            set
            {
                isLocationModified = true;
                location = value;
            }
        }
        private bool isLocationModified = false;
        private Location location;

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
        public AvailableAction AvailableActions { get; private set; }

        void IPatchable.SetAllModifiedState(bool isModified)
        {
            isNameModified = isModified;
            isImageUriModified = isModified;
            isCompanyModified = isModified;
            isManagerModified = isModified;
            isLocationModified = isModified;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            ((IPatchable)this).SetAllModifiedState(false);
        }
    }
}
