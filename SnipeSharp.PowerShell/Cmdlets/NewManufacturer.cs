using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "Manufacturer")]
    public class NewManufacturer: PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Url { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string SupportUrl { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string SupportPhone { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string SupportEmail { get; set; }
        
        protected override void ProcessRecord()
        {
            var item = new Manufacturer {
                Name = this.Name,
                Url = this.Url,
                SupportUrl = this.SupportUrl,
                SupportPhone = this.SupportPhone,
                SupportEmail = this.SupportEmail
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.LicenseManager.Create(item).Payload);
        }
    }
}