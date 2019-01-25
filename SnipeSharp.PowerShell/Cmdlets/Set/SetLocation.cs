using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Changes the properties of an existing Snipe-IT location.</summary>
    /// <remarks>The Set-Location cmdlet changes the properties of an existing Snipe-IT location object.</remarks>
    /// <example>
    ///   <code>Set-Location -Name "Warehouse 19" -Manager "respud"</code>
    ///   <para>Changes the manager of "Warehouse 19" to the user "respud".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Set, nameof(Location))]
    [OutputType(typeof(Location))]
    public class SetLocation: SetObject<Location, ObjectBinding<Location>>
    {
        /// <summary>
        /// The new name of the location.
        /// </summary>
        [Parameter]
        public string NewName { get; set; }

        /// <summary>
        /// The updated uri of the image for the location.
        /// </summary>
        [Parameter]
        public Uri ImageUri { get; set; }

        /// <summary>
        /// The location's updated address line.
        /// </summary>
        [Parameter]
        public string Address { get; set; }

        /// <summary>
        /// The location's updated second address line.
        /// </summary>
        [Parameter]
        public string Address2 { get; set; }

        /// <summary>
        /// The location's udpated address city.
        /// </summary>
        [Parameter]
        public string City { get; set; }

        /// <summary>
        /// The location's updated address state.
        /// </summary>
        [Parameter]
        public string State { get; set; }

        /// <summary>
        /// The location's updated address country.
        /// </summary>
        [Parameter]
        public string Country { get; set; }

        /// <summary>
        /// The location's updated address zip code.
        /// </summary>
        [Parameter]
        public string ZipCode { get; set; }

        /// <summary>
        /// The new currency used at the location.
        /// </summary>
        [Parameter]
        public string Currency { get; set; }

        /// <summary>
        /// The updated parent location.
        /// </summary>
        [Parameter]
        public ObjectBinding<Location> ParentLocation { get; set; }

        /// <summary>
        /// The updated manager of the location.
        /// </summary>
        [Parameter]
        public UserBinding Manager { get; set; }
        
        /// <inheritdoc />
        protected override bool PopulateItem(Location item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Address)))
                item.Address = this.Address;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Address2)))
                item.Address2 = this.Address2;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(City)))
                item.City = this.City;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(State)))
                item.State = this.State;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Country)))
                item.Country = this.Country;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ZipCode)))
                item.ZipCode = this.ZipCode;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Currency)))
                item.Currency = this.Currency;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ParentLocation)))
            {
                if (!GetSingleValue(ParentLocation, out var parentLocation))
                    return false;
                item.ParentLocation = parentLocation;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manager)))
            {
                if (!GetSingleValue(Manager, out var manager))
                    return false;
                item.Manager = manager;
            }
            return true;
        }
    }
}
