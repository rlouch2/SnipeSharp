using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Changes the properties of an existing Snipe-IT license.</summary>
    /// <remarks>The Set-License cmdlet changes the properties of an existing Snipe-IT license object.</remarks>
    /// <example>
    ///   <code>Set-License -Name "State Potato Peeling License" -IsReassignable $false</code>
    ///   <para>Pulls into question if it really makes sense to not require every employee have their own potato peeling license, if only because they can no longer be reassigned.</para>
    /// </example>
    [Cmdlet(VerbsCommon.Set, nameof(License))]
    [OutputType(typeof(License))]
    public class SetLicense: SetObject<License, ObjectBinding<License>>
    {
        /// <summary>
        /// The new name of the license.
        /// </summary>
        [Parameter]
        public string NewName { get; set; }

        /// <summary>
        /// The update company that owns the license.
        /// </summary>
        [Parameter]
        public ObjectBinding<Company> Company { get; set; }

        /// <summary>
        /// The new depreciation to use for the license.
        /// </summary>
        [Parameter]
        public ObjectBinding<Depreciation> Depreciation { get; set; }

        /// <summary>
        /// The updated manufacturer of the product the license is for.
        /// </summary>
        [Parameter]
        public ObjectBinding<Manufacturer> Manufacturer { get; set; }

        /// <summary>
        /// The updated license product key.
        /// </summary>
        [Parameter]
        public string ProductKey { get; set; }

        /// <summary>
        /// The updated order the license was purchased in, supplied by the supplier.
        /// </summary>
        [Parameter]
        public string OrderNumber { get; set; }

        /// <summary>
        /// The updated order the license was purchased in, supplied by the purchaser.
        /// </summary>
        [Parameter]
        public string PurchaseOrder { get; set; }

        /// <summary>
        /// The updated purchase date of the license.
        /// </summary>
        [Parameter]
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// The updated purchase cost of the license.
        /// </summary>
        [Parameter]
        public decimal PurchaseCost { get; set; }

        /// <summary>
        /// Any notes for the license.
        /// </summary>
        [Parameter]
        public string Notes { get; set; }

        /*[Parameter]
        public DateTime ExpirationDate { get; set; }*/

        /// <summary>
        /// The updated seat coutn for the license.
        /// </summary>
        [Parameter]
        public int Seats { get; set; }

        /// <summary>
        /// The updated licensee name.
        /// </summary>
        [Parameter]
        public string LicensedToName { get; set; }

        /// <summary>
        /// The updated licensee email address.
        /// </summary>
        [Parameter]
        public string LicensedToEmailAddress { get; set; }

        /// <summary>
        /// Is the license maintained?
        /// </summary>
        [Parameter]
        public bool IsMaintained { get; set; }

        /// <summary>
        /// The updated category of the license.
        /// </summary>
        [Parameter]
        [ValidateIdentityNotNull]
        public ObjectBinding<Category> Category { get; set; }

        /// <summary>
        /// Are seats on this license reassignable?
        /// </summary>
        [Parameter]
        public bool IsReassignable { get; set; }

        /// <summary>
        /// The updated supplier that sold the license.
        /// </summary>
        [Parameter]
        public ObjectBinding<Supplier> Supplier { get; set; }

        /// <inheritdoc />
        protected override bool PopulateItem(License item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
            {
                if (!this.GetSingleValue(Company, out var company))
                    return false;
                item.Company = company;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Depreciation)))
            {
                if (!this.GetSingleValue(Depreciation, out var depreciation))
                    return false;
                item.Depreciation = depreciation;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
            {
                if (!this.GetSingleValue(Manufacturer, out var manufacturer))
                    return false;
                item.Manufacturer = manufacturer;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ProductKey)))
                item.ProductKey = this.ProductKey;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(OrderNumber)))
                item.OrderNumber = this.OrderNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseOrder)))
                item.PurchaseOrder = this.PurchaseOrder;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseDate)))
                item.PurchaseDate = this.PurchaseDate;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseCost)))
                item.PurchaseCost = this.PurchaseCost;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Notes)))
                item.Notes = this.Notes;
            /*if(MyInvocation.BoundParameters.ContainsKey(nameof(ExpirationDate)))
                item.ExpirationDate = this.ExpirationDate;*/
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Seats)))
                item.TotalSeats = this.Seats;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(LicensedToName)))
                item.LicensedToName = this.LicensedToName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(LicensedToEmailAddress)))
                item.LicensedToEmailAddress = this.LicensedToEmailAddress;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(IsMaintained)))
                item.IsMaintained = this.IsMaintained;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Supplier)))
            {
                if (!this.GetSingleValue(Supplier, out var supplier))
                    return false;
                item.Supplier = supplier;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(IsReassignable)))
                item.IsReassignable = this.IsReassignable;
            return true;
        }
    }
}
