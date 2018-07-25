using System;
using System.Management.Automation;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "Consumable")]
    public class NewConsumable: PSCmdlet
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
        [ValidateNotNullOrEmpty]
        public string ItemNumber { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public LocationIdentity Location { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ManufacturerIdentity Manufacturer { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public long? MinimumAmount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ModelNumber { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string OrderNumber { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PurchaseCost { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PurchaseDate { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public long? Quantity { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public long? Remaining { get; set; }

        protected override void ProcessRecord()
        {
            var item = new Consumable {
                Name = this.Name,
                Category = this.Category?.Category,
                Company = this.Company?.Company,
                ItemNo = this.ItemNumber,
                Location = this.Location?.Location,
                Manufacturer = this.Manufacturer?.Manufacturer,
                MinAmt = this.MinimumAmount,
                ModelNumber = this.ModelNumber,
                OrderNumber = this.OrderNumber,
                PurchaseCost = this.PurchaseCost,
                Quantity = this.Quantity,
                Remaining = this.Remaining
            };
            if(PurchaseDate != null)
            {
                item.PurchaseDate = new ResponseDate {
                    DateTime = this.PurchaseDate
                };
            }
            //TODO: error handling
            WriteObject(ApiHelper.Instance.ConsumableManager.Create(item).Payload);
        }
        // TODO
    }
}