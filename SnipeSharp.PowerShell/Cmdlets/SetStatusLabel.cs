using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "StatusLabel")]
    [OutputType(typeof(StatusLabel))]
    public class SetStatusLabel: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateIdentityNotNull]
        public StatusLabelIdentity StatusLabel { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        [ValidateSet("deployable", "pending", "archived")]
        public string Type { get; set; }

        [Parameter]
        public string Color { get; set; }

        [Parameter]
        public bool ShowInNav { get; set; }

        [Parameter]
        public string Notes { get; set; }

        [Parameter]
        public bool Deployable { get; set; }

        [Parameter]
        public bool Pending { get; set; }

        [Parameter]
        public bool Archived { get; set; }

        protected override void ProcessRecord()
        {
            var item = this.StatusLabel.StatusLabel;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                item.Name = this.Name;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Type)))
                item.Type = this.Type;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Color)))
                item.Color = this.Color;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ShowInNav)))
                item.ShowInNav = this.ShowInNav;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Notes)))
                item.Notes = this.Notes;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Deployable)))
                item.Deployable = this.Deployable;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Pending)))
                item.Pending = this.Pending;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Archived)))
                item.Archived = this.Archived;
            //TODO: error handling
            WriteObject(ApiHelper.Instance.ModelManager.Update(item).Payload);
        }
    }
}