using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Endpoints.SearchFilters;
using SnipeSharp.PowerShell.Enums;
using SnipeSharp.PowerShell.BindingTypes;
using System.Collections.Generic;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Gets an Snipe IT asset.</para>
    /// <para type="description">The Get-Asset cmdlet gets one or more asset objects.</para>
    /// <para type="description">The Identity, InteralId, Name, AssetTag, and Serial parameters specify the Snipe IT asset to get. InternalId is the Snipe IT-internal Id number. Identity is a catch-all accepting pipeline input and attempting conversion accordingly.</para>
    /// </summary>
    /// <example>
    ///   <code>Get-Asset Asset4638</code>
    ///   <para>Retrieve an asset by its Identity.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Asset -Name Asset4368</code>
    ///   <para>Retrieve an asset explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Asset</code>
    ///   <para>Retrieve the first 100 assets by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Asset</para>
    [Cmdlet(VerbsCommon.Get, "Asset",
        DefaultParameterSetName = "ByAssetTag"
    )]
    [OutputType(typeof(Asset))]
    public class GetAsset: PSCmdlet
    {
        /// <summary>
        /// <para type="description">A device identity for an Asset.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByIdentity",
            Position = 0,
            ValueFromPipeline = true,
            ValueFromRemainingArguments = true
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

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var asset = new List<Asset>();
            switch(ParameterSetName)
            {
                case "ByIdentity":
                    foreach(var item in Identity)
                    {
                        if(item.Asset == null)
                        {
                            WriteError(new ErrorRecord(null, $"Asset not found by Identity {item.Identity}", ErrorCategory.InvalidArgument, item.Identity));
                        }
                        asset.Add(item.Asset);
                    }
                    break;
                case "ByInternalId":
                    foreach(var item in InternalId)
                    {
                        var assetItem = ApiHelper.Instance.AssetManager.Get(item);
                        if(assetItem == null)
                        {
                            WriteError(new ErrorRecord(null, $"Asset not found by internal Id {item}", ErrorCategory.InvalidArgument, item));
                        }
                        asset.Add(assetItem);
                    }
                    break;
                case "ByAssetTag":
                    foreach(var item in AssetTag)
                    {
                        var assetItem = ApiHelper.Instance.AssetManager.GetByAssetTag(item);
                        if(assetItem == null)
                        {
                            WriteError(new ErrorRecord(null, $"Asset not found by Asset Tag \"{item}\"", ErrorCategory.InvalidArgument, item));
                        }
                        asset.Add(assetItem);
                    }
                    break;
                case "ByName":
                    foreach(var item in Name)
                    {
                        var assetItem = ApiHelper.Instance.AssetManager.Get(item);
                        if(assetItem == null)
                        {
                            WriteError(new ErrorRecord(null, $"Asset not found by Name \"{item}\"", ErrorCategory.InvalidArgument, item));
                        }
                        asset.Add(assetItem);
                    }
                    break;
                case "BySerial":
                    foreach(var item in Serial)
                    {
                        var assetItem = ApiHelper.Instance.AssetManager.GetBySerial(item);
                        if(assetItem == null)
                        {
                            WriteError(new ErrorRecord(null, $"Asset not found by Serial \"{item}\"", ErrorCategory.InvalidArgument, item));
                        }
                        asset.Add(assetItem);
                    }
                    break;
            }

            if(asset == null)
                throw new Exception("Asset not found");
            else
                WriteObject(asset, true);
        }
    }
}