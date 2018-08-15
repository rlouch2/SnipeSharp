using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, nameof(Consumable))]
    [OutputType(typeof(Consumable))]
    public class NewConsumable: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ObjectBinding<Category> Category { get; set; }
        
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateRange(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Company> Company { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string ItemNumber { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Location> Location { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Manufacturer> Manufacturer { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public int MinimumQuantity { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string ModelNumber { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string OrderNumber { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public decimal PurchaseCost { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public DateTime PurchaseDate { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public bool IsRequestable { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new Consumable {
                Name = this.Name,
                Category = this.Category?.Object,
                Quantity = this.Quantity,
                Company = this.Company?.Object,
                ItemNumber = this.ItemNumber,
                Location = this.Location?.Object,
                Manufacturer = this.Manufacturer?.Object,
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
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Consumables.Create(item));
        }
    }
}
