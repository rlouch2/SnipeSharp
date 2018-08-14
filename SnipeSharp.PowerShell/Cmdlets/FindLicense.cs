using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.EndPoint.Filters;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Find, nameof(License),
        SupportsPaging = true
    )]
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
