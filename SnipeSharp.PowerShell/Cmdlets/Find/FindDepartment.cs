using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Finds a Snipe IT department.</summary>
    /// <remarks>The Find-Asset cmdlet finds departments by filter.</remarks>
    /// <example>
    ///   <code>Find-Department</code>
    ///   <para>Finds all department.</para>
    /// </example>
    /// <example>
    ///   <code>Find-Department "Potato Peeling"</code>
    ///   <para>Finds departments that match the search string "Potato Peeling".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(Department), SupportsPaging = true)]
    [OutputType(typeof(Department))]
    public class FindDepartment: FindObject<Department, string, SearchFilter>
    {
        /// <inheritdoc />
        protected override bool PopulateFilter(SearchFilter filter)
        {
            return true;
        }
    }
}
