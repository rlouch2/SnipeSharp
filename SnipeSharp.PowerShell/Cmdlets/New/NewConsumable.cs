using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Creates a new Snipe-IT consumable.</summary>
    /// <remarks>The New-Consumable cmdlet creates a new consumable object.</remarks>
    /// <example>
    ///   <code>New-Consumable -Name "Frying Oil" -Quantity 9001 -Category "Perishable"</code>
    ///   <para>Create a new consumable named "Frying oil" with all required properties set.</para>
    /// </example>
    [Cmdlet(VerbsCommon.New, nameof(Consumable))]
    [OutputType(typeof(Consumable))]
    public class NewConsumable: PSCmdlet
    {
        /// <summary>
        /// The name of the consumable.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The category the consumable belongs to.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ObjectBinding<Category> Category { get; set; }

        /// <summary>
        /// How many of the consumable there are.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateRange(1, int.MaxValue)]
        public int Quantity { get; set; }

        /// <summary>
        /// The company that owns the consumable.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Company> Company { get; set; }

        /// <summary>
        /// The item number of the consumable.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string ItemNumber { get; set; }

        /// <summary>
        /// The consumable's location.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Location> Location { get; set; }

        /// <summary>
        /// The maker of the consumable.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Manufacturer> Manufacturer { get; set; }

        /// <summary>
        /// When to start warning that the consumable is running low.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public int MinimumQuantity { get; set; }

        /// <summary>
        /// The model number of the consumable.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string ModelNumber { get; set; }

        /// <summary>
        /// The order the consumable was purchased in.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// The cost the consumable was purchased for.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public decimal PurchaseCost { get; set; }

        /// <summary>
        /// The date the consumable was purchased.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Is the consumable requestable by users?
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public bool IsRequestable { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new Consumable {
                Name = this.Name,
                Quantity = this.Quantity,
                ItemNumber = this.ItemNumber,
                ModelNumber = this.ModelNumber,
                OrderNumber = this.OrderNumber
            };
            if(MyInvocation.BoundParameters.ContainsKey(nameof(MinimumQuantity)))
                item.MinimumQuantity = this.MinimumQuantity;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseCost)))
                item.PurchaseCost = this.PurchaseCost;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseDate)))
                item.PurchaseDate = this.PurchaseDate;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(IsRequestable)))
                item.IsRequestable = this.IsRequestable;
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
            {
                if (!this.GetSingleValue(Category, out var category))
                    return;
                item.Category = category;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
            {
                if (!this.GetSingleValue(Company, out var company))
                    return;
                item.Company = company;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
            {
                if (!this.GetSingleValue(Location, out var location))
                    return;
                item.Location = location;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
            {
                if (!this.GetSingleValue(Manufacturer, out var manufacturer))
                    return;
                item.Manufacturer = manufacturer;
            }
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Consumables.Create(item));
        }
    }
}
