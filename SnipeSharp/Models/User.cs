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
    public sealed class User : CommonEndPointModel, IAvailableActions
    {
        /// <inheritdoc />
        [Field("id")]
        public override int Id { get; protected set; }

        /// <value>The URL of the user's gravatar.</value>
        [Field("gravatar")]
        public Uri AvatarUrl { get; set; }

        /// <value>Gets the user's name.</value>
        /// <remarks>This field cannot be used to set a user's name.</remarks>
        [Field("name")]
        public override string Name { get; set; }

        /// <value>Gets/sets the user's first name.</value>
        /// <remarks>This field is required.</remarks>
        [Field("first_name", true, required: true)]
        public string FirstName { get; set; }

        /// <value>Gets/sets the user's last name.</value>
        [Field("last_name", true)]
        public string LastName { get; set; }

        /// <value>Gets/sets the user's username.</value>
        /// <remarks>This field is required.</remarks>
        [Field("username", true, required: true)]
        public string UserName { get; set; }

        /// <value>Sets the user's password.</value>
        /// <remarks>This field is required.</remarks>
        [Field("password", true, required: true)]
        public string Password { private get; set; }

        /// <value>Gets/sets the user's employee number.</value>
        [Field("employee_num", true)]
        public string EmployeeNumber { get; set; }

        /// <value>Gets/sets the user's manager.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("manager", "manager_id", converter: CommonModelConverter)]
        public User Manager { get; set; }

        /// <value>Gets/sets the title of the user's job.</value>
        [Field("jobtitle", true)]
        public string JobTitle { get; set; }

        /// <value>Gets/sets the user's phone number.</value>
        [Field("phone", true)]
        public string PhoneNumber { get; set; }

        /// <value>Gets/sets the user's address.</value>
        [Field("address", true)]
        public string Address { get; set; }

        /// <value>Gets/sets the city of the user's address.</value>
        [Field("city", true)]
        public string City { get; set; }

        /// <value>Gets/sets the state of the user's address.</value>
        [Field("state", true)]
        public string State { get; set; }

        /// <value>Gets/sets the country of the user's address.</value>
        [Field("country", true)]
        public string Country { get; set; }

        /// <value>Gets/sets the zip code of the user's address.</value>
        [Field("zip", true)]
        public string ZipCode { get; set; }

        /// <value>Gets/sets the user's email address.</value>
        [Field("email", true)]
        public string EmailAddress { get; set; }

        /// <value>Gets/sets the user's department.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("department", "department_id", converter: CommonModelConverter)]
        public Department Department { get; set; }

        /// <value>Gets/sets the user's location.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("location", "location_id", converter: CommonModelConverter)]
        public Location Location { get; set; }

        /// <value>Gets the user's notes or description.</value>
        /// <remarks>Currently, this field cannot be set.</remarks>
        [Field("notes")]
        public string Notes { get; private set; }

        /// <value>Gets the user's permissions.</value>
        [Field("permissions", converter: PermissionsConverter)]
        public Dictionary<string, bool> Permissions { get; private set; }

        /// <value>Gets/sets if this user has been activated.</value>
        [Field("activated", true)]
        public bool? IsActivated { get; set; }

        /// <value>Gets if the user has activated two-factor authentication.</value>
        [Field("two_factor_activated")]
        public bool? IsTwoFactorActivated { get; private set; }

        /// <value>Gets the number of assets assigned to this user.</value>
        [Field("assets_count")]
        public int? AssetsCount { get; private set; }

        /// <value>Gets the number of licenses assigned to this user.</value>
        [Field("licenses_count")]
        public int? LicensesCount { get; private set; }

        /// <value>Gets the number of accessories assigned to this user.</value>
        [Field("accessories_count")]
        public int? AccessoriesCount { get; private set; }

        /// <value>Gets the number of consumables assigned to this user.</value>
        [Field("consumables_count")]
        public int? ConsumablesCount { get; private set; }

        /// <value>Gets/sets the company this user works for.</value>
        /// <remarks>
        /// <para>This field will be converted to the value of its Id when serialized.</para>
        /// <para>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</para>
        /// </remarks>
        [Field("company", "company_id", converter: CommonModelConverter)]
        public Company Company { get; set; }

        /// <inheritdoc />
        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <value>Gets the date this user last logged on.</value>
        [Field("last_login", converter: DateTimeConverter)]
        public DateTime? LastLogin { get; private set; }

        /// <inheritdoc />
        [Field("available_actions", converter: AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }

        /// <value>Gets the groups this user is a member of.</value>
        [Field("groups")]
        public ResponseCollection<Group> Groups { get; private set; }
    }
}
