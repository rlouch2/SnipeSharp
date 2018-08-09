using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "Department")]
    [OutputType(typeof(Depreciation))]
    public class SetDepartment: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateIdentityNotNull]
        public DepartmentIdentity Department { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public CompanyIdentity Company { get; set; }

        [Parameter]
        public UserIdentity Manager { get; set; }

        [Parameter]
        public LocationIdentity Location { get; set; }

        protected override void ProcessRecord()
        {
            var item = this.Department.Department;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                item.Name = this.Name;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
                item.Company = this.Company?.Company;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manager)))
                item.Manager = this.Manager?.User;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
                item.Location = this.Location?.Location;
            //TODO: error handling
            WriteObject(ApiHelper.Instance.DepartmentManager.Update(item).Payload);
        }
    }
}