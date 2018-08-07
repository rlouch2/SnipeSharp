using System;
using System.Management.Automation;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Common;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "License")]
    [OutputType(typeof(License))]
    public class NewLicense: PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public CompanyIdentity Company { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string ExpirationDate { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public long? FreeSeatsCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string LicenseEmail { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string LicenseName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public bool Maintained { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ManufacturerIdentity Manufacturer { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Notes { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string OrderNumber { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string ProductKey { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string PurchaseCost { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string PurchaseDate { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string PurchaseOrder { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public long Seats { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public CompanyIdentity Supplier { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public bool UserCanCheckout { get; set; }
        
        protected override void ProcessRecord()
        {
            var item = new License {
                Name = this.Name,
                Company = this.Company?.Company,
                FreeSeatsCount = this.FreeSeatsCount,
                LicenseEmail = this.LicenseEmail,
                LicenseName = this.LicenseName,
                Maintained = this.Maintained,
                Manufacturer = this.Manufacturer?.Manufacturer,
                Notes = this.Notes,
                OrderNumber = this.OrderNumber,
                ProductKey = this.ProductKey,
                PurchaseCost = this.PurchaseCost,
                PurchaseOrder = this.PurchaseOrder,
                Seats = this.Seats,
                Supplier = this.Supplier?.Company,
                UserCanCheckout = this.UserCanCheckout
            };
            if(ExpirationDate != null)
                item.ExpirationDate = new Date {
                    DateObj = this.ExpirationDate
                };
            if(PurchaseDate != null)
                item.PurchaseDate = new Date {
                    DateObj = this.PurchaseDate
                };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.LicenseManager.Create(item).Payload);
        }
    }
}