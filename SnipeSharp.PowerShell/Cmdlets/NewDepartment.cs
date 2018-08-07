using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "Department")]
    [OutputType(typeof(Depreciation))]
    public class NewDepartment: PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public CompanyIdentity Company { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public UserIdentity Manager { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public LocationIdentity Location { get; set; }

        protected override void ProcessRecord()
        {
            var item = new Department {
                Name = this.Name,
                Company = this.Company?.Company,
                Manager = this.Manager?.User,
                Location = this.Location?.Location
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.DepartmentManager.Create(item).Payload);
        }
    }
}