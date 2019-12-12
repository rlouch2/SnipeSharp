using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Creates a new Snipe-IT model.</summary>
    /// <remarks>The New-Model cmdlet creates a new model object.</remarks>
    /// <example>
    ///   <code>New-Model -Name "PotatoPeeler Plus 3000" -Manufacturer "Potato Peelers Inc." -Category "Handheld"</code>
    ///   <para>Create a new model named "PotatoPeeler Plus 3000" with all required properties set.</para>
    /// </example>
    [Cmdlet(VerbsCommon.New, "Model")]
    [OutputType(typeof(Model))]
    public class NewModel: PSCmdlet
    {
        /// <summary>
        /// The name of the model.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The maker of this model.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ObjectBinding<Manufacturer> Manufacturer { get; set; }

        /// <summary>
        /// The uri of the image for the model.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Uri ImageUri { get; set; }

        /// <summary>
        /// The model's model number.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string ModelNumber { get; set; }

        /// <summary>
        /// The depreciation to use for this model.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Depreciation> Depreciation { get; set; }

        /// <summary>
        /// The category of this model.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Category> Category { get; set; }

        /// <summary>
        /// The custom field set that applies to this model.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<FieldSet> FieldSet { get; set; }

        /// <summary>
        /// The lifetime of the model in months.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public int EndOfLife { get; set; }

        /// <summary>
        /// Any notes about the model.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Notes { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new Model {
                Name = this.Name,
                ImageUri = this.ImageUri,
                ModelNumber = this.ModelNumber,
                Notes = this.Notes
            };
            if(MyInvocation.BoundParameters.ContainsKey(nameof(EndOfLife)))
                item.EndOfLife = this.EndOfLife;
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
            {
                if (!this.GetSingleValue(Manufacturer, out var manufacturer, required: true))
                    return;
                item.Manufacturer = manufacturer;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Depreciation)))
            {
                if (!this.GetSingleValue(Depreciation, out var depreciation))
                    return;
                item.Depreciation = depreciation;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
            {
                if (!this.GetSingleValue(Category, out var category, required: true))
                    return;
                item.Category = category;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(FieldSet)))
            {
                if (!this.GetSingleValue(FieldSet, out var fieldSet))
                    return;
                item.FieldSet = fieldSet;
            }
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Models.Create(item));
        }
    }
}
