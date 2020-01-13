using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A Company.
    /// Companies own assets, licenses, components, etc., and has users that work for it.
    /// </summary>
    [PathSegment("companies")]
    public sealed class Company : CommonEndPointModel, IAvailableActions, IUpdatable<Company>, IPatchable
    {
        /// <summary>Create a new Company object.</summary>
        public Company() { }

        /// <summary>Create a new Company object with the supplied ID, for use with updating.</summary>
        internal Company(int id)
        {
            Id = id;
        }

        /// <inheritdoc />
        [Field(DeserializeAs = "id")]
        public override int Id { get; set; }

        private string name;
        private bool isNameModified;
        /// <inheritdoc />
        /// <remarks>This field is required, and must be unique.</remarks>
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

        private Uri imageUri;
        private bool isImageUriModified;
        /// <summary>
        /// The url for the image of this company.
        /// </summary>
        [Field(DeserializeAs = "image")]
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

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <value>The number of assets this company owns.</value>
        [Field(DeserializeAs = "assets_count")]
        public int AssetsCount { get; set; }

        /// <value>The number of licenses this company owns.</value>
        [Field(DeserializeAs = "licenses_count")]
        public int LicensesCount { get; set; }

        /// <value>The number of accessories this company owns.</value>
        [Field(DeserializeAs = "accessories_count")]
        public int AccessoriesCount { get; set; }

        /// <value>The number of consumables this company owns.</value>
        [Field(DeserializeAs = "consumables_count")]
        public int ConsumablesCount { get; set; }

        /// <value>The number of components this company owns.</value>
        [Field(DeserializeAs = "components_count")]
        public int ComponentsCount { get; set; }

        /// <value>The number of users in this company.</value>
        [Field(DeserializeAs = "users_count")]
        public int UsersCount { get; set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public AvailableAction AvailableActions { get; private set; }

        /// <inheritdoc />
        public Company CloneForUpdate() => new Company(this.Id);

        /// <inheritdoc />
        public Company WithValuesFrom(Company other)
            => new Company(this.Id)
            {
                Name = other.Name,
                ImageUri = other.ImageUri
            };

        void IPatchable.SetAllModifiedState(bool isModified)
        {
            isNameModified = isModified;
            isImageUriModified = isModified;
        }
    }
}
