using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets.Find
{
    [Cmdlet(VerbsCommon.Find, nameof(Location),
        SupportsPaging = true
    )]
    [OutputType(typeof(Location))]
    public class FindLocation: FindObject<Location, string, SearchFilter>
    {
        /// <inheritdoc />
        protected override void PopulateFilter(SearchFilter filter)
        {
            // nop
        }
    }
}
