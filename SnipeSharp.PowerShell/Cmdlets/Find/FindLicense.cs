using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Finds a Snipe IT license.</summary>
    /// <remarks>The Find-License cmdlet finds license objects by filter.</remarks>
    /// <example>
    ///   <code>Find-License</code>
    ///   <para>Finds all licenses.</para>
    /// </example>
    /// <example>
    ///   <code>Find-License "Potato Tracker"</code>
    ///   <para>Finds licenses that match the search string "Potato Tracker".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(License), SupportsPaging = true)]
    [OutputType(typeof(License))]
    public class FindLicense: FindObject<License, string, SearchFilter>
    {
        /// <inheritdoc />
        protected override bool PopulateFilter(SearchFilter filter)
        {
            return true;
        }
    }
}
