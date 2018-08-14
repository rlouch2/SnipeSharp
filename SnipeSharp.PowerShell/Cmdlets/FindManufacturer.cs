using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.EndPoint.Filters;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Find, nameof(Manufacturer),
        SupportsPaging = true
    )]
    [OutputType(typeof(Manufacturer))]
    public class FindManufacturer: FindObject<Manufacturer, string, SearchFilter>
    {
        /// <inheritdoc />
        protected override void PopulateFilter(SearchFilter filter)
        {
            // nop
        }
    }
}
