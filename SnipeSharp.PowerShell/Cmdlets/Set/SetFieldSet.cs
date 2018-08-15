using System;
using System.Management.Automation;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.Cmdlets.Set
{
    [Cmdlet(VerbsCommon.Set, nameof(FieldSet))]
    [OutputType(typeof(FieldSet))]
    public class SetFieldSet: SetObject<FieldSet>
    {
        [Parameter]
        public string NewName { get; set; }
        
        /// <inheritdoc />
        protected override void PopulateItem(FieldSet item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = NewName;
        }
    }
}
