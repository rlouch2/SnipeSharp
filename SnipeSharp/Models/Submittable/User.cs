using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;
using System.Runtime.Serialization;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A user.
    /// </summary>
    [PathSegment("users")]
    public sealed class User : CommonEndPointModel, IAvailableActions, IPatchable
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
        public override int Id { get; set; }

        /// <value>The URL of the user's gravatar.</value>
        [Field(DeserializeAs = "gravatar")]
        [Patch(nameof(isAvatarUrlModified))]
        public Uri AvatarUrl
        {
            get => avatarUrl;
            set
            {
                isAvatarUrlModified = true;
                avatarUrl = value;
            }
        }
        private bool isAvatarUrlModified = false;
        private Uri avatarUrl;

        /// <value>Gets the user's name.</value>
        /// <remarks>This field cannot be used to set a user's name.</remarks>
        [Field(DeserializeAs = "name")]
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

        /// <value>Gets/sets the user's first name.</value>
        /// <remarks>This field is required.</remarks>
        [Field("first_name", IsRequired = true)]
        [Patch(nameof(isFirstNameModified))]
        public string FirstName
        {
            get => firstName;
            set
            {
                isFirstNameModified = true;
                firstName = value;
            }
        }
        private bool isFirstNameModified = false;
        private string firstName;

        /// <value>Gets/sets the user's last name.</value>
        [Field("last_name")]
        [Patch(nameof(isLastNameModified))]
        public string LastName
        {
            get => lastName;
            set
            {
                isLastNameModified = true;
                lastName = value;
            }
        }
        private bool isLastNameModified = false;
        private string lastName;

        /// <value>Gets/sets the user's username.</value>
        /// <remarks>This field is required.</remarks>
        [Field("username", IsRequired = true)]
        [Patch(nameof(isUserNameModified))]
        public string UserName
        {
            get => userName;
            set
            {
                isUserNameModified = true;
                userName = value;
            }
        }
        private bool isUserNameModified = false;
        private string userName;

        /// <value>Sets the user's password.</value>
        /// <remarks>This field is required.</remarks>
        [Field("password", IsRequired = true)]
        [Patch(nameof(isPasswordModified))]
        public string Password
        {
            private get => password;
            set
            {
                isPasswordModified = true;
                password = value;
            }
        }
        private bool isPasswordModified = false;
        private string password;

        /// <summary>Confirms the user's password.</summary>
        /// <remarks>Must match <see cref="Password"/>.</remarks>
        [Field(SerializeAs = "password_confirmation", IsRequired = true)]
        [Patch(nameof(isPasswordConfirmationModified))]
        public string PasswordConfirmation
        {
            private get => passwordConfirmation;
            set
            {
                isPasswordConfirmationModified = true;
                passwordConfirmation = value;
            }
        }
        private bool isPasswordConfirmationModified = false;
        private string passwordConfirmation;

        /// <value>Gets/sets the user's employee number.</value>
        [Field("employee_num")]
        [Patch(nameof(isEmployeeNumberModified))]
        public string EmployeeNumber
        {
            get => employeeNumber;
            set
            {
                isEmployeeNumberModified = true;
                employeeNumber = value;
            }
        }
        private bool isEmployeeNumberModified = false;
        private string employeeNumber;

        /// <value>Gets/sets the user's manager.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
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

        /// <value>Gets/sets the title of the user's job.</value>
        [Field("jobtitle")]
        [Patch(nameof(isJobTitleModified))]
        public string JobTitle
        {
            get => jobTitle;
            set
            {
                isJobTitleModified = true;
                jobTitle = value;
            }
        }
        private bool isJobTitleModified = false;
        private string jobTitle;

        /// <value>Gets/sets the user's phone number.</value>
        [Field("phone")]
        [Patch(nameof(isPhoneNumberModified))]
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                isPhoneNumberModified = true;
                phoneNumber = value;
            }
        }
        private bool isPhoneNumberModified = false;
        private string phoneNumber;

        /// <value>Gets/sets the user's address.</value>
        [Field("address")]
        [Patch(nameof(isAddressModified))]
        public string Address
        {
            get => address;
            set
            {
                isAddressModified = true;
                address = value;
            }
        }
        private bool isAddressModified = false;
        private string address;

        /// <value>Gets/sets the city of the user's address.</value>
        [Field("city")]
        [Patch(nameof(isCityModified))]
        public string City
        {
            get => city;
            set
            {
                isCityModified = true;
                city = value;
            }
        }
        private bool isCityModified = false;
        private string city;

        /// <value>Gets/sets the state of the user's address.</value>
        [Field("state")]
        [Patch(nameof(isStateModified))]
        public string State
        {
            get => state;
            set
            {
                isStateModified = true;
                state = value;
            }
        }
        private bool isStateModified = false;
        private string state;

        /// <value>Gets/sets the country of the user's address.</value>
        [Field("country")]
        [Patch(nameof(isCountryModified))]
        public string Country
        {
            get => country;
            set
            {
                isCountryModified = true;
                country = value;
            }
        }
        private bool isCountryModified = false;
        private string country;

        /// <value>Gets/sets the zip code of the user's address.</value>
        [Field("zip")]
        [Patch(nameof(isZipCodeModified))]
        public string ZipCode
        {
            get => zipCode;
            set
            {
                isZipCodeModified = true;
                zipCode = value;
            }
        }
        private bool isZipCodeModified = false;
        private string zipCode;

        /// <value>Gets/sets the user's email address.</value>
        [Field("email")]
        [Patch(nameof(isEmailAddressModified))]
        public string EmailAddress
        {
            get => emailAddress;
            set
            {
                isEmailAddressModified = true;
                emailAddress = value;
            }
        }
        private bool isEmailAddressModified = false;
        private string emailAddress;

        /// <value>Gets/sets the user's department.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field(DeserializeAs = "department", SerializeAs = "department_id", Converter = CommonModelConverter)]
        [Patch(nameof(isDepartmentModified))]
        public Department Department
        {
            get => department;
            set
            {
                isDepartmentModified = true;
                department = value;
            }
        }
        private bool isDepartmentModified = false;
        private Department department;

        /// <value>Gets/sets the user's location.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
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

        /// <value>Gets the user's notes or description.</value>
        /// <remarks>Currently, this field cannot be set.</remarks>
        [Field(DeserializeAs = "notes")]
        [Patch(nameof(isNotesModified))]
        public string Notes
        {
            get => notes;
            private set
            {
                isNotesModified = true;
                notes = value;
            }
        }
        private bool isNotesModified = false;
        private string notes;

        /// <value>Gets the user's permissions.</value>
        [Field(DeserializeAs = "permissions", Converter = PermissionsConverter)]
        public Dictionary<string, bool> Permissions { get; private set; }

        /// <value>Gets/sets if this user has been activated.</value>
        [Field("activated")]
        [Patch(nameof(isIsActivatedModified))]
        public bool? IsActivated
        {
            get => isActivated;
            set
            {
                isIsActivatedModified = true;
                isActivated = value;
            }
        }
        private bool isIsActivatedModified = false;
        private bool? isActivated;

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
        public AvailableAction AvailableActions { get; private set; }

        /// <value>Gets the groups this user is a member of.</value>
        [Field("groups", Converter = CommonModelArrayConverter)]
        [Patch(nameof(isGroupsModified))]
        public ResponseCollection<Group> Groups
        {
            get => groups;
            set
            {
                isGroupsModified = true;
                groups = value;
            }
        }
        private bool isGroupsModified = false;
        private ResponseCollection<Group> groups;

        void IPatchable.SetAllModifiedState(bool isModified)
        {
            isAvatarUrlModified = isModified;
            isNameModified = isModified;
            isFirstNameModified = isModified;
            isLastNameModified = isModified;
            isUserNameModified = isModified;
            isPasswordModified = isModified;
            isPasswordConfirmationModified = isModified;
            isEmployeeNumberModified = isModified;
            isManagerModified = isModified;
            isJobTitleModified = isModified;
            isPhoneNumberModified = isModified;
            isAddressModified = isModified;
            isCityModified = isModified;
            isStateModified = isModified;
            isCountryModified = isModified;
            isZipCodeModified = isModified;
            isEmailAddressModified = isModified;
            isDepartmentModified = isModified;
            isLocationModified = isModified;
            isNotesModified = isModified;
            isIsActivatedModified = isModified;
            isCompanyModified = isModified;
            isGroupsModified = isModified;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            ((IPatchable)this).SetAllModifiedState(false);
        }
    }
}
