using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.EndPoint.Filters;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Find, nameof(Accessory),
        SupportsPaging = true
    )]
    [OutputType(typeof(Accessory))]
    public class FindAccessory: FindObject<Accessory, AccessorySearchColumn, AccessorySearchFilter>
    {
        /// <summary>
        /// <para type="description">Filter by owning company.</para>
        /// </summary>
        public ObjectBinding<Company> Company { get; set; }
        
        /// <summary>
        /// <para type="description">Filter by accessory category.</para>
        /// </summary>
        public ObjectBinding<Category> Category { get; set; }

        /// <summary>
        /// <para type="description">Filter by manufactuerer.</para>
        /// </summary>
        public ObjectBinding<Manufacturer> Manufacturer { get; set; }

        /// <summary>
        /// <para type="description">Filter by supplier.</para>
        /// </summary>
        public ObjectBinding<Supplier> Supplier { get; set; }


        /// <inheritdoc />
        protected override void PopulateFilter(ref AccessorySearchFilter filter)
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
