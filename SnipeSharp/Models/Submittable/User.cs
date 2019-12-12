using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A user.
    /// </summary>
    [PathSegment("users")]
    public sealed class User : CommonEndPointModel, IAvailableActions, IUpdatable<User>
    {
        /// <summary>Create a new User object.</summary>
        public User() { }

        /// <summary>Create a new User object with the supplied ID, for use with updating.</summary>
        internal User(int id)
        {
            Id = id;
        }

        /// <inheritdoc />
        [Field(DeserializeAs = "id")]
        public override int Id { get; protected set; }

        /// <value>The URL of the user's gravatar.</value>
        [Field(DeserializeAs = "gravatar")]
        public Uri AvatarUrl { get; set; }

        /// <value>Gets the user's name.</value>
        /// <remarks>This field cannot be used to set a user's name.</remarks>
        [Field(DeserializeAs = "name")]
        public override string Name { get; set; }

        /// <value>Gets/sets the user's first name.</value>
        /// <remarks>This field is required.</remarks>
        [Field("first_name", IsRequired = true)]
        public string FirstName { get; set; }

        /// <value>Gets/sets the user's last name.</value>
        [Field("last_name")]
        public string LastName { get; set; }

        /// <value>Gets/sets the user's username.</value>
        /// <remarks>This field is required.</remarks>
        [Field("username", IsRequired = true)]
        public string UserName { get; set; }

        /// <value>Sets the user's password.</value>
        /// <remarks>This field is required.</remarks>
        [Field("password", IsRequired = true)]
        public string Password { private get; set; }

        /// <summary>Confirms the user's password.</summary>
        /// <remarks>Must match <see cref="Password"/>.</remarks>
        [Field(SerializeAs = "password_confirmation", IsRequired = true)]
        public string PasswordConfirmation { private get; set; }

        /// <value>Gets/sets the user's employee number.</value>
        [Field("employee_num")]
        public string EmployeeNumber { get; set; }

        /// <value>Gets/sets the user's manager.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "manager", SerializeAs = "manager_id", Converter = CommonModelConverter)]
        public User Manager { get; set; }

        /// <value>Gets/sets the title of the user's job.</value>
        [Field("jobtitle")]
        public string JobTitle { get; set; }

        /// <value>Gets/sets the user's phone number.</value>
        [Field("phone")]
        public string PhoneNumber { get; set; }

        /// <value>Gets/sets the user's address.</value>
        [Field("address")]
        public string Address { get; set; }

        /// <value>Gets/sets the city of the user's address.</value>
        [Field("city")]
        public string City { get; set; }

        /// <value>Gets/sets the state of the user's address.</value>
        [Field("state")]
        public string State { get; set; }

        /// <value>Gets/sets the country of the user's address.</value>
        [Field("country")]
        public string Country { get; set; }

        /// <value>Gets/sets the zip code of the user's address.</value>
        [Field("zip")]
        public string ZipCode { get; set; }

        /// <value>Gets/sets the user's email address.</value>
        [Field("email")]
        public string EmailAddress { get; set; }

        /// <value>Gets/sets the user's department.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "department", SerializeAs = "department_id", Converter = CommonModelConverter)]
        public Department Department { get; set; }

        /// <value>Gets/sets the user's location.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "location", SerializeAs = "location_id", Converter = CommonModelConverter)]
        public Location Location { get; set; }

        /// <value>Gets the user's notes or description.</value>
        /// <remarks>Currently, this field cannot be set.</remarks>
        [Field(DeserializeAs = "notes")]
        public string Notes { get; private set; }

        /// <value>Gets the user's permissions.</value>
        [Field(DeserializeAs = "permissions", Converter = PermissionsConverter)]
        public Dictionary<string, bool> Permissions { get; private set; }

        /// <value>Gets/sets if this user has been activated.</value>
        [Field("activated")]
        public bool? IsActivated { get; set; }

        /// <value>Gets if the user has activated two-factor authentication.</value>
        [Field(DeserializeAs = "two_factor_activated")]
        public bool? IsTwoFactorActivated { get; private set; }

        /// <value>Gets the number of assets assigned to this user.</value>
        [Field(DeserializeAs = "assets_count")]
        public int? AssetsCount { get; private set; }

        /// <value>Gets the number of licenses assigned to this user.</value>
        [Field(DeserializeAs = "licenses_count")]
        public int? LicensesCount { get; private set; }

        /// <value>Gets the number of accessories assigned to this user.</value>
        [Field(DeserializeAs = "accessories_count")]
        public int? AccessoriesCount { get; private set; }

        /// <value>Gets the number of consumables assigned to this user.</value>
        [Field(DeserializeAs = "consumables_count")]
        public int? ConsumablesCount { get; private set; }

        /// <value>Gets/sets the company this user works for.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "company", SerializeAs = "company_id", Converter = CommonModelConverter)]
        public Company Company { get; set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <value>Gets the date this user last logged on.</value>
        [Field(DeserializeAs = "last_login", Converter = DateTimeConverter)]
        public DateTime? LastLogin { get; private set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }

        /// <value>Gets the groups this user is a member of.</value>
        [Field("groups", Converter = CommonModelArrayConverter)]
        public ResponseCollection<Group> Groups { get; set; }

        /// <inheritdoc />
        public User CloneForUpdate() => new User(this.Id);

        /// <inheritdoc />
        public User WithValuesFrom(User other)
            => new User(this.Id)
            {
                AvatarUrl = other.AvatarUrl,
                Name = other.Name,
                FirstName = other.FirstName,
                UserName = other.UserName,
                Password = other.Password,
                PasswordConfirmation = other.PasswordConfirmation,
                EmployeeNumber = other.EmployeeNumber,
                Manager = other.Manager,
                JobTitle = other.JobTitle,
                PhoneNumber = other.PhoneNumber,
                Address = other.Address,
                City = other.City,
                State = other.State,
                Country = other.Country,
                ZipCode = other.ZipCode,
                EmailAddress = other.EmailAddress,
                Department = other.Department,
                Location = other.Location,
                IsActivated = other.IsActivated,
                Company = other.Company,
                Groups = other.Groups
            };
    }
}
