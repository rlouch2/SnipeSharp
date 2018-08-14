using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.EndPoint.Filters;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Find, nameof(User),
        SupportsPaging = true
    )]
    [OutputType(typeof(User))]
    public class FindUser: FindObject<User, string, SearchFilter>
    {
        /// <inheritdoc />
        protected override void PopulateFilter(SearchFilter filter)
        {
            // nop
        }
    }
}
