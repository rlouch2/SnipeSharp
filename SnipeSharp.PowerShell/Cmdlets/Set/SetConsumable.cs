using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets.Set
{
    [Cmdlet(VerbsCommon.Set, nameof(Consumable))]
    [OutputType(typeof(Consumable))]
    public class SetConsumable: SetObject<Consumable>
    {
        /// <summary>
        /// The new name for the consumable.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string NewName { get; set; }

        /// <summary>
        /// The updated category of the consumable.
        /// </summary>
        [Parameter]
        [ValidateIdentityNotNull]
        public ObjectBinding<Category> Category { get; set; }
        
        /// <summary>
        /// The updated company that owns the consumable.
        /// </summary>
        [Parameter]
        public ObjectBinding<Company> Company { get; set; }

        /// <summary>
        /// The updated item number of the consumable.
        /// </summary>
        [Parameter]
        public string ItemNumber { get; set; }

        /// <summary>
        /// The updated location of the consumable.
        /// </summary>
        [Parameter]
        public ObjectBinding<Location> Location { get; set; }

        /// <summary>
        /// The update maker of the consumable.
        /// </summary>
        [Parameter]
        public ObjectBinding<Manufacturer> Manufacturer { get; set; }

        /// <summary>
        /// The updated quantity of the consumable.
        /// </summary>
        [Parameter]
        [ValidateRange(1, int.MaxValue)]
        public int Quantity { get; set; }

        /// <summary>
        /// The updated minimum quantity before warning for the consumable.
        /// </summary>
        [Parameter]
        public int MinimumQuantity { get; set; }

        /// <summary>
        /// The updated model number for the consumable.
        /// </summary>
        [Parameter]
        public string ModelNumber { get; set; }

        /// <summary>
        /// The updated order number for the consumable's purchase.
        /// </summary>
        [Parameter]
        public string OrderNumber { get; set; }

        /// <summary>
        /// The update cost the consumable was purchased for.
        /// </summary>
        [Parameter]
        public decimal PurchaseCost { get; set; }

        /// <summary>
        /// The updated date the consumable was purchased.
        /// </summary>
        [Parameter]
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Is the consumable requestable by users?
        /// </summary>
        [Parameter]
        public bool IsRequestable { get; set; }

        /// <inheritdoc />
        protected override void PopulateItem(Consumable item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                item.Category = this.Category?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
                item.Company = this.Company?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ItemNumber)))
                item.ItemNumber = this.ItemNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
                item.Location = this.Location?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
                item.Manufacturer = this.Manufacturer?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Quantity)))
                item.Quantity = this.Quantity;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(MinimumQuantity)))
                item.MinimumQuantity = this.MinimumQuantity;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ModelNumber)))
                item.ModelNumber = this.ModelNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(OrderNumber)))
                item.OrderNumber = this.OrderNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseCost)))
                item.PurchaseCost = this.PurchaseCost;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseDate)))
                item.PurchaseDate = this.PurchaseDate;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(IsRequestable)))
                item.IsRequestable = this.IsRequestable;
        }
    }
}
