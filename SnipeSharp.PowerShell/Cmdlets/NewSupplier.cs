using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, nameof(Supplier))]
    [OutputType(typeof(Supplier))]
    public class NewSupplier: PSCmdlet
    {
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Uri ImageUri { get; set; }

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
        public string FaxNumber { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string PhoneNumber { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string EmailAddress { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Contact { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Notes { get; set; }
        
        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new Supplier {
                Name = this.Name,
                ImageUri = this.ImageUri,
                Address = this.Address,
                Address2 = this.Address2,
                City = this.City,
                State = this.State,
                Country = this.Country,
                ZipCode = this.ZipCode,
                FaxNumber = this.FaxNumber,
                PhoneNumber = this.PhoneNumber,
                EmailAddress = this.EmailAddress,
                Contact = this.Contact,
                Notes = this.Notes
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Suppliers.Create(item));
        }
    }
}
