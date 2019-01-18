using System;
using System.Collections.Generic;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Gets a Snipe IT asset.</summary>
    /// <remarks>
    ///   <para>The Get-Asset cmdlet gets one or more asset objects.</para>
    ///   <para>The Identity, InteralId, Name, AssetTag, and Serial parameters specify the Snipe IT asset to get. InternalId is the Snipe IT-internal Id number. Identity is a catch-all accepting pipeline input and attempting conversion accordingly.</para>
    /// </remarks>
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
    /// <seealso cref="FindAsset" />
    [Cmdlet(VerbsCommon.Get, nameof(Asset), DefaultParameterSetName = nameof(GetAsset.ParameterSets.All))]
    [OutputType(typeof(Asset))]
    public sealed class GetAsset: GetObject<Asset, AssetBinding>
    {
        /// <summary>
        /// Extra parameter sets this cmdlet supports.
        /// </summary>
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
