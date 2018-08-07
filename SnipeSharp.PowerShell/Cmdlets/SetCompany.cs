using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "Company")]
    [OutputType(typeof(Company))]
    public class SetCompany: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public CompanyIdentity Company { get; set; }

        [Parameter]
        public string Name { get; set; }
        
        protected override void ProcessRecord()
        {
            var item = this.Company.Company;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                item.Name = this.Name;
            // TODO: error handling
            WriteObject(ApiHelper.Instance.CompanyManager.Update(item).Payload);
        }
    }
}