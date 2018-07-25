using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell;
using SnipeSharp.Common;

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
    [OutputType(typeof(IRequestResponse))]
    public class CheckOutAsset: PSCmdlet
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
        public AssetIdentity Asset { get; set; }

        /// <summary>
        /// <para type="description">The identity of a User to assign the Asset to.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ToUser",
            Position = 1,
            ValueFromPipelineByPropertyName = true
        )]
        public UserIdentity AssignedUser { get; set; }

        /// <summary>
        /// <para type="description">The identity of a Location to assign the Asset to.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ToLocation",
            Position = 1,
            ValueFromPipelineByPropertyName = true
        )]
        public LocationIdentity AssignedLocation { get; set; }

        /// <summary>
        /// <para type="description">The identity of an Asset to assign the Asset to.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ToAsset",
            Position = 1,
            ValueFromPipelineByPropertyName = true
        )]
        public AssetIdentity AssignedAsset { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(Asset.Asset == null)
            {
                WriteError(new ErrorRecord(null, "Asset not found.", ErrorCategory.InvalidArgument, Asset.Identity));
                return;
            }
            switch(ParameterSetName)
            {
                case "ToUser":
                    if(AssignedUser.User == null)
                    {
                        WriteError(new ErrorRecord(null, "AssignedUser not found.", ErrorCategory.InvalidArgument, AssignedUser.Identity));
                        return;
                    }
                    WriteObject(ApiHelper.Instance.AssetManager.CheckOutAsset(Asset.Asset, AssignedUser.User));
                    break;
                case "ToLocation":
                    if(AssignedLocation.Location == null)
                    {
                        WriteError(new ErrorRecord(null, "AssignedLocation not found.", ErrorCategory.InvalidArgument, AssignedLocation.Identity));
                        return;
                    }
                    WriteObject(ApiHelper.Instance.AssetManager.CheckOutAsset(Asset.Asset, AssignedLocation.Location));
                    break;
                case "ToAsset":
                    if(AssignedAsset.Asset == null)
                    {
                        WriteError(new ErrorRecord(null, "AssignedAsset not found.", ErrorCategory.InvalidArgument, AssignedAsset.Identity));
                        return;
                    }
                    WriteObject(ApiHelper.Instance.AssetManager.CheckOutAsset(Asset.Asset, AssignedAsset.Asset));
                    break;
            }
        }
    }
}