using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Finds a Snipe IT accessory.</summary>
    /// <remarks>The Find-Accessory cmdlet finds accessory objects by filter, company, category, manufacturer, or supplier.</remarks>
    /// <example>
    ///   <code>Find-Accessory</code>
    ///   <para>Finds all accessories.</para>
    /// </example>
    /// <example>
    ///   <code>Find-Accessory "PotatoPeeler"</code>
    ///   <para>Finds accessories that match the search string "PotatoPeeler".</para>
    /// </example>
    /// <example>
    ///   <code>Find-Accessory -Company $x</code>
    ///   <para>Finds accessories owned by the company stored in $x.</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(Accessory),
        SupportsPaging = true
    )]
    [OutputType(typeof(Accessory))]
    public sealed class FindAccessory: FindObject<Accessory, AccessorySearchColumn, AccessorySearchFilter>
    {
        /// <summary>Filter by owning company.</summary>
        [Parameter]
        public ObjectBinding<Company> Company { get; set; }
        
        /// <summary>Filter by accessory category.</summary>
        [Parameter]
        public ObjectBinding<Category> Category { get; set; }

        /// <summary>Filter by manufactuerer.</summary>
        [Parameter]
        public ObjectBinding<Manufacturer> Manufacturer { get; set; }

        /// <summary>Filter by supplier.</summary>
        [Parameter]
        public ObjectBinding<Supplier> Supplier { get; set; }


        /// <inheritdoc />
        protected override void PopulateFilter(AccessorySearchFilter filter)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
                filter.Company = Company?.Value[0];
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                filter.Category = Category?.Value[0];
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
                filter.Manufacturer = Manufacturer?.Value[0];
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Supplier)))
                filter.Supplier = Supplier?.Value[0];
        }
    }
}
