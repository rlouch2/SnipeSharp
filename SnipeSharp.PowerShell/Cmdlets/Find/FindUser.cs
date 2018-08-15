using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets.Find
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
