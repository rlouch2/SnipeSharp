using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets.New
{
    [Cmdlet(VerbsCommon.New, nameof(Location))]
    [OutputType(typeof(Location))]
    public class NewLocation: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Address { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Address2 { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string City { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string State { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Country { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string ZipCode { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Currency { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Location> ParentLocation { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new Location {
                Name = this.Name,
                Address = this.Address,
                Address2 = this.Address2,
                City = this.City,
                State = this.State,
                Country = this.Country,
                ZipCode = this.ZipCode,
                Currency = this.Currency,
                ParentLocation = this.ParentLocation?.Object
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Locations.Create(item));
        }
    }
}
