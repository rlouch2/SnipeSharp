using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "FieldSet")]
    [OutputType(typeof(FieldSet))]
    public class NewFieldSet: PSCmdlet
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
            var item = new FieldSet {
                Name = this.Name
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.FieldSetManager.Create(item).Payload);
        }
    }
}