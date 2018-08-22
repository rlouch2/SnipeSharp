using System.Collections.Generic;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

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
        DefaultParameterSetName = nameof(RemoveAsset.AssetParameterSets.ByAssetTag),
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(RequestResponse<Asset>))]
    public sealed class RemoveAsset: RemoveObject<Asset, AssetBinding>
    {
        internal enum AssetParameterSets
        {
            ByAssetTag,
            BySerial
        }

        /// <summary>
        /// <para type="description">The asset tag for the Asset.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = nameof(AssetParameterSets.ByAssetTag)
        )]
        public string[] AssetTag { get; set; }

        /// <summary>
        /// <para type="description">The serial Id for the Asset.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = nameof(AssetParameterSets.BySerial)
        )]
        public string[] Serial { get; set; }

        /// <inheritdoc />
        protected override IEnumerable<AssetBinding> GetBoundObjects()
        {
            if(ParameterSetName == nameof(AssetParameterSets.ByAssetTag))
            {
                foreach(var item in AssetTag)
                    yield return AssetBinding.FromTag(item);
            } else
            {
                foreach(var item in Serial)
                    yield return AssetBinding.FromSerial(item);
            }
        }
    }
}
