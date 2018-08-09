using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "Accessory")]
    [OutputType(typeof(Accessory))]
    public class SetAccessory: PSCmdlet
    {
        internal enum ParameterSets
        {
            ByIdentity,
            ByName,
            ByInternalId
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = nameof(ParameterSets.ByIdentity))]
        [ValidateIdentityNotNull]
        public ObjectBinding<Accessory> Identity { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = nameof(ParameterSets.ByName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = nameof(ParameterSets.ByInternalId))]
        public int Id { get; set; }

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

        protected override void ProcessRecord()
        {
            switch(ParameterSetName)
            {
                case nameof(ParameterSets.ByInternalId):
                    Identity = ObjectBinding<Accessory>.FromId(Id);
                    break;
                case nameof(ParameterSets.ByName):
                    Identity = ObjectBinding<Accessory>.FromName(Name);
                    break;
                case nameof(ParameterSets.ByIdentity):
                    break;
            }
            if(Identity.IsNull)
            {
                WriteError(new ErrorRecord(Identity.Error, $"Accessory not found: {Identity.Query}", ErrorCategory.InvalidArgument, null));
                return;
            }
            var item = Identity.Object;
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

            // TODO: error handling
            WriteObject(ApiHelper.Instance.Accessories.Update(item));
        }
    }
}