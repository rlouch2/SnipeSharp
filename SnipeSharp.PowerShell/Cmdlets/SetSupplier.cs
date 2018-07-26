using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "Supplier")]
    [OutputType(typeof(Supplier))]
    public class SetSupplier: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateIdentityNotNull]
        public SupplierIdentity Supplier { get; set; }

        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
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
        public string Fax { get; set; }

        [Parameter]
        public string Phone { get; set; }

        [Parameter]
        public string Email { get; set; }

        [Parameter]
        public string Contact { get; set; }

        [Parameter]
        public string Notes { get; set; }
        
        protected override void ProcessRecord()
        {
            var item = this.Supplier.Supplier
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
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Fax)))
                item.Fax = this.Fax;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Phone)))
                item.Phone = this.Phone;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Email)))
                item.Email = this.Email;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Contact)))
                item.Contact = this.Contact;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Notes)))
                item.Notes = this.Notes;
            //TODO: error handling
            WriteObject(ApiHelper.Instance.SupplierManager.Update(item).Payload);
        }
    }
}