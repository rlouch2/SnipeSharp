using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Finds a Snipe IT location.</summary>
    /// <remarks>The Find-Asset cmdlet finds location objects by filter.</remarks>
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
        protected override bool PopulateFilter(SearchFilter filter)
        {
            return true;
        }
    }
}
