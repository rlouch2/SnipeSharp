using System;
using System.Collections.Generic;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets.Get
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
    public sealed class GetAsset: GetObject<Asset, AssetBinding>
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
