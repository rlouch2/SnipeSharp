using System.Management.Automation;
using SnipeSharp.Filters;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Gets the License Seats of a Snipe IT License.</summary>
    /// <remarks>
    ///   <p>The Get-LicenseSeat cmdlet gets, for each license provided, the license seat objects associated with that license.</p>
    ///   <p>Paging is per-license, not overall. If you need to process a certain number of seats from multiple licenses, use <see>Select-Object</see>.</p>
    /// </remarks>
    /// <example>
    ///   <code>Get-LicenseSeat License12</code>
    ///   <para>Retrieves the license seats for the license License12.</para>
    /// </example>
    /// <example>
    ///   <code>Get-LicenseSeat License12, License11</code>
    ///   <para>Retrieves the license seats for the licenses License12 and License11.</para>
    /// </example>
    [Cmdlet(VerbsCommon.Get, "LicenseSeat", SupportsPaging = true)]
    [OutputType(typeof(LicenseSeat))]
    public sealed class GetLicenseSeat: PSCmdlet
    {
        /// <summary>The license to retrieve the seats of.</summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public ObjectBinding<License>[] License { get; set; }

        /// <summary>Which way to sort the data.</summary>
        [Parameter]
        public SearchOrder SortOrder { get; set; }

        /// <summary>On which column to sort the data.</summary>
        [Parameter]
        public LicenseSeatSearchColumn SortColumn { get; set; }

        /// <summary>If present, return the result as a <see cref="SnipeSharp.Models.ResponseCollection{T}"/> rather than enumerating.</summary>
        [Parameter]
        public SwitchParameter NoEnumerate { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var filter = new LicenseSeatSearchFilter();
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SortOrder)))
                filter.Order = SortOrder;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(SortColumn)))
                filter.SortColumn = SortColumn;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PagingParameters.First)))
                filter.Limit = (int) PagingParameters.First;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PagingParameters.Skip)))
                filter.Offset = (int) PagingParameters.Skip;
            foreach(var item in License)
            {
                if (this.GetSingleValue(item, out var itemValue))
                    WriteObject(ApiHelper.Instance.Licenses.GetSeats(itemValue, filter), !NoEnumerate.IsPresent);
            }
        }
    }
}
