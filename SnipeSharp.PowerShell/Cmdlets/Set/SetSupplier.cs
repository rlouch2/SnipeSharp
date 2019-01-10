using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets.Set
{
    /// <summary>
    /// <para type="synopsis">Changes the properties of an existing Snipe-IT supplier.</para>
    /// <para type="description">The Set-Supplier cmdlet changes the properties of an existing Snipe-IT supplier object.</para>
    /// </summary>
    /// <example>
    ///   <code>Set-Supplier -Name "Potato Warehouse &amp; Wholesale" -PhoneNumber '+1 (555) 555-5555'</code>
    ///   <para>Changes the contact phone number for supplier "Potato Warehouse &amp; Wholesale" to "+1 (555) 555-5555".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Set, nameof(Supplier))]
    [OutputType(typeof(Supplier))]
    public class SetSupplier: SetObject<Supplier>
    {
        /// <summary>
        /// The new name of the supplier.
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string NewName { get; set; }

        /// <summary>
        /// The updated uri of the image for the supplier.
        /// </summary>
        [Parameter]
        public Uri ImageUri { get; set; }

        /// <summary>
        /// The supplier's updated address line.
        /// </summary>
        [Parameter]
        public string Address { get; set; }

        /// <summary>
        /// The supplier's updated second address line.
        /// </summary>
        [Parameter]
        public string Address2 { get; set; }

        /// <summary>
        /// The supplier's updated address city.
        /// </summary>
        [Parameter]
        public string City { get; set; }

        /// <summary>
        /// The supplier's updated address state.
        /// </summary>
        [Parameter]
        public string State { get; set; }

        /// <summary>
        /// The supplier's updated address country.
        /// </summary>
        [Parameter]
        public string Country { get; set; }

        /// <summary>
        /// The supplier's updated address zip code.
        /// </summary>
        [Parameter]
        public string ZipCode { get; set; }

        /// <summary>
        /// The supplier contact's updated fax number.
        /// </summary>
        [Parameter]
        public string FaxNumber { get; set; }

        /// <summary>
        /// The supplier contact's updated phone number.
        /// </summary>
        [Parameter]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The supplier contact's updated email address.
        /// </summary>
        [Parameter]
        public string EmailAddress { get; set; }

        /// <summary>
        /// The updated name of the supplier contact.
        /// </summary>
        [Parameter]
        public string Contact { get; set; }

        /// <summary>
        /// Any notes about the supplier.
        /// </summary>
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
