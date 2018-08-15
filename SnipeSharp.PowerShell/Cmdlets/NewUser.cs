using System;
using System.Management.Automation;
using System.Collections.Generic;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, nameof(User))]
    [OutputType(typeof(User))]
    public class NewUser: PSCmdlet
    {
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Uri AvatarUrl { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string FirstName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string LastName { get; set; }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string UserName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Password { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string EmployeeNumber { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<User> Manager { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string JobTitle { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string PhoneNumber { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Address { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string City { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Country { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string State { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string ZipCode { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string EmailAddress { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Department> Department { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Location> Location { get; set; }

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
                Manager = this.Manager?.Object,
                JobTitle = this.JobTitle,
                PhoneNumber = this.PhoneNumber,
                Address = this.Address,
                City = this.City,
                Country = this.Country,
                State = this.State,
                ZipCode = this.ZipCode,
                EmailAddress = this.EmailAddress,
                Department = this.Department?.Object,
                Location = this.Location?.Object,
                Company = this.Company?.Object
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Users.Create(item));
        }
    }
}
