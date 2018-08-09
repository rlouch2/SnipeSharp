using System;
using System.Management.Automation;
using System.Collections.Generic;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "User")]
    [OutputType(typeof(User))]
    public class NewUser: PSCmdlet
    {
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public bool Activated { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Address { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string City { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public CompanyIdentity Company { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Country { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Email { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string EmployeeNumber { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string FirstName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string JobTitle { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string LastLogin { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string LastName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public LocationIdentity Location { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public UserIdentity Manager { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Notes { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Dictionary<string, string> Permissions { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Phone { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string State { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string UserName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Zip { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Password { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public DepartmentIdentity Department { get; set; }

        protected override void ProcessRecord()
        {
            var item = new User {
                Name = this.Name,
                Activated = this.Activated,
                Address = this.Address,
                City = this.City,
                Company = this.Company?.Company,
                Country = this.Country,
                Email = this.Email,
                EmployeeNum = this.EmployeeNumber,
                Firstname = this.FirstName,
                Jobtitle = this.JobTitle,
                Lastname = this.LastName,
                Location = this.Location?.Location,
                Manager = this.Manager?.User,
                Notes = this.Notes,
                Permissions = this.Permissions,
                Phone = this.Phone,
                State = this.State,
                Username = this.UserName,
                Zip = this.Zip,
                Password = this.Password,
                Department = this.Department?.Department
            };

            if(LastLogin != null)
                item.LastLogin = new ResponseDate {
                    DateTime = this.LastLogin
                };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.UserManager.Create(item).Payload);
        }
    }
}