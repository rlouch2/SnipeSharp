using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.EndPoint.Filters;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Find, nameof(Asset),
        SupportsPaging = true
    )]
    [OutputType(typeof(Asset))]
    public class FindAsset: FindObject<Asset, AssetSearchColumn, AssetSearchFilter>
    {
        // TODO: parameters

        /// <inheritdoc />
        protected override void PopulateFilter(AssetSearchFilter filter)
        {
            //TODO: parameters
        }
    }
}
