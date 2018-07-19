using System;
using System.Management.Automation;

namespace SnipeSharp.PowerShell
{
    [Cmdlet(VerbsCommunications.Connect, "SnipeIT")]
    public class ConnectSnipeIT: PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 1,
            HelpMessage = "API Token to use to connect to Snipe IT."
        )]
        public string ApiToken { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 0,
            HelpMessage = "The API URI for a Snipe IT instance."
        )]
        public Uri Uri { get; set; }

        protected override void EndProcessing(){
            ApiHelper.Instance = new SnipeItApi {
                ApiSettings = {
                    ApiToken = this.ApiToken,
                    BaseUrl = this.Uri
                }
            };
            // TODO: test that it connects
        }
    }
}