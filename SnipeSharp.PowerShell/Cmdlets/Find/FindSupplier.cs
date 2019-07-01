using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Finds a Snipe IT supplier.</summary>
    /// <remarks>The Find-Supplier cmdlet finds supplier objects by filter.</remarks>
    /// <example>
    ///   <code>Find-Supplier</code>
    ///   <para>Finds all suppliers.</para>
    /// </example>
    /// <example>
    ///   <code>Find-Supplier "Potato Supplier Inc"</code>
    ///   <para>Finds suppliers that match the search string "Potato Supplier Inc".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(Supplier), SupportsPaging = true)]
    [OutputType(typeof(Supplier))]
    public class FindSupplier: FindObject<Supplier, string, SearchFilter>
    {
        /// <inheritdoc />
        protected override bool PopulateFilter(SearchFilter filter)
        {
            return true;
        }
    }
}
