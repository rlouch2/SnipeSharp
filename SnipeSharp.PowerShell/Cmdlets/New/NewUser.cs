using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Creates a new Snipe-IT user.</summary>
    /// <remarks>The New-User cmdlet creates a new user object.</remarks>
    /// <example>
    ///   <code>New-User -FirstName "Craig" -UserName "cjohnson" -Password $Password</code>
    ///   <para>Create a new user named "cjohnson" with all required properties set.</para>
    /// </example>
    [Cmdlet(VerbsCommon.New, nameof(User))]
    [OutputType(typeof(User))]
    public class NewUser: BaseCmdlet
    {
        /// <summary>
        /// The uri of the image for the user's avatar.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Uri AvatarUrl { get; set; }

        /// <summary>
        /// The user's given name.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string FirstName { get; set; }

        /// <summary>
        /// The user's surname.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string LastName { get; set; }

        /// <summary>
        /// The unique username of the user.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string UserName { get; set; }

        /// <summary>
        /// The user's initial password.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Password { get; set; }

        /// <summary>
        /// The employee number of the user.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string EmployeeNumber { get; set; }

        /// <summary>
        /// The manager of the user.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public UserBinding Manager { get; set; }

        /// <summary>
        /// The title of the user's position.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string JobTitle { get; set; }

        /// <summary>
        /// The phone number for reaching the user.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The user's street address.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Address { get; set; }

        /// <summary>
        /// The user's address city.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string City { get; set; }

        /// <summary>
        /// The user's address country.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Country { get; set; }

        /// <summary>
        /// The user's address state.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string State { get; set; }

        /// <summary>
        /// The user's address zip code.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string ZipCode { get; set; }

        /// <summary>
        /// The email address for the user.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// The department the user works for.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Department> Department { get; set; }

        /// <summary>
        /// The location the user works at.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Location> Location { get; set; }

        /// <summary>
        /// The company the user works for.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Company> Company { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new User {
                AvatarUrl = this.AvatarUrl,
                FirstName = this.FirstName,
                LastName = this.LastName,
                UserName = this.UserName,
                Password = this.Password,
                EmployeeNumber = this.EmployeeNumber,
                JobTitle = this.JobTitle,
                PhoneNumber = this.PhoneNumber,
                Address = this.Address,
                City = this.City,
                Country = this.Country,
                State = this.State,
                ZipCode = this.ZipCode,
                EmailAddress = this.EmailAddress
            };
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Manager)))
            {
                if (!GetSingleValue(Manager, out var manager))
                    return;
                item.Manager = manager;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Department)))
            {
                if (!GetSingleValue(Department, out var department))
                    return;
                item.Department = department;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
            {
                if (!GetSingleValue(Location, out var location))
                    return;
                item.Location = location;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
            {
                if (!GetSingleValue(Company, out var company))
                    return;
                item.Company = company;
            }
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Users.Create(item));
        }
    }
}
