using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets.Find
{
    /// <summary>
    /// <para type="synopsis">Finds a Snipe IT manufacturer.</para>
    /// <para type="description">The Find-Asset cmdlet finds manufacturer objects by filter.</para>
    /// </summary>
    /// <example>
    ///   <code>Find-Manufacturer</code>
    ///   <para>Finds all manufacturers.</para>
    /// </example>
    /// <example>
    ///   <code>Find-Manufacturer "Potato Peelers United"</code>
    ///   <para>Finds manufacturers that match the search string "Potato Peelers United".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(Manufacturer), SupportsPaging = true)]
    [OutputType(typeof(Manufacturer))]
    public class FindManufacturer: FindObject<Manufacturer, string, SearchFilter>
    {
        /// <inheritdoc />
        protected override void PopulateFilter(SearchFilter filter)
        {
            // nop
        }
    }
}
