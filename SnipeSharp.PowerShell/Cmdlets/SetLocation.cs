using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.Attributes;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "Location")]
    [OutputType(typeof(Location))]
    public class SetLocation: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateIdentityNotNull]
        public LocationIdentity Location { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public string Address { get; set; }

        [Parameter]
        public string City { get; set; }

        [Parameter]
        public string State { get; set; }

        [Parameter]
        public string Country { get; set; }

        [Parameter]
        public string Zip { get; set; }

        [Parameter]
        public LocationIdentity Parent { get; set; }

        [Parameter]
        public UserIdentity Manager { get; set; }
        
        protected override void ProcessRecord()
        {
            var item = this.Location.Location;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                item.Name = this.Name;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Address)))
                item.Address = this.Address;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(City)))
                item.City = this.City;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(State)))
                item.State = this.State;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Country)))
                item.Country = this.Country;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Zip)))
                item.Zip = this.Zip;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Parent)))
                item.Parent = this.Parent?.Location;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manager)))
                item.Manager = this.Manager?.User;
            //TODO: error handling
            WriteObject(ApiHelper.Instance.LocationManager.Update(item).Payload);
        }
    }
}