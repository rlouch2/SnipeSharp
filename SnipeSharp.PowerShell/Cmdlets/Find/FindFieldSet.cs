using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Finds a Snipe IT custom field set.</summary>
    /// <remarks>The Find-FieldSet cmdlet finds custom field sets by filter.</remarks>
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
    public class FindFieldSet: FindObject<FieldSet>
    {
    }
}
