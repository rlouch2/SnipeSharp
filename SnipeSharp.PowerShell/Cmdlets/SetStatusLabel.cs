using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, nameof(StatusLabel))]
    [OutputType(typeof(StatusLabel))]
    public class SetStatusLabel: SetObject<StatusLabel>
    {
        [Parameter]
        public string NewName { get; set; }

        [Parameter]
        public StatusType Type { get; set; }

        [Parameter]
        public string Notes { get; set; }

        /// <inheritdoc />
        protected override void PopulateItem(StatusLabel item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Type)))
                item.Type = this.Type;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Notes)))
                item.Notes = this.Notes;
            //TODO: error handling
            WriteObject(ApiHelper.Instance.StatusLabels.Update(item));
        }
    }
}
