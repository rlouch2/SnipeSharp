using System;
using System.Management.Automation;

namespace SnipeSharp.PowerShell
{
    [Cmdlet(VerbsCommunications.Disconnect, "SnipeIT")]
    public class DisconnectSnipeIT: PSCmdlet
    {
        protected override void EndProcessing(){
            ApiHelper.Instance = null;
        }
    }
}