using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, nameof(Depreciation))]
    [OutputType(typeof(Depreciation))]
    public class NewDepreciation: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        public int Months { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new Depreciation {
                Name = this.Name,
                Months = this.Months
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Depreciations.Create(item));
        }
    }
}
