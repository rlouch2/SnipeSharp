using System;
using System.Collections.Generic;
using System.Management.Automation;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "Asset")]
    [OutputType(typeof(Asset))]
    public class SetAsset: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public AssetIdentity Asset { get; set; }

        [Parameter]
        public string Name { get; set; }
        
        [Parameter]
        public CategoryIdentity Category { get; set; }
        
        [Parameter]
        public CompanyIdentity Company { get; set; }
        
        [Parameter]
        public Dictionary<string, string> CustomFields { get; set; }
        
        [Parameter]
        public LocationIdentity Location { get; set; }
        
        [Parameter]
        public ManufacturerIdentity Manufacturer { get; set; }
        
        [Parameter]
        public ModelIdentity Model { get; set; }

        [Parameter]
        public string ModelNumber { get; set; }
        
        [Parameter]
        public string Notes { get; set; }

        [Parameter]
        public string OrderNumber { get; set; }
        
        [Parameter]
        public string PurchaseCost { get; set; }
        
        [Parameter]
        public string PurchaseDate { get; set; }
        
        [Parameter]
        public LocationIdentity RtdLocation { get; set; }
        
        [Parameter]
        public string Serial { get; set; }
        
        [Parameter)]
        public StatusLabelIdentity StatusLabel { get; set; }

        [Parameter]
        public long WarrantyMonths { get; set; }

        protected override void ProcessRecord()
        {
            var item = this.Asset.Asset;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(AssetTag)))
                item.AssetTag = this.AssetTag;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                item.Name = this.Name;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                item.Category = this.Category;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
                item.Company = this.Company;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)))
                item.CustomFields = this.CustomFields;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
                item.Location = this.Location;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
                item.Manufacturer = this.Manufacturer;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Model)))
                item.Model = this.Model;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ModelNumber)))
                item.ModelNumber = this.ModelNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Notes)))
                item.Notes = this.Notes;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(OrderNumber)))
                item.OrderNumber = this.OrderNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseCost)))
                item.PurchaseCost = this.PurchaseCost;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(RtdLocation)))
                item.RtdLocation = this.RtdLocation;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Serial)))
                item.Serial = this.Serial;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(StatusLabel)))
                item.StatusLabel = this.StatusLabel;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(WarrantyMonths)))
                item.WarrantyMonths = this.WarrantyMonths;
            if(MyInvocation.BoundParameters.ContainsKey(namneof(PurchaseDate)))
                item.PurchaseDate = new ResponseDate {
                    DateTime = this.PurchaseDate
                };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.AssetManager.Update(item).Payload);
        }
    }
}