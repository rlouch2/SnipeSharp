using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Changes the properties of an existing Snipe-IT model.</summary>
    /// <remarks>The Set-Model cmdlet changes the properties of an existing Snipe-IT model object.</remarks>
    /// <example>
    ///   <code>Set-Model -Name "PotatoPeeler Plus 3000" -EndOfLife 36</code>
    ///   <para>Acknowledges that even the mighty "PotatoPeeler Plus 3000" will only last about 3 years before it's time for a new one.</para>
    /// </example>
    [Cmdlet(VerbsCommon.Set, nameof(Model))]
    [OutputType(typeof(Model))]
    public class SetModel: SetObject<Model, ObjectBinding<Model>>
    {
        /// <summary>
        /// The new name of the model.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string NewName { get; set; }

        /// <summary>
        /// The updated maker of this model.
        /// </summary>
        [Parameter]
        public ObjectBinding<Manufacturer> Manufacturer { get; set; }

        /// <summary>
        /// The updated uri of the image for the model.
        /// </summary>
        [Parameter]
        public Uri ImageUri { get; set; }

        /// <summary>
        /// The updated model number for the model.
        /// </summary>
        [Parameter]
        public string ModelNumber { get; set; }

        /// <summary>
        /// The new depreciation to use for the model.
        /// </summary>
        [Parameter]
        public ObjectBinding<Depreciation> Depreciation { get; set; }

        /// <summary>
        /// The updated category of the model.
        /// </summary>
        [Parameter]
        public ObjectBinding<Category> Category { get; set; }

        /// <summary>
        /// The new custom field set that applies to the model.
        /// </summary>
        [Parameter]
        public ObjectBinding<FieldSet> FieldSet { get; set; }

        /// <summary>
        /// The updated lifetime of the model in months.
        /// </summary>
        [Parameter]
        public int EndOfLife { get; set; }

        /// <summary>
        /// Any notes about the model.
        /// </summary>
        [Parameter]
        public string Notes { get; set; }

        /// <inheritdoc />
        protected override bool PopulateItem(Model item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
            {
                if(!GetSingleValue(Manufacturer, out var manufacturer))
                    return false;
                item.Manufacturer = manufacturer;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ImageUri)))
                item.ImageUri = this.ImageUri;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ModelNumber)))
                item.ModelNumber = this.ModelNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Depreciation)))
            {
                if(!GetSingleValue(Depreciation, out var depreciation))
                    return false;
                item.Depreciation = depreciation;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
            {
                if(!GetSingleValue(Category, out var category))
                    return false;
                item.Category = category;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(FieldSet)))
            {
                if(!GetSingleValue(FieldSet, out var fieldset))
                    return false;
                item.FieldSet = fieldset;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(EndOfLife)))
                item.EndOfLife = this.EndOfLife;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Notes)))
                item.Notes = this.Notes;
            return true;
        }
    }
}
