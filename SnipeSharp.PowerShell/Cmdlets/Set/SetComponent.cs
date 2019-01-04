using System;
using System.Management.Automation;
using SnipeSharp.EndPoint;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets.Set
{
    /// <summary>
    /// <para type="synopsis">Changes the properties of an existing Snipe-IT component.</para>
    /// <para type="description">The Set-Component cmdlet changes the properties of an existing Snipe-IT component object.</para>
    /// </summary>
    /// <example>
    ///   <code>Set-Component -Name "Potato Peeler Blade" -Category "Hazardous"</code>
    ///   <para>Changes the category of component "Potato Peeler Blade" to "Hazardous".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Set, nameof(Component))]
    [OutputType(typeof(Component))]
    public class SetComponent: SetObject<Component>
    {
        /// <summary>
        /// The new name of the component.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string NewName { get; set; }

        /// <summary>
        /// The updated serial number(s) for the component(s).
        /// </summary>
        [Parameter]
        public string Serial { get; set; }

        /// <summary>
        /// The updated location for the component.
        /// </summary>
        [Parameter]
        public ObjectBinding<Location> Location { get; set; }

        /// <summary>
        /// The updated quantity of the component.
        /// </summary>
        [Parameter]
        [ValidateRange(1, int.MaxValue)]
        public int Quantity { get; set; }

        /// <summary>
        /// The updated minimum quantity before warning for the component.
        /// </summary>
        [Parameter]
        public int MinimumQuantity { get; set; }

        /// <summary>
        /// The updated category of the component.
        /// </summary>
        [Parameter]
        public ObjectBinding<Category> Category { get; set; }

        /// <summary>
        /// The updated order the component was purchased in.
        /// </summary>
        [Parameter]
        public string OrderNumber { get; set; }

        /// <summary>
        /// The updated date the component was purchased.
        /// </summary>
        [Parameter]
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// The updated cost the component was purchased for.
        /// </summary>
        [Parameter]
        public decimal PurchaseCost { get; set; }

        /// <summary>
        /// The updated company that owns the component.
        /// </summary>
        [Parameter]
        public ObjectBinding<Company> Company { get; set; }

        /// <inheritdoc />
        protected override void PopulateItem(Component item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Serial)))
                item.Serial = this.Serial;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
                item.Location = this.Location?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Quantity)))
                item.Quantity = this.Quantity;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(MinimumQuantity)))
                item.MinimumQuantity = this.MinimumQuantity;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                item.Category = this.Category?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(OrderNumber)))
                item.OrderNumber = this.OrderNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseCost)))
                item.PurchaseCost = this.PurchaseCost;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseDate)))
                item.PurchaseDate = this.PurchaseDate;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
                item.Company = this.Company?.Object;
        }
    }
}
