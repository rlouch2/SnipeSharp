using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "Company")]
    [OutputType(typeof(Company))]
    public class NewCompany: PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        
        protected override void ProcessRecord()
        {
            var item = new Company {
                Name = this.Name
            };
            // TODO: error handling
            WriteObject(ApiHelper.Instance.CompanyManager.Create(item).Payload);
        }
    }
}