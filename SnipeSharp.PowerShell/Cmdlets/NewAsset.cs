using System;
using System.Collections.Generic;
using System.Management.Automation;
using SnipeSharp.EndPoint;
using SnipeSharp.EndPoint.Models;
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
            Position = 0
        )]
        [ValidateNotNullOrEmpty]
        public string AssetTag { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1
        )]
        public ObjectBinding<Model> Model { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2
        )]
        public ObjectBinding<StatusLabel> Status { get; set; }
        
        [Parameter]
        public string Name { get; set; }
        
        [Parameter]
        public string Serial { get; set; }

        [Parameter]
        public ObjectBinding<Supplier> Supplier { get; set; }

        [Parameter]
        public string Notes { get; set; }

        [Parameter]
        public string OrderNumber { get; set; }

        [Parameter]
        public ObjectBinding<Company> Company { get; set; }

        [Parameter]
        public ObjectBinding<Location> Location { get; set; }

        [Parameter]
        public ObjectBinding<Location> DefaultLocation { get; set; }

        [Parameter]
        public Uri ImageUri { get; set; }
        
        [Parameter(DontShow = true)]
        public CommonEndPointModel AssignedTo { get; set; }

        [Parameter(DontShow = true)]
        public AssignedToType AssignedType { get; set; }

        [Parameter]
        public DateTime PurchaseDate { get; set; }

        [Parameter]
        public decimal PurchaseCost { get; set; }

        [Parameter]
        public int WarrantyMonths { get; set; }

        [Parameter]
        public Dictionary<string, string> CustomFields { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new Asset {
                AssetTag = this.AssetTag,
                Name = this.Name,
                Company = this.Company?.Object,
                Location = this.Location?.Object,
                Model = this.Model?.Object,
                Notes = this.Notes,
                OrderNumber = this.OrderNumber,
                DefaultLocation = this.DefaultLocation?.Object,
                Serial = this.Serial,
                Status = this.Status?.Object?.ToAssetStatus()
            };
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseDate)))
                item.PurchaseDate = PurchaseDate;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseCost)))
                item.PurchaseCost = PurchaseCost;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(WarrantyMonths)))
                item.WarrantyMonths = WarrantyMonths;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)) && !(CustomFields is null))
                foreach(var pair in CustomFields)
                    item.CustomFields[pair.Key] = new AssetCustomField { Field = pair.Key, Value = pair.Value };

            //TODO: error handling
            WriteObject(ApiHelper.Instance.Assets.Create(item));
        }
    }
}
