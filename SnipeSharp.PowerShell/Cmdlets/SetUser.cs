using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, nameof(User))]
    [OutputType(typeof(User))]
    public class SetUser: SetObject<User>
    {
        [Parameter]
        public Uri AvatarUrl { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string FirstName { get; set; }

        [Parameter]
        public string LastName { get; set; }

        [Parameter]
        public string UserName { get; set; }

        [Parameter]
        public string Password { get; set; }

        [Parameter]
        public string EmployeeNumber { get; set; }

        [Parameter]
        public ObjectBinding<User> Manager { get; set; }

        [Parameter]
        public string JobTitle { get; set; }

        [Parameter]
        public string PhoneNumber { get; set; }

        [Parameter]
        public string Address { get; set; }

        [Parameter]
        public string City { get; set; }

        [Parameter]
        public string Country { get; set; }

        [Parameter]
        public string State { get; set; }

        [Parameter]
        public string ZipCode { get; set; }

        [Parameter]
        public string EmailAddress { get; set; }

        [Parameter]
        public ObjectBinding<Department> Department { get; set; }

        [Parameter]
        public ObjectBinding<Location> Location { get; set; }

        [Parameter]
        public ObjectBinding<Company> Company { get; set; }

        protected override void PopulateItem(User item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(AvatarUrl)))
                item.AvatarUrl = this.AvatarUrl;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(FirstName)))
                item.FirstName = this.FirstName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(LastName)))
                item.LastName = this.LastName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(UserName)))
                item.UserName = this.UserName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Password)))
                item.Password = this.Password;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(EmployeeNumber)))
                item.EmployeeNumber = this.EmployeeNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manager)))
                item.Manager = this.Manager?.Object;
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
                item.Department = this.Department?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
                item.Location = this.Location?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
                item.Company = this.Company?.Object;
        }
    }
}
