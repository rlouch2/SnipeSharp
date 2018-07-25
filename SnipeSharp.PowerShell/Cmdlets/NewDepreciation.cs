using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "Depreciation")]
    public class NewDepreciation: PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNullOrEmpty]
        public string Months { get; set; }

        protected override void ProcessRecord()
        {
            var item = new Depreciation {
                Name = this.Name,
                Months = this.Months
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.DepreciationManager.Create(item).Payload);
        }
        // TODO
    }
}