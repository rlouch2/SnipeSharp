using System.Management.Automation;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Gets Snipe IT requests.</summary>
    /// <remarks>The Get-Request cmdlet gets all requests for the current account.</remarks>
    /// <example>
    ///   <code>Get-Request</code>
    ///   <para>Retrieve all requests for the current account.</para>
    /// </example>
    /// <seealso cref="FindRequestableAsset" />
    [Cmdlet(VerbsCommon.Get, nameof(Request))]
    [OutputType(typeof(Request))]
    public sealed class GetRequest: Cmdlet
    {
        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            WriteObject(ApiHelper.Instance.Account.GetRequests(), true);
        }
    }
}
