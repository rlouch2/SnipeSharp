using System;
using System.Management.Automation;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "Accessory")]
    [OutputType(typeof(Accessory))]
    public class SetAccessory: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateIdentityNotNull]
        public AccessoryIdentity Accessory { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public CategoryIdentity Category { get; set; }

        [Parameter]
        public CompanyIdentity Company { get; set; }

        [Parameter]
        public LocationIdentity Location { get; set; }

        [Parameter]
        public ManufacturerIdentity Manufacturer { get; set; }

        [Parameter]
        public long MinimumQuantity { get; set; }

        [Parameter]
        public string ModelNumber { get; set; }

        [Parameter]
        public string Notes { get; set; }

        [Parameter]
        public string OrderNumber { get; set; }

        [Parameter]
        public string PurchaseCost { get; set; }

        [Parameter]
        public string PurchaseDate { get; set; }

        [Parameter]
        public long Quantity { get; set; };

        [Parameter]
        public SupplierIdentity Supplier { get; set; }

        protected override void ProcessRecord()
        {
            var item = this.Accessory.Accessory;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                item.Name = this.Name;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                item.Category = this.Category;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
                item.Company = this.Company;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
                item.Location = this.Location;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
                item.Manufacturer = this.Manufacturer;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(MinimumQuantity)))
                item.MinQty = this.MinimumQuantity;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ModelNumber)))
                item.ModelNumber = this.ModelNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Notes)))
                item.Notes = this.Notes;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(OrderNumber)))
                item.OrderNumber = this.OrderNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseCost)))
                item.PurchaseCost = this.PurchaseCost;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Quantity)))
                item.Quantity = this.Quantity;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Supplier)))
                item.Supplier = this.Supplier;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseDate)))
                item.PurchaseDate = new ResponseDate {
                    DateTime = this.PurchaseDate
                };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.AccessoryManager.Update(item).Payload);
        }
    }
}