using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, nameof(Supplier))]
    [OutputType(typeof(Supplier))]
    public class SetSupplier: SetObject<Supplier>
    {
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
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
        public string FaxNumber { get; set; }

        [Parameter]
        public string PhoneNumber { get; set; }

        [Parameter]
        public string EmailAddress { get; set; }

        [Parameter]
        public string Contact { get; set; }

        [Parameter]
        public string Notes { get; set; }
        
        /// <inheritdoc />
        protected override void PopulateItem(Supplier item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ImageUri)))
                item.ImageUri = this.ImageUri;
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
            if(MyInvocation.BoundParameters.ContainsKey(nameof(FaxNumber)))
                item.FaxNumber = this.FaxNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PhoneNumber)))
                item.PhoneNumber = this.PhoneNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(EmailAddress)))
                item.EmailAddress = this.EmailAddress;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Contact)))
                item.Contact = this.Contact;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Notes)))
                item.Notes = this.Notes;
        }
    }
}
