using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Finds a Snipe IT category.</summary>
    /// <remarks>The Find-Category cmdlet finds category objects by filter.</remarks>
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
        protected override bool PopulateFilter(SearchFilter filter)
        {
            return true;
        }
    }
}
