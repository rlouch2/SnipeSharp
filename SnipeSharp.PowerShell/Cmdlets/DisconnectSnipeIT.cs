using System;
using System.Management.Automation;

namespace SnipeSharp.PowerShell
{
    /// <summary>
    /// <para type="synopsis">Ends the current session with Snipe IT.</para>
    /// <para type="description">The Disconnect-SnipeIT cmdlet ends the current session with Snipe IT. This cmdlet does not throw any errors if there is no connected session.</para>
    /// </summary>
    /// <example>
    ///   <code>Disconnect-SnipeIT</code>
    ///   <para>Disconnect from the current Snipe IT session, or verify that there isn't a current session.</para>
    /// </example>
    /// <para type="link">Connect-SnipeIT</para>
    [Cmdlet(VerbsCommunications.Disconnect, "SnipeIT")]
    public class DisconnectSnipeIT: PSCmdlet
    {
        /// <inheritdoc />
        protected override void EndProcessing(){
            ApiHelper.Instance = null;
        }
    }
}