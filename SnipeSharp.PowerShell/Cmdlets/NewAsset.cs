using System;
using System.Collections.Generic;
using System.Management.Automation;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "Asset")]
    [OutputType(typeof(Asset))]
    public class NewAsset: PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNullOrEmpty]
        public string AssetTag { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public CategoryIdentity Category { get; set; }
        
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public CompanyIdentity Company { get; set; }
        
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Dictionary<string, string> CustomFields { get; set; }
        
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public LocationIdentity Location { get; set; }
        
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ManufacturerIdentity Manufacturer { get; set; }
        
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ModelIdentity Model { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ModelNumber { get; set; }
        
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Notes { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string OrderNumber { get; set; }
        
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PurchaseCost { get; set; }
        
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PurchaseDate { get; set; }
        
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public LocationIdentity RtdLocation { get; set; }
        
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Serial { get; set; }
        
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public StatusLabelIdentity StatusLabel { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public long? WarrantyMonths { get; set; }

        protected override void ProcessRecord()
        {
            var item = new Asset {
                AssetTag = this.AssetTag,
                Name = this.Name,
                Category = this.Category?.Category,
                Company = this.Company?.Company,
                CustomFields = this.CustomFields,
                Location = this.Location?.Location,
                Manufacturer = this.Manufacturer?.Manufacturer,
                Model = this.Model?.Model,
                ModelNumber = this.ModelNumber,
                Notes = this.Notes,
                OrderNumber = this.OrderNumber,
                PurchaseCost = this.PurchaseCost,
                RtdLocation = this.RtdLocation?.Location,
                Serial = this.Serial,
                StatusLabel = this.StatusLabel?.StatusLabel,
                WarrantyMonths = this.WarrantyMonths?.ToString()
            };
            if(PurchaseDate != null)
            {
                item.PurchaseDate = new ResponseDate {
                    DateTime = this.PurchaseDate
                };
            }
            //TODO: error handling
            WriteObject(ApiHelper.Instance.AssetManager.Create(item).Payload);
        }
    }
}