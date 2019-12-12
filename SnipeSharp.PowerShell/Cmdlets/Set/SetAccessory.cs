using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Changes the properties of an existing Snipe-IT accessory.</summary>
    /// <remarks>The Set-Accessory cmdlet changes the properties of an existing Snipe-IT accessory object.</remarks>
    /// <example>
    ///   <code>Set-Accessory -Name "Potato Peeler Wrist strap" -NewName "Potato Peeler Wriststrap" -MinimumQuantity 12</code>
    ///   <para>Changes the name of the accessory "Potato Peeler Wrist strap" to "Potato Peeler Wriststrap" and sets the new minimum quantity before warning to 12.</para>
    /// </example>
    [Cmdlet(VerbsCommon.Set, nameof(Accessory))]
    [OutputType(typeof(Accessory))]
    public class SetAccessory: SetObject<Accessory, ObjectBinding<Accessory>>
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
        protected override bool PopulateItem(Accessory item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
            {
                if(!this.GetSingleValue(Company, out var company))
                    return false;
                item.Company = company;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
            {
                if(!this.GetSingleValue(Manufacturer, out var manufacturer))
                    return false;
                item.Manufacturer = manufacturer;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Supplier)))
            {
                if(!this.GetSingleValue(Supplier, out var supplier))
                    return false;
                item.Supplier = supplier;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ModelNumber)))
                item.ModelNumber = this.ModelNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
            {
                if(!this.GetSingleValue(Category, out var category))
                    return false;
                item.Category = category;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
            {
                if(!this.GetSingleValue(Location, out var location))
                    return false;
                item.Location = location;
            }
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
            return true;
        }
    }
}
