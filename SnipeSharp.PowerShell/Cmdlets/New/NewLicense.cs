using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Creates a new Snipe-IT license.</summary>
    /// <remarks>The New-License cmdlet creates a new license object.</remarks>
    /// <example>
    ///   <code>New-License -Name "State Potato Peeling License" -Seats 12000 -Category "Gov't Required"</code>
    ///   <para>Create a new license named "State Potato Peeling License" with all required properties set.</para>
    /// </example>
    [Cmdlet(VerbsCommon.New, nameof(License))]
    [OutputType(typeof(License))]
    public class NewLicense: PSCmdlet
    {
        /// <summary>
        /// The name of the license.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The total seats available on the license.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        public int Seats { get; set; }

        /// <summary>
        /// The category of the license.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ObjectBinding<Category> Category { get; set; }

        /// <summary>
        /// The company that owns the license.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Company> Company { get; set; }

        /// <summary>
        /// The depreciation to use for the license.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Depreciation> Depreciation { get; set; }

        /// <summary>
        /// The manufacturer of the product the license is for.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Manufacturer> Manufacturer { get; set; }

        /// <summary>
        /// The license product key.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string ProductKey { get; set; }

        /// <summary>
        /// The order the license was purchased in, supplied by the supplier.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// The order the license was purchased in, supplied by the purchaser.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string PurchaseOrder { get; set; }

        /// <summary>
        /// The date the license was purchased.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// The cost the license was purchased for.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public decimal PurchaseCost { get; set; }

        /// <summary>
        /// Any notes about the license.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Notes { get; set; }

        /*[Parameter(ValueFromPipelineByPropertyName = true)]
        public DateTime ExpirationDate { get; set; }*/

        /// <summary>
        /// The registered name of the licensee.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string LicensedToName { get; set; }

        /// <summary>
        /// The registered email address of the licensee.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string LicensedToEmailAddress { get; set; }

        /// <summary>
        /// Is the license maintained?
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public bool IsMaintained { get; set; }

        /// <summary>
        /// Are the seats on this license reassignable?
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public bool IsReassignable { get; set; }

        /// <summary>
        /// The supplier who sold the license.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Supplier> Supplier { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new License {
                Name = this.Name,
                ProductKey = this.ProductKey,
                OrderNumber = this.OrderNumber,
                PurchaseOrder = this.PurchaseOrder,
                Notes = this.Notes,
                TotalSeats = this.Seats,
                LicensedToEmailAddress = this.LicensedToEmailAddress,
                LicensedToName = this.LicensedToName
            };
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseDate)))
                item.PurchaseDate = this.PurchaseDate;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseCost)))
                item.PurchaseCost = this.PurchaseCost;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(IsMaintained)))
                item.IsMaintained = this.IsMaintained;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(IsReassignable)))
                item.IsReassignable = this.IsReassignable;
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
            {
                if (!this.GetSingleValue(Category, out var category, required: true))
                    return;
                item.Category = category;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
            {
                if (!this.GetSingleValue(Company, out var company))
                    return;
                item.Company = company;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Depreciation)))
            {
                if (!this.GetSingleValue(Depreciation, out var depreciation))
                    return;
                item.Depreciation = depreciation;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
            {
                if (!this.GetSingleValue(Manufacturer, out var manufacturer))
                    return;
                item.Manufacturer = manufacturer;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Supplier)))
            {
                if (!this.GetSingleValue(Supplier, out var supplier))
                    return;
                item.Supplier = supplier;
            }
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Licenses.Create(item));
        }
    }
}
