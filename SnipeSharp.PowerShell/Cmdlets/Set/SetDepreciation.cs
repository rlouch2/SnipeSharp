using System;
using System.Management.Automation;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.Cmdlets.Set
{
    [Cmdlet(VerbsCommon.Set, nameof(Depreciation))]
    [OutputType(typeof(Depreciation))]
    public class SetDepreciation: SetObject<Depreciation>
    {
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string NewName { get; set; }

        [Parameter]
        public int Months { get; set; }

        /// <inheritdoc />
        protected override void PopulateItem(Depreciation item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Months)))
                item.Months = this.Months;
        }
    }
}
