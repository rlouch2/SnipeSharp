using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, nameof(License))]
    [OutputType(typeof(License))]
    public class NewLicense: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        public int Seats { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ObjectBinding<Category> Category { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Company> Company { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Depreciation> Depreciation { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Manufacturer> Manufacturer { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string ProductKey { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string OrderNumber { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string PurchaseOrder { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public DateTime PurchaseDate { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public decimal PurchaseCost { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Notes { get; set; }

        /*[Parameter(ValueFromPipelineByPropertyName = true)]
        public DateTime ExpirationDate { get; set; }*/

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string LicensedToName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string LicensedToEmailAddress { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public bool IsMaintained { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public bool IsReassignable { get; set; }
        
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Supplier> Supplier { get; set; }
        
        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new License {
                Name = this.Name,
                Company = this.Company?.Object,
                Depreciation = this.Depreciation?.Object,
                Manufacturer = this.Manufacturer?.Object,
                ProductKey = this.ProductKey,
                OrderNumber = this.OrderNumber,
                PurchaseOrder = this.PurchaseOrder,
                Notes = this.Notes,
                TotalSeats = this.Seats,
                LicensedToEmailAddress = this.LicensedToEmailAddress,
                LicensedToName = this.LicensedToName,
                Supplier = this.Supplier?.Object
            };
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseDate)))
                item.PurchaseDate = this.PurchaseDate;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseCost)))
                item.PurchaseCost = this.PurchaseCost;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(IsMaintained)))
                item.IsMaintained = this.IsMaintained;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(IsReassignable)))
                item.IsReassignable = this.IsReassignable;
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Licenses.Create(item));
        }
    }
}
