using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "Category")]
    [OutputType(typeof(Category))]
    public class NewCategory: PSCmdlet
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
        [ValidateSet("asset", "accessory", "consumable", "component")]
        public string Type { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Eula { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter CheckInEmail { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter RequireAcceptance { get; set; }

        protected override void ProcessRecord()
        {
            var item = new Category {
                Name = this.Name,
                Type = this.Type,
                eula = this.Eula.IsPresent,
                CheckinEmail = this.CheckInEmail.IsPresent,
                RequireAcceptance = this.RequireAcceptance.IsPresent
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.CategoryManager.Create(item).Payload);
        }
    }
}