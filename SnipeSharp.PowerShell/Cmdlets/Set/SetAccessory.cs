using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets.Set
{
    [Cmdlet(VerbsCommon.Set, nameof(Accessory))]
    [OutputType(typeof(Accessory))]
    public class SetAccessory: SetObject<Accessory>
    {
        /// <summary>
        /// The new name of the accessory.
        /// </summary>
        [Parameter]
        public string NewName { get; set; }

        /// <summary>
        /// The new company that owns the accessory.
        /// </summary>
        [Parameter]
        public ObjectBinding<Company> Company { get; set; }

        /// <summary>
        /// The updated manufacturer who made the accessory.
        /// </summary>
        [Parameter]
        public ObjectBinding<Manufacturer> Manufacturer { get; set; }

        /// <summary>
        /// The updated supplier who sold the accessory.
        /// </summary>
        [Parameter]
        public ObjectBinding<Supplier> Supplier { get; set; }

        /// <summary>
        /// The updated model number of the accessory.
        /// </summary>
        [Parameter]
        public string ModelNumber { get; set; }

        /// <summary>
        /// The updated category of the accessory.
        /// </summary>
        [Parameter]
        public ObjectBinding<Category> Category { get; set; }

        /// <summary>
        /// The updated location of the accessory.
        /// </summary>
        [Parameter]
        public ObjectBinding<Location> Location { get; set; }

        /// <summary>
        /// The updated quantity of the accessory.
        /// </summary>
        [Parameter]
        public int Quantity { get; set; }

        /// <summary>
        /// The updated date of purchase for the accessory.
        /// </summary>
        [Parameter]
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// The updated purchase cost for the accessory.
        /// </summary>
        [Parameter]
        public decimal PurchaseCost { get; set; }

        /// <summary>
        /// The updated order number for the accessory.
        /// </summary>
        [Parameter]
        public string OrderNumber { get; set; }

        /// <summary>
        /// The updated minimum quantity before warning for the accessory.
        /// </summary>
        [Parameter]
        public int MinimumQuantity { get; set; }

        /// <summary>
        /// The updated uri of the image for the accessory.
        /// </summary>
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