using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Changes the properties of an existing Snipe-IT user.</summary>
    /// <remarks>The Set-User cmdlet changes the properties of an existing Snipe-IT user object.</remarks>
    /// <example>
    ///   <code>Set-User -Identity "atuber" -LastName 'Spud'</code>
    ///   <para>Changes the last name of user "atuber" to "Spud" without updating their username.</para>
    /// </example>
    [Cmdlet(VerbsCommon.Set, nameof(User))]
    [OutputType(typeof(User))]
    public class SetUser: SetObject<User, UserBinding>
    {
        /// <summary>
        /// Extra parameter sets this cmdlet supports.
        /// </summary>
        internal enum UserParameterSets
        {
            ByUserName,
            ByEmailAddress
        }

        /// <summary>The username for the User.</summary>
        [Parameter(Mandatory = true, ParameterSetName = nameof(UserParameterSets.ByUserName))]
        public string UserName { get; set; }

        /// <summary>The email address for the User.</summary>
        [Parameter(Mandatory = true, ParameterSetName = nameof(UserParameterSets.ByEmailAddress))]
        public string EmailAddress { get; set; }

        /// <summary>
        /// The updated uri of the image for the user's avatar.
        /// </summary>
        [Parameter]
        public Uri AvatarUrl { get; set; }

        /// <summary>
        /// The user's new first name.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string FirstName { get; set; }

        /// <summary>
        /// The user's new surname.
        /// </summary>
        [Parameter]
        public string LastName { get; set; }

        /// <summary>
        /// The updated unique username for the user.
        /// </summary>
        [Parameter]
        public string NewUserName { get; set; }

        /// <summary>
        /// The updated password for the user.
        /// </summary>
        [Parameter]
        public string Password { get; set; }

        /// <summary>
        /// The updated employee number for the user.
        /// </summary>
        [Parameter]
        public string EmployeeNumber { get; set; }

        /// <summary>
        /// The new manager for the user.
        /// </summary>
        [Parameter]
        public UserBinding Manager { get; set; }

        /// <summary>
        /// The updated position of the user.
        /// </summary>
        [Parameter]
        public string JobTitle { get; set; }

        /// <summary>
        /// The updated phone number to contact the user.
        /// </summary>
        [Parameter]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The user's updated street address.
        /// </summary>
        [Parameter]
        public string Address { get; set; }

        /// <summary>
        /// The user's updated address city.
        /// </summary>
        [Parameter]
        public string City { get; set; }

        /// <summary>
        /// The user's updated address country.
        /// </summary>
        [Parameter]
        public string Country { get; set; }

        /// <summary>
        /// The user's updated address state.
        /// </summary>
        [Parameter]
        public string State { get; set; }

        /// <summary>
        /// The user's updated address zip code.
        /// </summary>
        [Parameter]
        public string ZipCode { get; set; }

        /// <summary>
        /// The updated email address for the user.
        /// </summary>
        [Parameter]
        public string NewEmailAddress { get; set; }

        /// <summary>
        /// The updated department the user works for.
        /// </summary>
        [Parameter]
        public ObjectBinding<Department> Department { get; set; }

        /// <summary>
        /// The updated location the user works at.
        /// </summary>
        [Parameter]
        public ObjectBinding<Location> Location { get; set; }

        /// <summary>
        /// The updated company the user works for.
        /// </summary>
        [Parameter]
        public ObjectBinding<Company> Company { get; set; }

        /// <summary>
        /// The updated list of groups the user is a member of.
        /// </summary>
        [Parameter]
        public ObjectBinding<Group>[] Groups { get; set; }

        /// <inheritdoc />
        protected override bool PopulateItem(User item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(AvatarUrl)))
                item.AvatarUrl = this.AvatarUrl;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(FirstName)))
                item.FirstName = this.FirstName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(LastName)))
                item.LastName = this.LastName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewUserName)))
                item.UserName = this.NewUserName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Password)))
            {
                item.Password = this.Password;
                item.PasswordConfirmation = this.Password;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(EmployeeNumber)))
                item.EmployeeNumber = this.EmployeeNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manager)))
            {
                if (!GetSingleValue(Manager, out var manager))
                    return false;
                item.Manager = manager;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(JobTitle)))
                item.JobTitle = this.JobTitle;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PhoneNumber)))
                item.PhoneNumber = this.PhoneNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Address)))
                item.Address = this.Address;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(City)))
                item.City = this.City;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Country)))
                item.Country = this.Country;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(State)))
                item.State = this.State;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ZipCode)))
                item.ZipCode = this.ZipCode;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(EmailAddress)))
                item.EmailAddress = this.EmailAddress;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Department)))
            {
                if (!GetSingleValue(Department, out var department))
                    return false;
                item.Department = department;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
            {
                if (!GetSingleValue(Location, out var location))
                    return false;
                item.Location = location;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
            {
                if (!GetSingleValue(Company, out var company))
                    return false;
                item.Company = company;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Groups)))
            {
                if (!GetManyValues(Groups, out var groups))
                    return false;
                item.Groups = groups;
            }
            return false;
        }

        /// <inheritdoc />
        protected override UserBinding GetBoundObject()
        {
            if(ParameterSetName == nameof(UserParameterSets.ByUserName))
                return UserBinding.FromUserName(UserName);
            else
                return UserBinding.FromEmailAddress(EmailAddress);
        }
    }
}
