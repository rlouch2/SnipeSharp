using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "Model")]
    [OutputType(typeof(Model))]
    public class SetModel: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateIdentityNotNull]
        public ModelIdentity Model { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter]
        public ManufacturerIdentity Manufacturer { get; set; }

        [Parameter]
        public CategoryIdentity Category { get; set; }

        [Parameter]
        public string ModelNumber { get; set; }

        [Parameter]
        public DepreciationIdentity Depreciation { get; set; }

        [Parameter]
        public string Eol { get; set; }

        [Parameter]
        public string Notes { get; set; }

        [Parameter]
        public FieldSetIdentity FieldSet { get; set; }
        
        protected override void ProcessRecord()
        {
            var item = this.Model.Model;

            if(MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                item.Name = this.Name;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
                item.Manufacturer = this.Manufacturer?.Manufacturer;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                item.Category = this.Category?.Category;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ModelNumber)))
                item.ModelNumber = this.ModelNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Depreciation)))
                item.Depreciation = this.Depreciation?.Depreciation;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Eol)))
                item.Eol = this.Eol;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Notes)))
                item.Notes = this.Notes;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(FieldSet)))
                item.FieldSet = this.FieldSet?.FieldSet;
            //TODO: error handling
            WriteObject(ApiHelper.Instance.ModelManager.Update(item).Payload);
        }
    }
}