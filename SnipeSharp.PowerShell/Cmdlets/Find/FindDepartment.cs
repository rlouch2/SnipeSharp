using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets.Find
{
    /// <summary>
    /// <para type="synopsis">Finds a Snipe IT department.</para>
    /// <para type="description">The Find-Asset cmdlet finds departments by filter.</para>
    /// </summary>
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
        protected override void PopulateFilter(SearchFilter filter)
        {
            // nop
        }
    }
}
