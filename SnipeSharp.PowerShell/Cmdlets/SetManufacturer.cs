using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, "Manufacturer")]
    [OutputType(typeof(Manufacturer))]
    public class SetManufacturer: PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateIdentityNotNull]
        public ManufacturerIdentity Manufacturer { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public string Url { get; set; }

        [Parameter]
        public string SupportUrl { get; set; }

        [Parameter]
        public string SupportPhone { get; set; }

        [Parameter]
        public string SupportEmail { get; set; }
        
        protected override void ProcessRecord()
        {
            var item = this.Manufacturer.Manufacturer;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                item.Name = this.Name;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Url)))
                item.Url = this.Url;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SupportUrl)))
                item.SupportUrl = this.SupportUrl;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SupportPhone)))
                item.SupportPhone = this.SupportPhone;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SupportEmail)))
                item.SupportEmail = this.SupportEmail;
            //TODO: error handling
            WriteObject(ApiHelper.Instance.ManufacturerManager.Update(item).Payload);
        }
    }
}