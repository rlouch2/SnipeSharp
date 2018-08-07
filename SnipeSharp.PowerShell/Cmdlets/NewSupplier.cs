using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "Supplier")]
    [OutputType(typeof(Supplier))]
    public class NewSupplier: PSCmdlet
    {
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true)]
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
        public string Fax { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Phone { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Email { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Contact { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Notes { get; set; }
        
        protected override void ProcessRecord()
        {
            var item = new Supplier {
                Name = this.Name,
                Address = this.Address,
                City = this.City,
                State = this.State,
                Country = this.Country,
                Zip = this.Zip,
                Fax = this.Fax,
                Phone = this.Phone,
                Email = this.Email,
                Contact = this.Contact,
                Notes = this.Notes
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.SupplierManager.Create(item).Payload);
        }
    }
}