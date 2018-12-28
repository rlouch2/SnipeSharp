using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets.Find
{
    /// <summary>
    /// <para type="synopsis">Finds a Snipe IT component.</para>
    /// <para type="description">The Find-Component cmdlet finds component objects by filter.</para>
    /// </summary>
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
    public class FindComponent: FindObject<Component, string, SearchFilter>
    {
        /// <inheritdoc />
        protected override void PopulateFilter(SearchFilter filter)
        {
            // nop
        }
    }
}
