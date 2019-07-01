using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Changes the properties of an existing Snipe-IT manufacturer.</summary>
    /// <remarks>The Set-Manufacturer cmdlet changes the properties of an existing Snipe-IT manufacturer object.</remarks>
    /// <example>
    ///   <code>Set-Manufacturer -Name "Potato Peelers Inc." -SupportPhoneNumber '+1 (555) 555-5555'</code>
    ///   <para>Changes the support phone number for manufacturer "Potato Peelers Inc." to "+1 (555) 555-5555".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Set, nameof(Manufacturer))]
    [OutputType(typeof(Manufacturer))]
    public class SetManufacturer: SetObject<Manufacturer, ObjectBinding<Manufacturer>>
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
        protected override bool PopulateItem(Manufacturer item)
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
            return true;
        }
    }
}
