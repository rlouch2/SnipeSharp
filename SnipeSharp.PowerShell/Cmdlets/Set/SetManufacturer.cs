using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets.Set
{
    [Cmdlet(VerbsCommon.Set, nameof(Manufacturer))]
    [OutputType(typeof(Manufacturer))]
    public class SetManufacturer: SetObject<Manufacturer>
    {
        /// <summary>
        /// The new name for the manufacturer.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string NewName { get; set; }

        /// <summary>
        /// The updated url for the manufacturer's website.
        /// </summary>
        [Parameter]
        public Uri Url { get; set; }

        /// <summary>
        /// The updated uri of the image for the manufacturer.
        /// </summary>
        [Parameter]
        public Uri ImageUri { get; set; }

        /// <summary>
        /// The updated url for the manufacturer's support portal.
        /// </summary>
        [Parameter]
        public Uri SupportUrl { get; set; }

        /// <summary>
        /// The updated phone number for the manufacturer's support line.
        /// </summary>
        [Parameter]
        public string SupportPhoneNumber { get; set; }

        /// <summary>
        /// The updated email address to contact the manufacturer by for support.
        /// </summary>
        [Parameter]
        public string SupportEmailAddress { get; set; }

        /// <inheritdoc />
        protected override void PopulateItem(Manufacturer item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = this.NewName;
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
