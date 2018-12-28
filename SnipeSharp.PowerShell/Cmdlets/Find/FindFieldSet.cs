using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets.Find
{
    /// <summary>
    /// <para type="synopsis">Finds a Snipe IT custom field set.</para>
    /// <para type="description">The Find-FieldSet cmdlet finds custom field sets by filter.</para>
    /// </summary>
    /// <example>
    ///   <code>Find-FieldSet</code>
    ///   <para>Finds all field sets.</para>
    /// </example>
    /// <example>
    ///   <code>Find-FieldSet "PotatoPeeler"</code>
    ///   <para>Finds field sets that match the search string "PotatoPeeler".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(FieldSet), SupportsPaging = true)]
    [OutputType(typeof(FieldSet))]
    public class FindFieldSet: FindObject<FieldSet, string, SearchFilter>
    {
        /// <inheritdoc />
        protected override void PopulateFilter(SearchFilter filter)
        {
            // nop
        }
    }
}
