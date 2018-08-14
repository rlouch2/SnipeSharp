using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.EndPoint.Filters;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Find, nameof(Supplier),
        SupportsPaging = true
    )]
    [OutputType(typeof(Supplier))]
    public class FindSupplier: FindObject<Supplier, string, SearchFilter>
    {
        /// <inheritdoc />
        protected override void PopulateFilter(SearchFilter filter)
        {
            // nop
        }
    }
}
