using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets.New
{
    [Cmdlet(VerbsCommon.New, nameof(Accessory))]
    [OutputType(typeof(Accessory))]
    public class NewAccessory: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 1)]
        [ValidateRange(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        public ObjectBinding<Manufacturer> Manufacturer { get; set; }

        [Parameter(Mandatory = true, Position = 3)]
        public ObjectBinding<Category> Category { get; set; }
        
        [Parameter]
        public ObjectBinding<Company> Company { get; set; }

        [Parameter]
        public ObjectBinding<Supplier> Supplier { get; set; }

        [Parameter]
        public string ModelNumber { get; set; }

        [Parameter]
        public ObjectBinding<Location> Location { get; set; }

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
        protected override void ProcessRecord()
        {
            var item = new Accessory {
                Name = this.Name,
                Quantity = this.Quantity,
                Manufacturer = this.Manufacturer?.Object,
                Category = this.Category?.Object,
                Company = this.Company?.Object,
                Supplier = this.Supplier?.Object,
                ModelNumber = this.ModelNumber,
                Location = this.Location?.Object,
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
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Accessories.Create(item));
        }
    }
}
