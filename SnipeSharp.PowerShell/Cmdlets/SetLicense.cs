using System;
using System.Management.Automation;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Common;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "License")]
    [OutputType(typeof(License))]
    public class SetLicense: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateIdentityNotNull]
        public LicenseIdentity License { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public CompanyIdentity Company { get; set; }

        [Parameter]
        public string ExpirationDate { get; set; }

        [Parameter]
        public long FreeSeatsCount { get; set; }

        [Parameter]
        public string LicenseEmail { get; set; }

        [Parameter]
        public string LicenseName { get; set; }

        [Parameter]
        public bool Maintained { get; set; }

        [Parameter]
        public ManufacturerIdentity Manufacturer { get; set; }

        [Parameter]
        public string Notes { get; set; }

        [Parameter]
        public string OrderNumber { get; set; }

        [Parameter]
        public string ProductKey { get; set; }

        [Parameter]
        public string PurchaseCost { get; set; }

        [Parameter]
        public string PurchaseDate { get; set; }

        [Parameter]
        public string PurchaseOrder { get; set; }

        [Parameter]
        public long Seats { get; set; }

        [Parameter]
        public CompanyIdentity Supplier { get; set; }

        [Parameter]
        public bool UserCanCheckout { get; set; }
        
        protected override void ProcessRecord()
        {
            var item = this.License.License;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                item.Name = this.Name;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
                item.Company = this.Company;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(FreeSeatsCount)))
                item.FreeSeatsCount = this.FreeSeatsCount;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(LicenseEmail)))
                item.LicenseEmail = this.LicenseEmail;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(LicenseName)))
                item.LicenseName = this.LicenseName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Maintained)))
                item.Maintained = this.Maintained;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
                item.Manufacturer = this.Manufacturer;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Notes)))
                item.Notes = this.Notes;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(OrderNumber)))
                item.OrderNumber = this.OrderNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ProductKey)))
                item.ProductKey = this.ProductKey;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseCost)))
                item.PurchaseCost = this.PurchaseCost;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseOrder)))
                item.PurchaseOrder = this.PurchaseOrder;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Seats)))
                item.Seats = this.Seats;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Supplier)))
                item.Supplier = this.Supplier;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(UserCanCheckout)))
                item.UserCanCheckout = this.UserCanCheckout;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ExpirationDate)))
                item.ExpirationDate = new Date {
                    DateObj = this.ExpirationDate
                };
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseDate)))
                item.PurchaseDate = new Date {
                    DateObj = this.PurchaseDate
                };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.LicenseManager.Update(item).Payload);
        }
    }
}