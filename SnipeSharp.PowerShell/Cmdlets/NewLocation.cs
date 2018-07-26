using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.Attributes;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "Location")]
    public class NewLocation: PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Address { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string City { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string State { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Country { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Zip { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public LocationIdentity Parent { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public UserIdentity Manager { get; set; }
        
        protected override void ProcessRecord()
        {
            var item = new Location {
                Name = this.Name,
                Address = this.Address,
                City = this.City,
                State = this.State,
                Country = this.Country,
                Zip = this.Zip,
                Parent = this.Parent?.Location,
                Manager = this.Manager?.User
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.LicenseManager.Create(item).Payload);
        }
    }
}