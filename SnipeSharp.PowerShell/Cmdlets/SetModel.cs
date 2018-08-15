using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, nameof(Model))]
    [OutputType(typeof(Model))]
    public class SetModel: SetObject<Model>
    {
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string NewName { get; set; }

        [Parameter]
        public ObjectBinding<Manufacturer> Manufacturer { get; set; }

        [Parameter]
        public Uri ImageUri { get; set; }

        [Parameter]
        public string ModelNumber { get; set; }

        [Parameter]
        public ObjectBinding<Depreciation> Depreciation { get; set; }

        [Parameter]
        public ObjectBinding<Category> Category { get; set; }

        [Parameter]
        public ObjectBinding<FieldSet> FieldSet { get; set; }
        
        [Parameter]
        public int EndOfLife { get; set; }

        [Parameter]
        public string Notes { get; set; }

        /// <inheritdoc />
        protected override void PopulateItem(Model item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
                item.Manufacturer = this.Manufacturer?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ImageUri)))
                item.ImageUri = this.ImageUri;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ModelNumber)))
                item.ModelNumber = this.ModelNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Depreciation)))
                item.Depreciation = this.Depreciation?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                item.Category = this.Category?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(FieldSet)))
                item.FieldSet = this.FieldSet?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(EndOfLife)))
                item.EndOfLife = this.EndOfLife;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Notes)))
                item.Notes = this.Notes;
        }
    }
}
