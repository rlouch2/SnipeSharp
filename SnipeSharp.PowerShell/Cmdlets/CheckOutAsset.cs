using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Checks out a Snipe IT asset to a user, location, or other asset.</summary>
    /// <remarks>The CheckOut-Asset cmdlet checks out an asset to a user, location, or another asset.</remarks>
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
    /// <seealso cref="CheckInAsset" />
    /// <seealso cref="GetAsset" />
    [Cmdlet("CheckOut", "Asset", DefaultParameterSetName = "ToUser")]
    [OutputType(typeof(RequestResponse<Asset>))]
    public sealed class CheckOutAsset: Cmdlet
    {
        /// <summary>An Asset identity.</summary>
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public AssetBinding Asset { get; set; }

        /// <summary>The identity of a User to assign the Asset to.</summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ToUser",
            ValueFromPipelineByPropertyName = true
        )]
        public UserBinding AssignedUser { get; set; }

        /// <summary>The identity of a Location to assign the Asset to.</summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ToLocation",
            ValueFromPipelineByPropertyName = true
        )]
        public ObjectBinding<Location> AssignedLocation { get; set; }

        /// <summary>The identity of an Asset to assign the Asset to.</summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ToAsset",
            ValueFromPipelineByPropertyName = true
        )]
        public AssetBinding AssignedAsset { get; set; }

        /// <summary>The date to mark this Asset as being checked out.</summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public DateTime? CheckOutAt { get; set; }

        /// <summary>The date to this Asset is expected to be checked back in.</summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public DateTime? ExpectedCheckIn { get; set; }

        /// <summary>The note for the Asset's log.</summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Note { get; set; }

        /// <summary>The asset's new name. Defaults to the asset's current name.</summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string AssetName { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(!this.GetSingleValue(Asset, out var asset, queryType: "Identity", required: true))
                return;
            if(asset.IsDeleted)
                throw new InvalidOperationException($"Cannot checkout asset {asset.Name} because it has been deleted.");
            AssetCheckOutRequest request;
            if(null != AssignedUser)
            {
                // ToUser ParameterSet
                if(!this.GetSingleValue(AssignedUser, out var user, queryType: "Identity", required: true))
                    return;
                request = new AssetCheckOutRequest(asset, user);
            } else if(null != AssignedLocation)
            {
                if(!this.GetSingleValue(AssignedLocation, out var location, queryType: "Identity", required: true))
                    return;
                request = new AssetCheckOutRequest(asset, location);
            } else
            {
                if(!this.GetSingleValue(AssignedAsset, out var assignedAsset, queryType: "Identity", required: true))
                    return;
                if(assignedAsset.IsDeleted)
                    throw new InvalidOperationException($"Cannot checkout to asset {assignedAsset.Name} because it has been deleted.");
                request = new AssetCheckOutRequest(asset, assignedAsset);
            }
            if(null != CheckOutAt)
                request.CheckOutAt = CheckOutAt;
            if(null != ExpectedCheckIn)
                request.ExpectedCheckIn = ExpectedCheckIn;
            if(!string.IsNullOrEmpty(Note))
                request.Note = Note;
            if(!string.IsNullOrEmpty(AssetName))
                request.AssetName = AssetName;
            else
                request.AssetName = request.Asset.Name;
            WriteObject(ApiHelper.Instance.Assets.CheckOut(request));
        }
    }
}
