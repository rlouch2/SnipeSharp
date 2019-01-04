using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets.Find
{
    /// <summary>
    /// <para type="synopsis">Finds a Snipe IT custom field.</para>
    /// <para type="description">The Find-CustomField cmdlet finds custom fields by filter.</para>
    /// </summary>
    /// <example>
    ///   <code>Find-CustomField</code>
    ///   <para>Finds all fields.</para>
    /// </example>
    /// <example>
    ///   <code>Find-CustomField "Length"</code>
    ///   <para>Finds field sets that match the search string "Length".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(CustomField), SupportsPaging = true)]
    [OutputType(typeof(CustomField))]
    public class FindCustomField: FindObject<CustomField, string, SearchFilter>
    {
        /// <inheritdoc />
        protected override void PopulateFilter(SearchFilter filter)
        {
            // nop
        }
    }
}
