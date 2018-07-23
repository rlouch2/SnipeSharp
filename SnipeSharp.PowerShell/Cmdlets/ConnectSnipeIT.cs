﻿using System;
using System.Management.Automation;

namespace SnipeSharp.PowerShell
{
    /// <summary>
    /// <para type="synopsis">Connects to Snipe IT.</para>
    /// <para type="description">The Connect-SnipeIT cmdlet begins a session with a Snipe IT instance.</para>
    /// <para type="description">You may only have one SnipeIT session per PowerShell session.</para>
    /// </summary>
    /// <example>
    ///   <code>Connect-SnipeIT -Uri 'https://inventory.example.com/api/v1' -ApiToken $ApiToken</code>
    ///   <para>Connect to a Snipe IT session at "inventory.example.com" with the token in $ApiToken.</para>
    /// </example>
    /// <para type="link">Disconnect-SnipeIT</para>
    /// <para type="link" uri="(https://snipe-it.readme.io/reference#generating-api-tokens)">[Generating API tokens for Snipe IT]</para>
    [Cmdlet(VerbsCommunications.Connect, "SnipeIT")]
    public class ConnectSnipeIT: PSCmdlet
    {
        /// <summary>
        /// <para type="description">The Api token to connect to Snipe IT with.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 1,
            HelpMessage = "API Token to use to connect to Snipe IT."
        )]
        public string ApiToken { get; set; }

        /// <summary>
        /// <para type="description">The URI for the API endpoint of your Snipe IT instance. Usually this is the same as the URL for your instance, with the path "/api/v1".</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 0,
            HelpMessage = "The API URI for a Snipe IT instance."
        )]
        public Uri Uri { get; set; }

        /// <inheritdoc />
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