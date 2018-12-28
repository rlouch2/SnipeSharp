using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets.Find
{
    /// <summary>
    /// <para type="synopsis">Finds a Snipe IT category.</para>
    /// <para type="description">The Find-Category cmdlet finds category objects by filter.</para>
    /// </summary>
    /// <example>
    ///   <code>Find-Category</code>
    ///   <para>Finds all categories.</para>
    /// </example>
    /// <example>
    ///   <code>Find-Category "Peeler"</code>
    ///   <para>Finds categories that match the search string "Peeler".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(Category), SupportsPaging = true)]
    [OutputType(typeof(Category))]
    public class FindCategory: FindObject<Category, string, SearchFilter>
    {
        /// <inheritdoc />
        protected override void PopulateFilter(SearchFilter filter)
        {
            // nop
        }
    }
}
