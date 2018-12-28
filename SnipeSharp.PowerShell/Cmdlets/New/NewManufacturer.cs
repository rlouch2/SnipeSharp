using System;
using System.Management.Automation;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.Cmdlets.New
{
    /// <summary>
    /// <para type="synopsis">Creates a new Snipe-IT manufacturer.</para>
    /// <para type="description">The New-Manufacturer cmdlet creates a new manufacturer object.</para>
    /// </summary>
    /// <example>
    ///   <code>New-Manufacturer -Name "Potato Peelers Inc."</code>
    ///   <para>Create a new manufacturer named "Potato Peelers Inc." with all required properties set.</para>
    /// </example>
    [Cmdlet(VerbsCommon.New, nameof(Manufacturer))]
    [OutputType(typeof(Manufacturer))]
    public class NewManufacturer: PSCmdlet
    {
        /// <summary>
        /// The name of the manufacturer.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The url of the manufacturer's website.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Uri Url { get; set; }

        /// <summary>
        /// The uri of the image for the manufacturer.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Uri ImageUri { get; set; }

        /// <summary>
        /// The url for the manufacturer's support portal.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Uri SupportUrl { get; set; }

        /// <summary>
        /// The phone number for the manufacturer's support line.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string SupportPhoneNumber { get; set; }

        /// <summary>
        /// The email address to contact the manufacturer by for support.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string SupportEmailAddress { get; set; }
        
        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new Manufacturer {
                Name = this.Name,
                Url = this.Url,
                SupportUrl = this.SupportUrl,
                SupportPhoneNumber = this.SupportPhoneNumber,
                SupportEmailAddress = this.SupportEmailAddress
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Manufacturers.Create(item));
        }
    }
}
