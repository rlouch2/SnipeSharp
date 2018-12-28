using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets.Find
{
    /// <summary>
    /// <para type="synopsis">Finds a Snipe IT depreciation.</para>
    /// <para type="description">The Find-Depreciation cmdlet finds depreciations by filter.</para>
    /// </summary>
    /// <example>
    ///   <code>Find-Depreciation</code>
    ///   <para>Finds all depreciations.</para>
    /// </example>
    /// <example>
    ///   <code>Find-Depreciation "PotatoPeeler"</code>
    ///   <para>Finds depreciations that match the search string "PotatoPeeler".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(Depreciation), SupportsPaging = true)]
    [OutputType(typeof(Depreciation))]
    public class FindDepreciation: FindObject<Depreciation, string, SearchFilter>
    {
        /// <inheritdoc />
        protected override void PopulateFilter(SearchFilter filter)
        {
            // nop
        }
    }
}
