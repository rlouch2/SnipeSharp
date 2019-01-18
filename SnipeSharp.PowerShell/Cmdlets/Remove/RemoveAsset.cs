using System.Collections.Generic;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Removes a Snipe IT asset.</summary>
    /// <remarks>
    ///   <para>The Remove-Asset cmdlet removes one or more asset objects from the Snipe IT database.</para>
    ///   <para>The Identity, InteralId, Name, AssetTag, and Serial parameters specify the Snipe IT asset to get. InternalId is the Snipe IT-internal Id number. Identity is a catch-all accepting pipeline input and attempting conversion accordingly.</para>
    /// </remarks>
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
    /// <seealso cref="GetAsset" />
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

        /// <summary>The asset tag for the Asset.</summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = nameof(AssetParameterSets.ByAssetTag)
        )]
        public string[] AssetTag { get; set; }

        /// <summary>The serial Id for the Asset.</summary>
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
