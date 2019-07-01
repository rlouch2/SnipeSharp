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
        protected override bool PopulateFilter(AccessorySearchFilter filter)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
            {
                if (!GetSingleValue(Company, out var company))
                    return false;
                filter.Company = company;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
            {
                if (!GetSingleValue(Category, out var category))
                    return false;
                filter.Category = category;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
            {
                if (!GetSingleValue(Manufacturer, out var manufacturer))
                    return false;
                filter.Manufacturer = manufacturer;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Supplier)))
            {
                if (!GetSingleValue(Supplier, out var supplier))
                    return false;
                filter.Supplier = supplier;
            }
            return true;
        }
    }
}
