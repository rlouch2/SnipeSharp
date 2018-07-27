using System;
using System.Management.Automation;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "Consumable")]
    [OutputType(typeof(Consumable))]
    public class SetConsumable: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateIdentityNotNull]
        public ConsumableIdentity Consumable { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public CategoryIdentity Category { get; set; }
        
        [Parameter]
        public CompanyIdentity Company { get; set; }

        [Parameter]
        public string ItemNumber { get; set; }

        [Parameter]
        public LocationIdentity Location { get; set; }

        [Parameter]
        public ManufacturerIdentity Manufacturer { get; set; }

        [Parameter]
        public long MinimumAmount { get; set; }

        [Parameter]
        public string ModelNumber { get; set; }

        [Parameter]
        public string OrderNumber { get; set; }

        [Parameter]
        public string PurchaseCost { get; set; }

        [Parameter]
        public string PurchaseDate { get; set; }

        [Parameter]
        public long Quantity { get; set; }

        [Parameter]
        public long Remaining { get; set; }

        protected override void ProcessRecord()
        {
            var item = this.Consumable.Consumable;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                item.Name = this.Name;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                item.Category = this.Category?.Category;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
                item.Company = this.Company?.Company;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ItemNumber)))
                item.ItemNo = this.ItemNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
                item.Location = this.Location?.Location;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
                item.Manufacturer = this.Manufacturer?.Manufacturer;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(MinimumAmount)))
                item.MinAmt = this.MinimumAmount;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ModelNumber)))
                item.ModelNumber = this.ModelNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(OrderNumber)))
                item.OrderNumber = this.OrderNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseCost)))
                item.PurchaseCost = this.PurchaseCost;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Quantity)))
                item.Quantity = this.Quantity;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Remaining)))
                item.Remaining = this.Remaining;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseDate)))
                item.PurchaseDate = new ResponseDate {
                    DateTime = this.PurchaseDate
                };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.ConsumableManager.Update(item).Payload);
        }
    }
}