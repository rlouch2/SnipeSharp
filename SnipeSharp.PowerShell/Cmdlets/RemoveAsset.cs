using System;
using System.Management.Automation;
using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Endpoints.SearchFilters;
using SnipeSharp.PowerShell.Enums;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.Common;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT asset.</para>
    /// <para type="description">The Remove-Asset cmdlet removes one or more asset objects from the Snipe IT database.</para>
    /// <para type="description">The Identity, InteralId, Name, AssetTag, and Serial parameters specify the Snipe IT asset to get. InternalId is the Snipe IT-internal Id number. Identity is a catch-all accepting pipeline input and attempting conversion accordingly.</para>
    /// </summary>
    /// <example>
    ///   <code>Remove-Asset -InternalId 12</code>
    ///   <para>Removes an accessory by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-Asset Asset4368</code>
    ///   <para>Removes an asset by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Asset | Remove-Asset</code>
    ///   <para>Removes the first 100 assets by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Get-Asset</para>
    [Cmdlet(VerbsCommon.Remove, "Asset",
        DefaultParameterSetName = "ByAssetTag",
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(IRequestResponse))]
    public class RemoveAsset: PSCmdlet
    {
        /// <summary>
        /// <para type="description">A device identity for an Asset.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByIdentity",
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public AssetIdentity[] Identity { get; set; }

        /// <summary>
        /// <para type="description">The internal Id of the Asset.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByInternalId"
        )]
        public int[] InternalId { get; set; }

        /// <summary>
        /// <para type="description">The name of the Asset.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByName"
        )]
        public string[] Name { get; set; }

        /// <summary>
        /// <para type="description">The asset tag for the Asset.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByAssetTag"
        )]
        public string[] AssetTag { get; set; }

        /// <summary>
        /// <para type="description">The serial Id for the Asset.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "BySerial"
        )]
        public string[] Serial { get; set; }

        /// <summary>
        /// <para type="description">If present, write the response from the Api to the pipeline.</para>
        /// </summary>
        [Parameter]
        public SwitchParameter ShowResponse { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            switch(ParameterSetName)
            {
                case "ByIdentity":
                    foreach(var item in Identity)
                    {
                        if(item.Asset == null)
                        {
                            WriteError(new ErrorRecord(null, $"Asset not found by Identity {item.Identity}", ErrorCategory.InvalidArgument, item.Identity));
                        } else if(ShouldProcess(item.Asset.Name ?? item.Asset.Id.ToString()))
                        {
                            var response = ApiHelper.Instance.AssetManager.Delete(item.Asset);
                            if(ShowResponse.IsPresent)
                                WriteObject(response);
                        }
                    }
                    break;
                case "ByInternalId":
                    foreach(var item in InternalId)
                    {
                        var asset = ApiHelper.Instance.AssetManager.Get(item);
                        if(asset == null)
                        {
                            WriteError(new ErrorRecord(null, $"Asset not found by internal Id {item}", ErrorCategory.InvalidArgument, item));
                        } else if(ShouldProcess(asset.Name ?? asset.Id.ToString()))
                        {
                            var response = ApiHelper.Instance.AssetManager.Delete(item);
                            if(ShowResponse.IsPresent)
                                WriteObject(response);
                        }
                    }
                    break;
                case "ByAssetTag":
                    foreach(var item in AssetTag)
                    {
                        var asset = ApiHelper.Instance.AssetManager.GetByAssetTag(item);
                        if(asset == null)
                        {
                            WriteError(new ErrorRecord(null, $"Asset not found by Asset Tag \"{item}\"", ErrorCategory.InvalidArgument, item));
                        } else if(ShouldProcess(asset.Name ?? asset.Id.ToString()))
                        {
                            var response = ApiHelper.Instance.AssetManager.Delete(asset);
                            if(ShowResponse.IsPresent)
                                WriteObject(response);
                        }
                    }
                    break;
                case "ByName":
                    foreach(var item in Name)
                    {
                        var asset = ApiHelper.Instance.AssetManager.Get(item);
                        if(asset == null)
                        {
                            WriteError(new ErrorRecord(null, $"Asset not found by Name \"{item}\"", ErrorCategory.InvalidArgument, item));
                        } else if(ShouldProcess(asset.Name ?? asset.Id.ToString()))
                        {
                            var response = ApiHelper.Instance.AssetManager.Delete(asset);
                            if(ShowResponse.IsPresent)
                                WriteObject(response);
                        }
                    }
                    break;
                case "BySerial":
                    foreach(var item in Serial)
                    {
                        var asset = ApiHelper.Instance.AssetManager.GetBySerial(item);
                        if(asset == null)
                        {
                            WriteError(new ErrorRecord(null, $"Asset not found by Serial \"{item}\"", ErrorCategory.InvalidArgument, item));
                        } else if(ShouldProcess(asset.Name ?? asset.Id.ToString()))
                        {
                            var response = ApiHelper.Instance.AssetManager.Delete(asset);
                            if(ShowResponse.IsPresent)
                                WriteObject(response);
                        }
                    }
                    break;
            }
        }
    }
}