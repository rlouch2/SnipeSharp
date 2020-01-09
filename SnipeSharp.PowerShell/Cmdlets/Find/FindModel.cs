using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Finds a Snipe IT model.</summary>
    /// <remarks>The Find-Model cmdlet finds model objects by filter.</remarks>
    /// <example>
    ///   <code>Find-Model</code>
    ///   <para>Finds all models.</para>
    /// </example>
    /// <example>
    ///   <code>Find-Model "PotatoPeeler Plus"</code>
    ///   <para>Finds models that match the search string "PotatoPeeler Plus".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(Model), SupportsPaging = true)]
    [OutputType(typeof(Model))]
    public class FindModel: FindObject<Model>
    {
    }
}
