using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets.Find
{
    /// <summary>
    /// <para type="synopsis">Finds a Snipe IT company.</para>
    /// <para type="description">The Find-Company cmdlet finds company objects by filter.</para>
    /// </summary>
    /// <example>
    ///   <code>Find-Company</code>
    ///   <para>Finds all company.</para>
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
        protected override void PopulateFilter(SearchFilter filter)
        {
            // nop
        }
    }
}
