using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets.Find
{
    /// <summary>
    /// <para type="synopsis">Finds a Snipe IT status label.</para>
    /// <para type="description">The Find-StatusLabel cmdlet finds status label objects by filter.</para>
    /// </summary>
    /// <example>
    ///   <code>Find-StatusLabel</code>
    ///   <para>Finds all status labels.</para>
    /// </example>
    /// <example>
    ///   <code>Find-StatusLabel "Pending"</code>
    ///   <para>Finds status labels that match the search string "Pending".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(StatusLabel), SupportsPaging = true)]
    [OutputType(typeof(StatusLabel))]
    public class FindStatusLabel: FindObject<StatusLabel, string, SearchFilter>
    {
        /// <inheritdoc />
        protected override void PopulateFilter(SearchFilter filter)
        {
            // nop
        }
    }
}
