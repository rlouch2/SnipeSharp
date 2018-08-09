using System;
using System.Management.Automation;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "Component")]
    [OutputType(typeof(Component))]
    public class SetComponent: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public ComponentIdentity Component { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public CategoryIdentity Category { get; set; }

        [Parameter]
        public CompanyIdentity Company { get; set; }

        [Parameter]
        public LocationIdentity Location { get; set; }

        [Parameter]
        public long MinimumAmount { get; set; }

        [Parameter]
        public string OrderNumber { get; set; }

        [Parameter]
        public string PurchaseCost { get; set; }

        [Parameter]
        public string PurchaseDate { get; set; }

        [Parameter]
        public long Quantity { get; set; }

        [Parameter]
        public string Serial { get; set; }

        protected override void ProcessRecord()
        {
            var item = this.Component.Component;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                item.Name = this.Name;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                item.Category = this.Category?.Category;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
                item.Company = this.Company?.Company;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
                item.Location = this.Location?.Location;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(MinimumAmount)))
                item.MinAmt = this.MinimumAmount;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(OrderNumber)))
                item.OrderNumber = this.OrderNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseCost)))
                item.PurchaseCost = this.PurchaseCost;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Quantity)))
                item.Quantity = this.Quantity;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Serial)))
                item.SerialNumber = this.Serial;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseDate)))
                item.PurchaseDate = new ResponseDate {
                    DateTime = this.PurchaseDate
                };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.ComponentManager.Update(item).Payload);
        }
    }
}