using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Finds a Snipe IT depreciation.</summary>
    /// <remarks>The Find-Depreciation cmdlet finds depreciations by filter.</remarks>
    /// <example>
    ///   <code>Find-Depreciation</code>
    ///   <para>Finds all depreciations.</para>
    /// </example>
    /// <example>
    ///   <code>Find-Depreciation "PotatoPeeler"</code>
    ///   <para>Finds depreciations that match the search string "PotatoPeeler".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(Depreciation), SupportsPaging = true)]
    [OutputType(typeof(Depreciation))]
    public class FindDepreciation: FindObject<Depreciation>
    {
    }
}
