using System;
using SnipeSharp.Exceptions;
using System.Management.Automation;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Connects to Snipe IT.</summary>
    /// <remarks>
    ///   <para>The Connect-SnipeIT cmdlet begins a session with a Snipe IT instance.</para>
    ///   <para>You may only have one SnipeIT session per PowerShell session.</para>
    /// </remarks>
    /// <example>
    ///   <code>Connect-SnipeIT -Uri 'https://inventory.example.com/api/v1' -ApiToken $ApiToken</code>
    ///   <para>Connect to a Snipe IT session at "inventory.example.com" with the token in $ApiToken.</para>
    /// </example>
    /// <seealso cref="DisconnectSnipeIT" />
    /// <seealso link="https://snipe-it.readme.io/reference#generating-api-tokens">Generating API tokens for Snipe IT</seealso>
    [Cmdlet(VerbsCommunications.Connect, "IT")]
    public sealed class ConnectSnipeIT: PSCmdlet
    {
        /// <summary>The Api token to connect to Snipe IT with.</summary>
        [Parameter(
            Mandatory = true,
            Position = 1,
            HelpMessage = "API Token to use to connect to Snipe IT."
        )]
        public string Token { get; set; }

        /// <summary>The URI for the API endpoint of your Snipe IT instance. Usually this is the same as the URL for your instance, with the path "/api/v1".</summary>
        [Parameter(
            Mandatory = true,
            Position = 0,
            HelpMessage = "The API URI for a Snipe IT instance."
        )]
        public Uri Uri { get; set; }

        /// <inheritdoc />
        protected override void EndProcessing(){
            var instance = new SnipeItApi {
                Token = this.Token,
                Uri = this.Uri
            };

            if(instance.TestConnection())
                ApiHelper.Instance = instance;
            else
                throw new ApiErrorException($"Could not validate a connection to Snipe-IT at Uri \"{Uri}\".");

#if DEBUG
            WriteObject(ApiHelper.Instance);
#endif
        }
    }
}
