using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "Category")]
    [OutputType(typeof(Category))]
    public class SetCategory: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateIdentityNotNull]
        public CategoryIdentity Category { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        [ValidateSet("asset", "accessory", "consumable", "component")]
        public string Type { get; set; }

        [Parameter]
        public bool Eula { get; set; }

        [Parameter]
        public bool CheckInEmail { get; set; }

        [Parameter]
        public bool RequireAcceptance { get; set; }

        protected override void ProcessRecord()
        {
            var item = this.Category.Category;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                item.Name = this.Name;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Type)))
                item.Type = this.Type;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Eula)))
                item.eula = this.Eula;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(CheckInEmail)))
                item.CheckinEmail = this.CheckInEmail;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(RequireAcceptance)))
                item.RequireAcceptance = this.RequireAcceptance;
            //TODO: error handling
            WriteObject(ApiHelper.Instance.CategoryManager.Update(item).Payload);
        }
    }
}