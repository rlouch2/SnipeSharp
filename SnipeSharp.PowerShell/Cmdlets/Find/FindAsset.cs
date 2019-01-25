using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Finds a Snipe IT asset.</summary>
    /// <remarks>The Find-Asset cmdlet finds asset objects by filter.</remarks>
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
        protected override bool PopulateFilter(AssetSearchFilter filter)
        {
            return true;
        }
    }
}
