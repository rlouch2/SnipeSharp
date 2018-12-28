using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets.Find
{
    /// <summary>
    /// <para type="synopsis">Finds a Snipe IT model.</para>
    /// <para type="description">The Find-Model cmdlet finds model objects by filter.</para>
    /// </summary>
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
    public class FindModel: FindObject<Model, string, SearchFilter>
    {
        /// <inheritdoc />
        protected override void PopulateFilter(SearchFilter filter)
        {
            // nop
        }
    }
}
