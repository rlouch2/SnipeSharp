using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Finds a Snipe IT company.</summary>
    /// <remarks>The Find-Company cmdlet finds company objects by filter.</remarks>
    /// <example>
    ///   <code>Find-Company</code>
    ///   <para>Finds all companies.</para>
    /// </example>
    /// <example>
    ///   <code>Find-Company "Potato Heavy Industries"</code>
    ///   <para>Finds companies that match the search string "Potato Heavy Industries".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(Company), SupportsPaging = true)]
    [OutputType(typeof(Company))]
    public class FindCompany: FindObject<Company, string, SearchFilter>
    {
        /// <inheritdoc />
        protected override bool PopulateFilter(SearchFilter filter)
        {
            return true;
        }
    }
}
