using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets.Find
{
    /// <summary>
    /// <para type="synopsis">Finds a Snipe IT accessory.</para>
    /// <para type="description">The Find-Accessory cmdlet finds accessory objects by filter, company, category, manufacturer, or supplier.</para>
    /// </summary>
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
        /// <summary>
        /// <para type="description">Filter by owning company.</para>
        /// </summary>
        [Parameter]
        public ObjectBinding<Company> Company { get; set; }
        
        /// <summary>
        /// <para type="description">Filter by accessory category.</para>
        /// </summary>
        [Parameter]
        public ObjectBinding<Category> Category { get; set; }

        /// <summary>
        /// <para type="description">Filter by manufactuerer.</para>
        /// </summary>
        [Parameter]
        public ObjectBinding<Manufacturer> Manufacturer { get; set; }

        /// <summary>
        /// <para type="description">Filter by supplier.</para>
        /// </summary>
        [Parameter]
        public ObjectBinding<Supplier> Supplier { get; set; }


        /// <inheritdoc />
        protected override void PopulateFilter(AccessorySearchFilter filter)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
                filter.Company = Company?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
                filter.Category = Category?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
                filter.Manufacturer = Manufacturer?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Supplier)))
                filter.Supplier = Supplier?.Object;
        }
    }
}
