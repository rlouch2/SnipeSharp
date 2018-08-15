using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "Depreciation")]
    [OutputType(typeof(Depreciation))]
    public class SetDepreciation: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateIdentityNotNull]
        public DepreciationIdentity Depreciation { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public string Months { get; set; }

        protected override void ProcessRecord()
        {
            var item = this.Depreciation.Depreciation;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                item.Name = this.Name;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Months)))
                item.Months = this.Months;
            //TODO: error handling
            WriteObject(ApiHelper.Instance.DepreciationManager.Update(item).Payload);
        }
    }
}