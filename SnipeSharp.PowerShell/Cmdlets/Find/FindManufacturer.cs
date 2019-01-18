using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Filters;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Finds a Snipe IT manufacturer.</summary>
    /// <remarks>The Find-Asset cmdlet finds manufacturer objects by filter.</remarks>
    /// <example>
    ///   <code>Find-Manufacturer</code>
    ///   <para>Finds all manufacturers.</para>
    /// </example>
    /// <example>
    ///   <code>Find-Manufacturer "Potato Peelers United"</code>
    ///   <para>Finds manufacturers that match the search string "Potato Peelers United".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(Manufacturer), SupportsPaging = true)]
    [OutputType(typeof(Manufacturer))]
    public class FindManufacturer: FindObject<Manufacturer, ManufacturerSearchColumn, ManufacturerSearchFilter>
    {
        /// <summary>Find deleted manufacturers, or non-deleted manufacturers?</summary>
        [Parameter]
        public bool Deleted { get; set; }

        /// <inheritdoc />
        protected override void PopulateFilter(ManufacturerSearchFilter filter)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Deleted)))
                filter.Deleted = Deleted;
        }
    }
}
