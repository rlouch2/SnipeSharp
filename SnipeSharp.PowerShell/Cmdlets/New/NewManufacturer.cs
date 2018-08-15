using System;
using System.Management.Automation;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.Cmdlets.New
{
    [Cmdlet(VerbsCommon.New, nameof(Manufacturer))]
    [OutputType(typeof(Manufacturer))]
    public class NewManufacturer: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Uri Url { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Uri ImageUri { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Uri SupportUrl { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string SupportPhoneNumber { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string SupportEmailAddress { get; set; }
        
        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new Manufacturer {
                Name = this.Name,
                Url = this.Url,
                SupportUrl = this.SupportUrl,
                SupportPhoneNumber = this.SupportPhoneNumber,
                SupportEmailAddress = this.SupportEmailAddress
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Manufacturers.Create(item));
        }
    }
}
