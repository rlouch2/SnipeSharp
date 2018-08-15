using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using static SnipeSharp.EndPoint.EndPointExtensions;

namespace SnipeSharp.PowerShell.Cmdlets.Remove
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
    [Cmdlet(VerbsCommon.Remove, nameof(Asset),
        DefaultParameterSetName = nameof(RemoveAsset.ParameterSets.ByAssetTag),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<Asset>))]
    public sealed class RemoveAsset: PSCmdlet
    {
        internal enum ParameterSets
        {
            ByAssetTag,
            ByIdentity,
            ByInternalId,
            ByName,
            BySerial
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
        /// <para type="description">If present, write the response from the Api to the pipeline.</para>
        /// </summary>
        [Parameter]
        public SwitchParameter ShowResponse { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            switch(ParameterSetName)
            {
                case nameof(ParameterSets.ByIdentity):
                    foreach(var item in Identity)
                    {
                        if(item.Object is null)
                        {
                            WriteError(new ErrorRecord(item.Error, $"Asset not found by Identity {item.Object}", ErrorCategory.InvalidArgument, item.Query));
                        } else if(ShouldProcess(item.Query))
                        {
                            var response = ApiHelper.Instance.Assets.Delete(item.Object.Id);
                            if(ShowResponse.IsPresent)
                                WriteObject(response);
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
                        } else if(ShouldProcess(asset.AssetTag))
                        {
                            var response = ApiHelper.Instance.Assets.Delete(asset.Id);
                            if(ShowResponse.IsPresent)
                                WriteObject(response);
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
                        } else if(ShouldProcess(asset.AssetTag))
                        {
                            var response = ApiHelper.Instance.Assets.Delete(asset.Id);
                            if(ShowResponse.IsPresent)
                                WriteObject(response);
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
                        } else if(ShouldProcess(asset.AssetTag))
                        {
                            var response = ApiHelper.Instance.Assets.Delete(asset.Id);
                            if(ShowResponse.IsPresent)
                                WriteObject(response);
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
                        } else if(ShouldProcess(asset.AssetTag))
                        {
                            var response = ApiHelper.Instance.Assets.Delete(asset.Id);
                            if(ShowResponse.IsPresent)
                                WriteObject(response);
                        }
                    }
                    break;
            }
        }
    }
}
