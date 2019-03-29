using System;
using System.Management.Automation;
using SnipeSharp.EndPoint;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Creates a new Snipe-IT component.</summary>
    /// <remarks>The New-Component cmdlet creates a new component object.</remarks>
    /// <example>
    ///   <code>New-Component -Name "Potato Peeler Blade" -Quantity 215 -Company "Potato Inc." -Category "Potato"</code>
    ///   <para>Create a new component named "Potato Peeler Blade" with all required properties set.</para>
    /// </example>
    [Cmdlet(VerbsCommon.New, nameof(Component))]
    [OutputType(typeof(Component))]
    public class NewComponent: BaseCmdlet
    {
        /// <summary>
        /// The name of the component.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// How many of the component there are.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateRange(1, int.MaxValue)]
        public int Quantity { get; set; }

        /// <summary>
        /// The category of the component.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ObjectBinding<Category> Category { get; set; }

        /// <summary>
        /// The company that owns the component.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Company> Company { get; set; }

        /// <summary>
        /// The location of the component.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Location> Location { get; set; }

        /// <summary>
        /// When to start warning that the component is running low.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public int MinimumQuantity { get; set; }

        /// <summary>
        /// The order the component was purchased in.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// The cost the component was purchased for.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public decimal PurchaseCost { get; set; }

        /// <summary>
        /// The date the component was purchased.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// The serial number(s) of the component(s).
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Serial { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new Component {
                Name = this.Name,
                Quantity = this.Quantity,
                OrderNumber = this.OrderNumber,
                Serial = this.Serial
            };
            if(MyInvocation.BoundParameters.ContainsKey(nameof(MinimumQuantity)))
                item.MinimumQuantity = this.MinimumQuantity;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseCost)))
                item.PurchaseCost = this.PurchaseCost;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseDate)))
                item.PurchaseDate = this.PurchaseDate;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
            {
                if(!GetSingleValue(Category, out var category, required: true))
                    return;
                item.Category = category;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
            {
                if(!GetSingleValue(Company, out var company, required: true))
                    return;
                item.Company = company;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
            {
                if(!GetSingleValue(Location, out var location))
                    return;
                item.Location = location;
            }
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Components.Create(item));
        }
    }
}
