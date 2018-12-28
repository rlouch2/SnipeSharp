using System;
using System.Management.Automation;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.Cmdlets.New
{
    /// <summary>
    /// <para type="synopsis">Creates a new Snipe-IT supplier.</para>
    /// <para type="description">The New-Supplier cmdlet creates a new supplier object.</para>
    /// </summary>
    /// <example>
    ///   <code>New-Supplier -Name "Potato Warehouse &amp; Wholesale"</code>
    ///   <para>Create a new supplier named "Potato Warehouse &amp; Wholesale" with all required properties set.</para>
    /// </example>
    [Cmdlet(VerbsCommon.New, nameof(Supplier))]
    [OutputType(typeof(Supplier))]
    public class NewSupplier: PSCmdlet
    {
        /// <summary>
        /// The name of the supplier.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The uri of the image for the supplier.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Uri ImageUri { get; set; }

        /// <summary>
        /// The supplier's address line.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Address { get; set; }

        /// <summary>
        /// The supplier's second address line.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Address2 { get; set; }

        /// <summary>
        /// The supplier's address city.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string City { get; set; }

        /// <summary>
        /// The supplier's address state.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string State { get; set; }

        /// <summary>
        /// The supplier's address country.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Country { get; set; }

        /// <summary>
        /// The supplier's address zip code.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string ZipCode { get; set; }

        /// <summary>
        /// The supplier contact's fax number.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string FaxNumber { get; set; }

        /// <summary>
        /// The supplier contact's phone number.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The supplier contact's email address.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// The name of the supplier contact.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Contact { get; set; }

        /// <summary>
        /// Any notes about the supplier.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Notes { get; set; }
        
        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new Supplier {
                Name = this.Name,
                ImageUri = this.ImageUri,
                Address = this.Address,
                Address2 = this.Address2,
                City = this.City,
                State = this.State,
                Country = this.Country,
                ZipCode = this.ZipCode,
                FaxNumber = this.FaxNumber,
                PhoneNumber = this.PhoneNumber,
                EmailAddress = this.EmailAddress,
                Contact = this.Contact,
                Notes = this.Notes
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Suppliers.Create(item));
        }
    }
}
