using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets.Find
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
