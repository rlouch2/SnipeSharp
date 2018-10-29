using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets.Set
{
    [Cmdlet(VerbsCommon.Set, nameof(Location))]
    [OutputType(typeof(Location))]
    public class SetLocation: SetObject<Location>
    {
        [Parameter]
        public string NewName { get; set; }

        [Parameter]
        public Uri ImageUri { get; set; }

        [Parameter]
        public string Address { get; set; }

        [Parameter]
        public string Address2 { get; set; }

        [Parameter]
        public string City { get; set; }

        [Parameter]
        public string State { get; set; }

        [Parameter]
        public string Country { get; set; }

        [Parameter]
        public string ZipCode { get; set; }

        [Parameter]
        public string Currency { get; set; }

        [Parameter]
        public ObjectBinding<Location> ParentLocation { get; set; }

        [Parameter]
        public UserBinding Manager { get; set; }
        
        /// <inheritdoc />
        protected override void PopulateItem(Location item)
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
                item.ParentLocation = this.ParentLocation?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manager)))
                item.Manager = this.Manager?.Object;
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Locations.Update(item));
        }
    }
}
