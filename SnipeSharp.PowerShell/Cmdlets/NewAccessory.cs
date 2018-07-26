using System;
using System.Management.Automation;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "Accessory")]
    [OutputType(typeof(Accessory))]
    public class NewAccessory: PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public CategoryIdentity Category { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public CompanyIdentity Company { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public LocationIdentity Location { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ManufacturerIdentity Manufacturer { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public long? MinimumQuantity { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ModelNumber { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string Notes { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string OrderNumber { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PurchaseCost { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PurchaseDate { get; set; } // convert this to ResponseDate internally

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public long Quantity { get; set; } = 1; // "req"

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public SupplierIdentity Supplier { get; set; }

        protected override void ProcessRecord()
        {
            var item = new Accessory {
                Name = this.Name,
                Category = this.Category?.Category,
                Company = this.Company?.Company,
                Location = this.Location?.Location,
                Manufacturer = this.Manufacturer?.Manufacturer,
                MinQty = this.MinimumQuantity,
                ModelNumber = this.ModelNumber,
                Notes = this.Notes,
                OrderNumber = this.OrderNumber,
                PurchaseCost = this.PurchaseCost,
                Quantity = this.Quantity,
                Supplier = this.Supplier?.Supplier
            };
            if(PurchaseDate != null)
            {
                item.PurchaseDate = new ResponseDate {
                    DateTime = this.PurchaseDate
                };
            }
            //TODO: error handling
            WriteObject(ApiHelper.Instance.AccessoryManager.Create(item).Payload);
        }
    }
}