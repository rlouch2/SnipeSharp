using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "StatusLabel")]
    [OutputType(typeof(StatusLabel))]
    public class NewStatusLabel: PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true
        )]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateSet("deployable", "pending", "archived")]
        public string Type { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Color { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public bool ShowInNav { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Notes { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public bool Deployable { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public bool Pending { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public bool Archived { get; set; }

        protected override void ProcessRecord()
        {
            var item = new StatusLabel {
                Name = this.Name,
                Type = this.Type,
                Color = this.Color,
                ShowInNav = this.ShowInNav,
                Notes = this.Notes,
                Deployable = this.Deployable,
                Pending = this.Pending,
                Archived = this.Archived
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.ModelManager.Create(item).Payload);
        }
    }
}