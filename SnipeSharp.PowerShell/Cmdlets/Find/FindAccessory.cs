using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets.Find
{
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
