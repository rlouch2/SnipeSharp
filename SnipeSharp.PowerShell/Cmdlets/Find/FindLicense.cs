using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets.Find
{
    /// <summary>
    /// <para type="synopsis">Finds a Snipe IT license.</para>
    /// <para type="description">The Find-License cmdlet finds license objects by filter.</para>
    /// </summary>
    /// <example>
    ///   <code>Find-License</code>
    ///   <para>Finds all licenses.</para>
    /// </example>
    /// <example>
    ///   <code>Find-License "Potato Tracker"</code>
    ///   <para>Finds licenses that match the search string "Potato Tracker".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(License), SupportsPaging = true)]
    [OutputType(typeof(License))]
    public class FindLicense: FindObject<License, string, SearchFilter>
    {
        /// <inheritdoc />
        protected override void PopulateFilter(SearchFilter filter)
        {
            // nop
        }
    }
}
