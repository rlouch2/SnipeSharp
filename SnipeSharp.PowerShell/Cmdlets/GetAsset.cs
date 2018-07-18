using System;
using System.Management.Automation;

namespace SnipeSharp.PowerShell
{
    [Cmdlet(VerbsCommon.Get, "Asset")]
    public class GetAsset: PSCmdlet
    {
        protected override void EndProcessing(){
            WriteObject(ApiHelper.Instance.AssetManager.GetAll().Rows, true);
        }
    }
}