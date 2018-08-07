using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "FieldSet")]
    [OutputType(typeof(FieldSet))]
    public class SetFieldSet: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateIdentityNotNull]
        public FieldSetIdentity FieldSet { get; set; }

        [Parameter]
        public string Name { get; set; }
        
        protected override void ProcessRecord()
        {
            var item = this.FieldSet.FieldSet;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                item.Name = Name;
            //TODO: error handling
            WriteObject(ApiHelper.Instance.FieldSetManager.Update(item).Payload);
        }
    }
}