using System;
using System.Management.Automation;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;
using SnipeSharp.PowerShell.Cmdlets.AbstractCmdlets;

namespace SnipeSharp.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, nameof(Manufacturer))]
    [OutputType(typeof(Manufacturer))]
    public class SetManufacturer: SetObject<Manufacturer>
    {
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter]
        public Uri Url { get; set; }

        [Parameter]
        public Uri ImageUri { get; set; }

        [Parameter]
        public Uri SupportUrl { get; set; }

        [Parameter]
        public string SupportPhoneNumber { get; set; }

        [Parameter]
        public string SupportEmailAddress { get; set; }
        
        protected override void PopulateItem(Manufacturer item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Name)))
                item.Name = this.Name;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Url)))
                item.Url = this.Url;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ImageUri)))
                item.ImageUri = this.ImageUri;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SupportUrl)))
                item.SupportUrl = this.SupportUrl;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SupportPhoneNumber)))
                item.SupportPhoneNumber = this.SupportPhoneNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SupportEmailAddress)))
                item.SupportEmailAddress = this.SupportEmailAddress;
        }
    }
}
