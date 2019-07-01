using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Gets the License Seats of a Snipe IT License.</summary>
    /// <remarks>The Get-LicenseSeat cmdlet gets, for each license provided, the license seat objects associated with that license.</remarks>
    /// <example>
    ///   <code>Get-LicenseSeat License12</code>
    ///   <para>Retrieves the license seats for the license License12.</para>
    /// </example>
    /// <example>
    ///   <code>Get-LicenseSeat License12, License11</code>
    ///   <para>Retrieves the license seats for the licenses License12 and License11.</para>
    /// </example>
    [Cmdlet(VerbsCommon.Get, "LicenseSeat")]
    [OutputType(typeof(LicenseSeat))]
    public sealed class GetLicenseSeat: BaseCmdlet
    {
        /// <summary>The license to retrieve the seats of.</summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public ObjectBinding<License>[] License { get; set; }

        /// <summary>If present, return the result as a <see cref="SnipeSharp.Models.ResponseCollection{T}"/> rather than enumerating.</summary>
        [Parameter]
        public SwitchParameter NoEnumerate { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            foreach(var item in License)
            {
                if (GetSingleValue(item, out var itemValue))
                    WriteObject(ApiHelper.Instance.Licenses.GetSeats(itemValue), !NoEnumerate.IsPresent);
            }
        }
    }
}
