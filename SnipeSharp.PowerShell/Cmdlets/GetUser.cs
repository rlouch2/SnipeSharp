using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Gets a Snipe IT user.</para>
    /// <para type="description">The Get-User cmdlet gets one or more user objects by name or by Snipe IT internal id number.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Get-User 14</code>
    ///   <para>Retrieve an user by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-User User4368</code>
    ///   <para>Retrieve an user explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-User</code>
    ///   <para>Retrieve the first 100 categories by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-User</para>
    [Cmdlet(VerbsCommon.Get, "User",
        DefaultParameterSetName = "ByName"
    )]
    [OutputType(typeof(User))]
    public class GetUser: PSCmdlet
    {
        /// <summary>
        /// <para type="description">The name of the User.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByInternalId",
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public int[] InternalId { get; set; }

        /// <summary>
        /// <para type="description">The internal Id of the User.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByName",
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public string[] Name { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(ParameterSetName == "ByName")
            {
                foreach(var name in Name)
                {
                    var item = ApiHelper.Instance.UserManager.Get(name);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"User not found by name \"{name}\"", ErrorCategory.InvalidArgument, name));
                    } else
                    {
                        WriteObject(item);
                    }
                }
            } else
            {
                foreach(var id in InternalId)
                {
                    var item = ApiHelper.Instance.UserManager.Get(id);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"User not found by internal id {id}", ErrorCategory.InvalidArgument, id));
                    } else
                    {
                        WriteObject(item);
                    }
                }
            }
        }
    }
}