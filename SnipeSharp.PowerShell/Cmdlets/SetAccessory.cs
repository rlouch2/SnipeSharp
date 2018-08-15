using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, nameof(Accessory))]
    [OutputType(typeof(Accessory))]
    public class SetAccessory: SetObject<Accessory>
    {
        [Parameter]
        public string NewName { get; set; }

        [Parameter]
        public ObjectBinding<Company> Company { get; set; }

        [Parameter]
        public ObjectBinding<Manufacturer> Manufacturer { get; set; }

        [Parameter]
        public ObjectBinding<Supplier> Supplier { get; set; }

        [Parameter]
        public string ModelNumber { get; set; }

        [Parameter]
        public ObjectBinding<Category> Category { get; set; }

        [Parameter]
        public ObjectBinding<Location> Location { get; set; }

        [Parameter]
        public int Quantity { get; set; }

        [Parameter]
        public DateTime PurchaseDate { get; set; }

        [Parameter]
        public decimal PurchaseCost { get; set; }

        [Parameter]
        public string OrderNumber { get; set; }

        [Parameter]
        public int MinimumQuantity { get; set; }

        [Parameter]
        public Uri ImageUri { get; set; }

        /// <inheritdoc />
        protected override void PopulateItem(Accessory item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
                item.Company = this.Company?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
                item.Manufacturer = this.Manufacturer?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Supplier)))
                item.Supplier = this.Supplier?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ModelNumber)))
                item.ModelNumber = this.ModelNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                item.Category = this.Category?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
                item.Location = this.Location?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Quantity)))
                item.Quantity = this.Quantity;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseDate)))
                item.PurchaseDate = this.PurchaseDate;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseCost)))
                item.PurchaseCost = this.PurchaseCost;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(OrderNumber)))
                item.OrderNumber = this.OrderNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(MinimumQuantity)))
                item.MinimumQuantity = this.MinimumQuantity;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ImageUri)))
                item.ImageUri = this.ImageUri;
        }
    }
}