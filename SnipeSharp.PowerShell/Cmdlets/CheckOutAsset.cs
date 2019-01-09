using System;
using System.Management.Automation;
using SnipeSharp;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Checks out a Snipe IT asset to a user, location, or other asset.</para>
    /// <para type="description">The CheckOut-Asset cmdlet checks out an asset to a user, location, or another asset.</para>
    /// </summary>
    /// <example>
    ///   <code>CheckOut-Asset -Asset Asset1234 -AssignedUser "Marty McFly"</code>
    ///   <para>Checks out the asset Asset1234 to Marty McFly.</para>
    /// </example>
    /// <example>
    ///   <code>CheckOut-Asset -Asset Asset1234 -AssignedLocation Chicago</code>
    ///   <para>Checks out the asset Asset1234 to the location Chicago.</para>
    /// </example>
    /// <example>
    ///   <code>CheckOut-Asset -Asset Asset1234 -AssignedAsset Asset5678</code>
    ///   <para>Checks out the asset Asset1234 to the asset Asset5678.</para>
    /// </example>
    /// <para type="link">CheckIn-Asset</para>
    /// <para type="link">Get-Asset</para>
    [Cmdlet("CheckOut", "Asset",
        DefaultParameterSetName = "ToUser"
    )]
    [OutputType(typeof(RequestResponse<Asset>))]
    public sealed class CheckOutAsset: PSCmdlet
    {
        /// <summary>
        /// <para type="description">An Asset identity.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public AssetBinding Asset { get; set; }

        /// <summary>
        /// <para type="description">The identity of a User to assign the Asset to.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ToUser",
            ValueFromPipelineByPropertyName = true
        )]
        public UserBinding AssignedUser { get; set; }

        /// <summary>
        /// <para type="description">The identity of a Location to assign the Asset to.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ToLocation",
            ValueFromPipelineByPropertyName = true
        )]
        public ObjectBinding<Location> AssignedLocation { get; set; }

        /// <summary>
        /// <para type="description">The identity of an Asset to assign the Asset to.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ToAsset",
            ValueFromPipelineByPropertyName = true
        )]
        public AssetBinding AssignedAsset { get; set; }

        /// <summary>
        /// <para type="description">The date to mark this Asset as being checked out.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public DateTime? CheckOutAt { get; set; }

        /// <summary>
        /// <para type="description">The date to this Asset is expected to be checked back in.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public DateTime? ExpectedCheckIn { get; set; }

        /// <summary>
        /// <para type="description">The note for the Asset's log.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Note { get; set; }

        /// <summary>
        /// <para type="description">The asset's new name. Defaults to the asset's current name.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string AssetName { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(Asset.Object is null)
            {
                WriteError(new ErrorRecord(Asset.Error, "Asset not found.", ErrorCategory.InvalidArgument, Asset.Query));
                return;
            }
            var request = default(AssetCheckOutRequest);
            switch(ParameterSetName)
            {
                case "ToUser":
                    if(AssignedUser.Object is null)
                    {
                        WriteError(new ErrorRecord(null, "AssignedUser not found.", ErrorCategory.InvalidArgument, AssignedUser.Query));
                        return;
                    }
                    request = new AssetCheckOutRequest(Asset.Object, AssignedUser.Object);
                    
                    break;
                case "ToLocation":
                    if(AssignedLocation.Object is null)
                    {
                        WriteError(new ErrorRecord(null, "AssignedLocation not found.", ErrorCategory.InvalidArgument, AssignedLocation.Query));
                        return;
                    }
                    request = new AssetCheckOutRequest(Asset.Object, AssignedLocation.Object);
                    break;
                case "ToAsset":
                    if(AssignedAsset.Object is null)
                    {
                        WriteError(new ErrorRecord(null, "AssignedAsset not found.", ErrorCategory.InvalidArgument, AssignedAsset.Object));
                        return;
                    }
                    request = new AssetCheckOutRequest(Asset.Object, AssignedAsset.Object);
                    break;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(CheckOutAt)))
                request.CheckOutAt = CheckOutAt;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ExpectedCheckIn)))
                request.ExpectedCheckIn = ExpectedCheckIn;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Note)))
                request.Note = Note;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(AssetName)))
                request.AssetName = AssetName;
            else
                request.AssetName = request.Asset.Name;
            WriteObject(ApiHelper.Instance.Assets.CheckOut(request));
        }
    }
}
