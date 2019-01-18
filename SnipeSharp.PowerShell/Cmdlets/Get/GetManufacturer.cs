using System;
using System.Management.Automation;
using SnipeSharp.Filters;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Gets a Snipe IT manufacturer.</summary>
    /// <remarks>
    ///   <para>The Get-Manufacturer cmdlet gets one or more manufacturer objects by name or by Snipe IT internal id number.</para>
    ///   <para>Whatever identifier is used, both accept pipeline input.</para>
    /// </remarks>
    /// <example>
    ///   <code>Get-Manufacturer 14</code>
    ///   <para>Retrieve an manufacturer by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Manufacturer Manufacturer4368</code>
    ///   <para>Retrieve an manufacturer explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Manufacturer</code>
    ///   <para>Retrieve the first 100 manufacturers by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <seealso cref="FindManufacturer" />
    [Cmdlet(VerbsCommon.Get, nameof(Manufacturer), DefaultParameterSetName = nameof(GetManufacturer.ParameterSets.All))]
    [OutputType(typeof(Manufacturer))]
    public sealed class GetManufacturer: GetObject<Manufacturer, ObjectBinding<Manufacturer>, ManufacturerSearchFilter>
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
