using System;
using System.Management.Automation;
using System.Collections.Generic;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "User")]
    [OutputType(typeof(User))]
    public class SetUser: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateIdentityNotNull]
        public UserIdentity User { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public bool Activated { get; set; }

        [Parameter]
        public string Address { get; set; }

        [Parameter]
        public string City { get; set; }

        [Parameter]
        public CompanyIdentity Company { get; set; }

        [Parameter]
        public string Country { get; set; }

        [Parameter]
        public string Email { get; set; }

        [Parameter]
        public string EmployeeNumber { get; set; }

        [Parameter]
        public string FirstName { get; set; }

        [Parameter]
        public string JobTitle { get; set; }

        [Parameter]
        public string LastLogin { get; set; }

        [Parameter]
        public string LastName { get; set; }

        [Parameter]
        public LocationIdentity Location { get; set; }

        [Parameter]
        public UserIdentity Manager { get; set; }

        [Parameter]
        public string Notes { get; set; }

        [Parameter]
        public Dictionary<string, string> Permissions { get; set; }

        [Parameter]
        public string Phone { get; set; }

        [Parameter]
        public string State { get; set; }

        [Parameter]
        public string UserName { get; set; }

        [Parameter]
        public string Zip { get; set; }

        [Parameter]
        public string Password { get; set; }

        [Parameter]
        public DepartmentIdentity Department { get; set; }

        protected override void ProcessRecord()
        {
            var item = this.User.User;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                item.Name = this.Name;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Activated)))
                item.Activated = this.Activated;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Address)))
                item.Address = this.Address;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(City)))
                item.City = this.City;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
                item.Company = this.Company?.Company;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Country)))
                item.Country = this.Country;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Email)))
                item.Email = this.Email;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(EmployeeNumber)))
                item.EmployeeNum = this.EmployeeNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(FirstName)))
                item.Firstname = this.FirstName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(JobTitle)))
                item.Jobtitle = this.JobTitle;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(LastName)))
                item.Lastname = this.LastName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
                item.Location = this.Location?.Location;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manager)))
                item.Manager = this.Manager?.User;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Notes)))
                item.Notes = this.Notes;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Permissions)))
                item.Permissions = this.Permissions;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Phone)))
                item.Phone = this.Phone;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(State)))
                item.State = this.State;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(UserName)))
                item.Username = this.UserName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Zip)))
                item.Zip = this.Zip;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Password)))
                item.Password = this.Password;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Department)))
                item.Department = this.Department?.Department;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(LastLogin)))
                item.LastLogin = new ResponseDate {
                    DateTime = this.LastLogin
                };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.UserManager.Update(item).Payload);
        }
    }
}