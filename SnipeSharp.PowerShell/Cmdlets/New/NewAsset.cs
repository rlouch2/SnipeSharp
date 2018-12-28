using System;
using System.Collections.Generic;
using System.Management.Automation;
using SnipeSharp.EndPoint;
using SnipeSharp.Models;
using SnipeSharp.Models.Enumerations;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets.New
{
    [Cmdlet(VerbsCommon.New, nameof(Asset))]
    [OutputType(typeof(Asset))]
    public class NewAsset: PSCmdlet
    {
        /// <summary>
        /// The asset tag of the Asset.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string AssetTag { get; set; }

        /// <summary>
        /// The model of the Asset.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1)]
        public ObjectBinding<Model> Model { get; set; }

        /// <summary>
        /// The status of the asset.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2)]
        public ObjectBinding<StatusLabel> Status { get; set; }
        
        /// <summary>
        /// The name of the asset.
        /// </summary>
        [Parameter]
        public string Name { get; set; }
        
        /// <summary>
        /// The serial number of the asset.
        /// </summary>
        [Parameter]
        public string Serial { get; set; }

        /// <summary>
        /// The supplier who sold the asset.
        /// </summary>
        [Parameter]
        public ObjectBinding<Supplier> Supplier { get; set; }

        /// <summary>
        /// Any notes for the asset.
        /// </summary>
        [Parameter]
        public string Notes { get; set; }

        /// <summary>
        /// The order number the asset was purchased in.
        /// </summary>
        [Parameter]
        public string OrderNumber { get; set; }

        /// <summary>
        /// The company that owns the asset.
        /// </summary>
        [Parameter]
        public ObjectBinding<Company> Company { get; set; }

        /// <summary>
        /// The location of the asset.
        /// </summary>
        [Parameter]
        public ObjectBinding<Location> Location { get; set; }

        /// <summary>
        /// The default location the asset returns to when unassigned.
        /// </summary>
        [Parameter]
        public ObjectBinding<Location> DefaultLocation { get; set; }

        /// <summary>
        /// The uri for the image of the Asset.
        /// </summary>
        [Parameter]
        public Uri ImageUri { get; set; }
        
        /// <summary>
        /// What the asset is assigned to.
        /// </summary>
        [Parameter(DontShow = true)]
        public CommonEndPointModel AssignedTo { get; set; }

        /// <summary>
        /// What kind of thing the asset is assigned to.
        /// </summary>
        [Parameter(DontShow = true)]
        public AssignedToType AssignedType { get; set; }

        /// <summary>
        /// When the asset was purchased.
        /// </summary>
        [Parameter]
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// How much the asset cost.
        /// </summary>
        [Parameter]
        public decimal PurchaseCost { get; set; }

        /// <summary>
        /// How long the asset's warranty is.
        /// </summary>
        [Parameter]
        public int WarrantyMonths { get; set; }

        /// <summary>
        /// Custom fields required by the asset's model's field set.
        /// </summary>
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
