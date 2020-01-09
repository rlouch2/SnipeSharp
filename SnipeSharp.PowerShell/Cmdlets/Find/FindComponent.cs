using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Finds a Snipe IT component.</summary>
    /// <remarks>The Find-Component cmdlet finds component objects by filter.</remarks>
    /// <example>
    ///   <code>Find-Component</code>
    ///   <para>Finds all components.</para>
    /// </example>
    /// <example>
    ///   <code>Find-Component "Potato Peeler Blade"</code>
    ///   <para>Finds components that match the search string "Potato Peeler Blade".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(Component), SupportsPaging = true)]
    [OutputType(typeof(Component))]
    public class FindComponent: FindObject<Component>
    {
    }
}
