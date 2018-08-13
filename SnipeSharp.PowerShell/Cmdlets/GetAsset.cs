using System;
using System.Management.Automation;
using static SnipeSharp.EndPoint.EndPointExtensions;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.BindingTypes;
using System.Collections.Generic;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Gets a Snipe IT asset.</para>
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
    ///   <para>Retrieve the first 100 assets by their identities.</para>
    /// </example>
    /// <para type="link">Find-Asset</para>
    [Cmdlet(VerbsCommon.Get, nameof(Asset),
        DefaultParameterSetName = nameof(GetAsset.ParameterSets.All)
    )]
    [OutputType(typeof(Asset))]
    public sealed class GetAsset: PSCmdlet
    {
        internal enum ParameterSets
        {
            ByAssetTag,
            ByIdentity,
            ByInternalId,
            ByName,
            BySerial,
            All
        }

        /// <summary>
        /// <para type="description">A device identity for an Asset.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = nameof(ParameterSets.ByIdentity),
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public AssetBinding[] Identity { get; set; }

        /// <summary>
        /// <para type="description">The internal Id of the Asset.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = nameof(ParameterSets.ByInternalId)
        )]
        public int[] InternalId { get; set; }

        /// <summary>
        /// <para type="description">The name of the Asset.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = nameof(ParameterSets.ByName)
        )]
        public string[] Name { get; set; }

        /// <summary>
        /// <para type="description">The asset tag for the Asset.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = nameof(ParameterSets.ByAssetTag)
        )]
        public string[] AssetTag { get; set; }

        /// <summary>
        /// <para type="description">The serial Id for the Asset.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = nameof(ParameterSets.BySerial)
        )]
        public string[] Serial { get; set; }

        /// <summary>
        /// <para type="description">If present, return the result as a <see cref="SnipeSharp.EndPoint.Models.ResponseCollection{T}"/> rather than enumerating.</para>
        /// </summary>
        [Parameter(ParameterSetName = nameof(ParameterSets.All))]
        public SwitchParameter NoEnumerate { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            switch(ParameterSetName)
            {
                case nameof(ParameterSets.All):
                    var (assets, err) = ApiHelper.Instance.Assets.GetAllOrNull();
                    if(!(err is null))
                    {
                        WriteError(new ErrorRecord(err, $"An error occurred retrieving all assets.", ErrorCategory.NotSpecified, null));
                    } else
                    {
                        WriteObject(assets, !NoEnumerate.IsPresent);
                    }
                    break;
                case nameof(ParameterSets.ByIdentity):
                    foreach(var item in Identity)
                    {
                        if(item.Object is null)
                        {
                            WriteError(new ErrorRecord(item.Error, $"Asset not found by Identity {item.Object}", ErrorCategory.InvalidArgument, item.Query));
                        } else
                        {
                            WriteObject(item.Object);
                        }
                    }
                    break;
                case nameof(ParameterSets.ByInternalId):
                    foreach(var item in InternalId)
                    {
                        var (asset, error) = ApiHelper.Instance.Assets.GetOrNull(item);
                        if(asset is null)
                        {
                            WriteError(new ErrorRecord(error, $"Asset not found by internal Id {item}", ErrorCategory.InvalidArgument, item));
                        } else
                        {
                            WriteObject(asset);
                        }
                    }
                    break;
                case nameof(ParameterSets.ByAssetTag):
                    foreach(var item in AssetTag)
                    {
                        var (asset, error) = ApiHelper.Instance.Assets.GetByTagOrNull(item);
                        if(asset is null)
                        {
                            WriteError(new ErrorRecord(error, $"Asset not found by Asset Tag \"{item}\"", ErrorCategory.InvalidArgument, item));
                        } else
                        {
                            WriteObject(asset);
                        }
                    }
                    break;
                case nameof(ParameterSets.ByName):
                    foreach(var item in Name)
                    {
                        var (asset, error) = ApiHelper.Instance.Assets.GetOrNull(item);
                        if(asset is null)
                        {
                            WriteError(new ErrorRecord(error, $"Asset not found by Name \"{item}\"", ErrorCategory.InvalidArgument, item));
                        } else
                        {
                            WriteObject(asset);
                        }
                    }
                    break;
                case nameof(ParameterSets.BySerial):
                    foreach(var item in Serial)
                    {
                        var (asset, error) = ApiHelper.Instance.Assets.GetBySerialOrNull(item);
                        if(asset is null)
                        {
                            WriteError(new ErrorRecord(error, $"Asset not found by Serial \"{item}\"", ErrorCategory.InvalidArgument, item));
                        } else
                        {
                            WriteObject(asset);
                        }
                    }
                    break;
            }
        }
    }
}
