using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "Model")]
    public class NewModel: PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public ManufacturerIdentity Manufacturer { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public CategoryIdentity Category { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string ModelNumber { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public DepreciationIdentity Depreciation { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Eol { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Notes { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public FieldSetIdentity FieldSet { get; set; }
        
        protected override void ProcessRecord()
        {
            var item = new Model {
                Name = this.Name,
                Manufacturer = this.Manufacturer?.Manufacturer,
                Category = this.Category?.Category,
                ModelNumber = this.ModelNumber,
                Depreciation = this.Depreciation?.Depreciation,
                Eol = this.Eol,
                Notes = this.Notes,
                FieldSet = this.FieldSet?.FieldSet
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.ModelManager.Create(item).Payload);
        }
    }
}