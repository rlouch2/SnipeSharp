using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Models.Enumerations;

namespace SnipeSharp.PowerShell.Cmdlets.New
{
    [Cmdlet(VerbsCommon.New, nameof(StatusLabel))]
    [OutputType(typeof(StatusLabel))]
    public class NewStatusLabel: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        public StatusType Type { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Notes { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new StatusLabel {
                Name = this.Name,
                Type = this.Type,
                Notes = this.Notes
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.StatusLabels.Create(item));
        }
    }
}
