using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets.Find
{
    /// <summary>
    /// <para type="synopsis">Finds a Snipe IT asset.</para>
    /// <para type="description">The Find-Asset cmdlet finds asset objects by filter.</para>
    /// </summary>
    /// <example>
    ///   <code>Find-Asset</code>
    ///   <para>Finds all assets.</para>
    /// </example>
    /// <example>
    ///   <code>Find-Asset "PotatoPeeler"</code>
    ///   <para>Finds assets that match the search string "PotatoPeeler".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(Asset), SupportsPaging = true)]
    [OutputType(typeof(Asset))]
    public class FindAsset: FindObject<Asset, AssetSearchColumn, AssetSearchFilter>
    {
        /// <inheritdoc />
        protected override void PopulateFilter(AssetSearchFilter filter)
        {
            //nop
        }
    }
}
