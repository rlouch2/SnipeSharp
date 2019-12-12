using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Creates a new Snipe-IT location.</summary>
    /// <remarks>The New-Location cmdlet creates a new location object.</remarks>
    /// <example>
    ///   <code>New-Location -Name "Potato Farm #12"</code>
    ///   <para>Create a new location named "Potato Farm #12" with all required properties set.</para>
    /// </example>
    [Cmdlet(VerbsCommon.New, nameof(Location))]
    [OutputType(typeof(Location))]
    public class NewLocation: PSCmdlet
    {
        /// <summary>
        /// The name of the location.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The location's address line.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Address { get; set; }

        /// <summary>
        /// The location's second address line.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Address2 { get; set; }

        /// <summary>
        /// The location's address city.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string City { get; set; }

        /// <summary>
        /// The location's address state.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string State { get; set; }

        /// <summary>
        /// The location's address country.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Country { get; set; }

        /// <summary>
        /// The location's address zip code.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string ZipCode { get; set; }

        /// <summary>
        /// The currency used at the location.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Currency { get; set; }

        /// <summary>
        /// The location of the location (its parent location).
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Location> ParentLocation { get; set; }

        /// <summary>
        /// The manager of the location.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public UserBinding Manager { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new Location {
                Name = this.Name,
                Address = this.Address,
                Address2 = this.Address2,
                City = this.City,
                State = this.State,
                Country = this.Country,
                ZipCode = this.ZipCode,
                Currency = this.Currency
            };
            if (MyInvocation.BoundParameters.ContainsKey(nameof(ParentLocation)))
            {
                if (!this.GetSingleValue(ParentLocation, out var parentLocation))
                    return;
                item.ParentLocation = parentLocation;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Manager)))
            {
                if (!this.GetSingleValue(Manager, out var manager))
                    return;
                item.Manager = manager;
            }
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Locations.Create(item));
        }
    }
}
