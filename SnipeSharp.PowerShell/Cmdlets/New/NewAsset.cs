using System;
using System.Collections.Generic;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Models.Enumerations;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Creates a new Snipe-IT asset.</summary>
    /// <remarks>The New-Asset cmdlet creates a new asset object.</remarks>
    /// <example>
    ///   <code>New-Asset -AssetTag '06514' -Model 'PotatoPeeler Plus 3000' -Status 'Assignable'</code>
    ///   <para>Create a new asset with the asset tag "06541" with all required properties set.</para>
    /// </example>
    [Cmdlet(VerbsCommon.New, nameof(Asset))]
    [OutputType(typeof(Asset))]
    public class NewAsset: BaseCmdlet
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
        /// Custom fields used by the asset's model's field set.
        /// </summary>
        [Parameter]
        public Dictionary<string, string> CustomFields { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new Asset {
                AssetTag = this.AssetTag,
                Name = this.Name,
                Notes = this.Notes,
                OrderNumber = this.OrderNumber,
                Serial = this.Serial
            };
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseDate)))
                item.PurchaseDate = PurchaseDate;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseCost)))
                item.PurchaseCost = PurchaseCost;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(WarrantyMonths)))
                item.WarrantyMonths = WarrantyMonths;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
            {
                if(!GetSingleValue(Company, out var company))
                    return;
                item.Company = company;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
            {
                if(!GetSingleValue(Location, out var location))
                    return;
                item.Location = location;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Model)))
            {
                if(!GetSingleValue(Model, out var model, required: true))
                    return;
                item.Model = model;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(DefaultLocation)))
            {
                if(!GetSingleValue(DefaultLocation, out var defaultLocation))
                    return;
                item.DefaultLocation = defaultLocation;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Status)))
            {
                if(!GetSingleValue(Status, out var status, required: true))
                    return;
                item.Status = status.ToAssetStatus();
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)) && !(CustomFields is null))
                foreach(var pair in CustomFields)
                    item.CustomFields[pair.Key] = new AssetCustomField { Field = pair.Key, Value = pair.Value };

            //TODO: error handling
            WriteObject(ApiHelper.Instance.Assets.Create(item));
        }
    }
}
