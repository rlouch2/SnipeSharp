using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets.Find
{
    /// <summary>
    /// <para type="synopsis">Finds a Snipe IT location.</para>
    /// <para type="description">The Find-Asset cmdlet finds location objects by filter.</para>
    /// </summary>
    /// <example>
    ///   <code>Find-Location</code>
    ///   <para>Finds all locations.</para>
    /// </example>
    /// <example>
    ///   <code>Find-Location "Potato Farm"</code>
    ///   <para>Finds location that match the search string "Potato Farm".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(Location), SupportsPaging = true)]
    [OutputType(typeof(Location))]
    public class FindLocation: FindObject<Location, string, SearchFilter>
    {
        /// <inheritdoc />
        protected override void PopulateFilter(SearchFilter filter)
        {
            // nop
        }
    }
}
