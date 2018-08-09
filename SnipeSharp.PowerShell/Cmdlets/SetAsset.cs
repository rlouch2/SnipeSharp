using System;
using System.Collections.Generic;
using System.Management.Automation;
using SnipeSharp.EndPoint;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, nameof(Asset),
        SupportsShouldProcess = true,
        DefaultParameterSetName = nameof(ParameterSets.ByIdentity)
    )]
    [OutputType(typeof(Asset))]
    public sealed class SetAsset: PSCmdlet
    {
        internal enum ParameterSets
        {
            ByIdentity,
            ByName,
            ByInternalId,
            ByAssetTag,
            BySerial
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = nameof(ParameterSets.ByIdentity))]
        [ValidateIdentityNotNull]
        public AssetBinding Identity { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = nameof(ParameterSets.ByName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = nameof(ParameterSets.ByInternalId))]
        public int Id { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = nameof(ParameterSets.ByAssetTag))]
        [ValidateNotNullOrEmpty]
        public string AssetTag { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = nameof(ParameterSets.BySerial))]
        [ValidateNotNullOrEmpty]
        public string Serial { get; set; }

        [Parameter]
        public string NewAssetTag { get; set; }

        [Parameter]
        public string NewName { get; set; }

        [Parameter]
        public string NewSerial { get; set; }
        
        [Parameter]
        public ObjectBinding<Model> Model { get; set; }

        [Parameter]
        public ObjectBinding<StatusLabel> Status { get; set; }

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

        protected override void ProcessRecord()
        {
            switch(ParameterSetName)
            {
                case nameof(ParameterSets.ByAssetTag):
                    Identity = AssetBinding.FromTag(AssetTag);
                    break;
                case nameof(ParameterSets.ByInternalId):
                    Identity = AssetBinding.FromId(Id);
                    break;
                case nameof(ParameterSets.ByName):
                    Identity = AssetBinding.FromName(Name);
                    break;
                case nameof(ParameterSets.BySerial):
                    Identity = AssetBinding.FromSerial(Serial);
                    break;
                case nameof(ParameterSets.ByIdentity):
                    break;
            }
            if(Identity.IsNull)
            {
                WriteError(new ErrorRecord(Identity.Error, $"Asset not found: {Identity.Query}", ErrorCategory.InvalidArgument, null));
                return;
            }
            var item = Identity.Object;

            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewAssetTag)))
                item.AssetTag = NewAssetTag;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewSerial)))
                item.Serial = NewSerial;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Model)))
                item.Model = Model?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Status)))
                item.Status = Status?.Object?.ToAssetStatus();
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Supplier)))
                item.Supplier = Supplier?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Notes)))
                item.Notes = Notes;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(OrderNumber)))
                item.OrderNumber = OrderNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
                item.Company = Company?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
                item.Location = Location?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(DefaultLocation)))
                item.DefaultLocation = DefaultLocation?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ImageUri)))
                item.ImageUri = ImageUri;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(AssignedTo)))
                item.AssignedTo = AssignedTo;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(AssignedType)))
                item.AssignedType = AssignedType;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseCost)))
                item.PurchaseCost = PurchaseCost;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseDate)))
                item.PurchaseDate = PurchaseDate;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(WarrantyMonths)))
                item.WarrantyMonths = WarrantyMonths;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)) && CustomFields != null)
                foreach(var pair in CustomFields)
                    item.CustomFields[pair.Key] = new AssetCustomField { Field = pair.Key, Value = pair.Value };
            
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Assets.Update(item));
        }
    }
}
