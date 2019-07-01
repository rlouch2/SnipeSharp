using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Creates a new Snipe-IT accessory.</summary>
    /// <remarks>The New-Accessory cmdlet creates a new accessory object.</remarks>
    /// <example>
    ///   <code>New-Accessory -Name "Potato Peeler Wrist strap" -Quantity 9001 -Manufacturer "Potato Peeler Accessories Ltd." -Category "Utility"</code>
    ///   <para>Create a new accessory named "Potato Peeler Wrist strap" with all required properties set.</para>
    /// </example>
    [Cmdlet(VerbsCommon.New, nameof(Accessory))]
    [OutputType(typeof(Accessory))]
    public class NewAccessory: BaseCmdlet
    {
        /// <summary>
        /// The name of the accessory.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// How many of the accessory there are.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1)]
        [ValidateRange(1, int.MaxValue)]
        public int Quantity { get; set; }

        /// <summary>
        /// The manufacturer who made the accessory.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2)]
        public ObjectBinding<Manufacturer> Manufacturer { get; set; }

        /// <summary>
        /// The category of the accessory.
        /// </summary>
        [Parameter(Mandatory = true, Position = 3)]
        public ObjectBinding<Category> Category { get; set; }

        /// <summary>
        /// The company that owns the accessory.
        /// </summary>
        [Parameter]
        public ObjectBinding<Company> Company { get; set; }

        /// <summary>
        /// The supplier who sold the accessory.
        /// </summary>
        [Parameter]
        public ObjectBinding<Supplier> Supplier { get; set; }

        /// <summary>
        /// The model number of the accessory.
        /// </summary>
        [Parameter]
        public string ModelNumber { get; set; }

        /// <summary>
        /// The location of the accessory.
        /// </summary>
        [Parameter]
        public ObjectBinding<Location> Location { get; set; }

        /// <summary>
        /// The date the accessory was purchsed.
        /// </summary>
        [Parameter]
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// How much the accessory cost.
        /// </summary>
        [Parameter]
        public decimal PurchaseCost { get; set; }

        /// <summary>
        /// The order the accessory was purchased in.
        /// </summary>
        [Parameter]
        public string OrderNumber { get; set; }

        /// <summary>
        /// When to start warning that the accessory is running low.
        /// </summary>
        [Parameter]
        public int MinimumQuantity { get; set; }

        /// <summary>
        /// The uri of the image for the accessory.
        /// </summary>
        [Parameter]
        public Uri ImageUri { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {

            var item = new Accessory {
                Name = this.Name,
                Quantity = this.Quantity,
                ModelNumber = this.ModelNumber,
                PurchaseCost = this.PurchaseCost,
                OrderNumber = this.OrderNumber,
                ImageUri = this.ImageUri
            };
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseDate)))
                item.PurchaseDate = PurchaseDate;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseCost)))
                item.PurchaseCost = PurchaseCost;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(MinimumQuantity)))
                item.MinimumQuantity = MinimumQuantity;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
            {
                if (!GetSingleValue(Manufacturer, out var manufacturer, required: true))
                    return;
                item.Manufacturer = manufacturer;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
            {
                if (!GetSingleValue(Category, out var category, required: true))
                    return;
                item.Category = category;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
            {
                if (!GetSingleValue(Company, out var company))
                    return;
                item.Company = company;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Supplier)))
            {
                if (!GetSingleValue(Supplier, out var supplier))
                    return;
                item.Supplier = supplier;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
            {
                if (!GetSingleValue(Location, out var location))
                    return;
                item.Location = location;
            }
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Accessories.Create(item));
        }
    }
}
