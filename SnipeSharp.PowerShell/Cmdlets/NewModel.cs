using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "Model")]
    [OutputType(typeof(Model))]
    public class NewModel: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ObjectBinding<Manufacturer> Manufacturer { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Uri ImageUri { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string ModelNumber { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Depreciation> Depreciation { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Category> Category { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<FieldSet> FieldSet { get; set; }
        
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public int EndOfLife { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Notes { get; set; }
        
        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new Model {
                Name = this.Name,
                Manufacturer = this.Manufacturer?.Object,
                ImageUri = this.ImageUri,
                ModelNumber = this.ModelNumber,
                Depreciation = this.Depreciation?.Object,
                Category = this.Category?.Object,
                FieldSet = this.FieldSet?.Object,
                Notes = this.Notes
            };
            if(MyInvocation.BoundParameters.ContainsKey(nameof(EndOfLife)))
                item.EndOfLife = this.EndOfLife;
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Models.Create(item));
        }
    }
}
