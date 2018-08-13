using System;
using System.Management.Automation;
using SnipeSharp.Common;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "Component")]
    [OutputType(typeof(Component))]
    public class NewComponent: PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public CategoryIdentity Category { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public CompanyIdentity Company { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public LocationIdentity Location { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public long? MinimumAmount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string OrderNumber { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PurchaseCost { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PurchaseDate { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public long? Quantity { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Serial { get; set; }

        protected override void ProcessRecord()
        {
            var item = new Component {
                Name = this.Name,
                Category = this.Category?.Category,
                Company = this.Company?.Company,
                Location = this.Location?.Location,
                MinAmt = this.MinimumAmount,
                OrderNumber = this.OrderNumber,
                PurchaseCost = this.PurchaseCost,
                Quantity = this.Quantity,
                SerialNumber = this.Serial
            };
            if(!(PurchaseDate is null))
            {
                item.PurchaseDate = new ResponseDate {
                    DateTime = this.PurchaseDate
                };
            }
            //TODO: error handling
            WriteObject(ApiHelper.Instance.ComponentManager.Create(item).Payload);
        }
    }
}