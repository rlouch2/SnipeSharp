using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Models.Enumerations;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets.Set
{
    [Cmdlet(VerbsCommon.Set, nameof(StatusLabel))]
    [OutputType(typeof(StatusLabel))]
    public class SetStatusLabel: SetObject<StatusLabel>
    {
        /// <summary>
        /// The new name of the status label.
        /// </summary>
        [Parameter]
        public string NewName { get; set; }

        /// <summary>
        /// The updated type of status the label represents.
        /// </summary>
        [Parameter]
        public StatusType Type { get; set; }

        /// <summary>
        /// Any notes about the status label.
        /// </summary>
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
