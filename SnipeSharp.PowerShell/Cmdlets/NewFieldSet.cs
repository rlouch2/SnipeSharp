using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, nameof(FieldSet))]
    [OutputType(typeof(FieldSet))]
    public class NewFieldSet: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        
        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new FieldSet {
                Name = this.Name
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.FieldSets.Create(item));
        }
    }
}
