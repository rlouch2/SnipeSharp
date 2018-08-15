using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets.Set
{
    [Cmdlet(VerbsCommon.Set, nameof(License))]
    [OutputType(typeof(License))]
    public class SetLicense: SetObject<License>
    {
        [Parameter]
        public string NewName { get; set; }

        [Parameter]
        public ObjectBinding<Company> Company { get; set; }

        [Parameter]
        public ObjectBinding<Depreciation> Depreciation { get; set; }

        [Parameter]
        public ObjectBinding<Manufacturer> Manufacturer { get; set; }

        [Parameter]
        public string ProductKey { get; set; }

        [Parameter]
        public string OrderNumber { get; set; }

        [Parameter]
        public string PurchaseOrder { get; set; }

        [Parameter]
        public DateTime PurchaseDate { get; set; }

        [Parameter]
        public decimal PurchaseCost { get; set; }

        [Parameter]
        public string Notes { get; set; }

        /*[Parameter]
        public DateTime ExpirationDate { get; set; }*/

        [Parameter]
        public int Seats { get; set; }

        [Parameter]
        public string LicensedToName { get; set; }

        [Parameter]
        public string LicensedToEmailAddress { get; set; }

        [Parameter]
        public bool IsMaintained { get; set; }

        [Parameter]
        [ValidateIdentityNotNull]
        public ObjectBinding<Category> Category { get; set; }

        [Parameter]
        public bool IsReassignable { get; set; }
        
        [Parameter]
        public ObjectBinding<Supplier> Supplier { get; set; }

        /// <inheritdoc />
        protected override void PopulateItem(License item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
                item.Company = this.Company?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Depreciation)))
                item.Depreciation = this.Depreciation?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
                item.Manufacturer = this.Manufacturer?.Object;
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
                item.Supplier = this.Supplier?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(IsReassignable)))
                item.IsReassignable = this.IsReassignable;
        }
    }
}
