using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.EndPoint.Filters;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Find, nameof(Model),
        SupportsPaging = true
    )]
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
