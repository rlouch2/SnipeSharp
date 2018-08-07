using System;
using System.Management.Automation;
using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Common;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT User.</para>
    /// <para type="description">The Remove-User cmdlet removes one or more User objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Remove-User 12</code>
    ///   <para>Removes a User by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-User User4368</code>
    ///   <para>Removes a User explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-User</code>
    ///   <para>Removes the first 100 User objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-User</para>
    [Cmdlet(VerbsCommon.Remove, "User",
        DefaultParameterSetName = "ByName",
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(IRequestResponse))]
    public class RemoveUser: PSCmdlet
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

        /// <summary>
        /// <para type="description">If present, write the response from the Api to the pipeline.</para>
        /// </summary>
        [Parameter]
        public SwitchParameter ShowResponse { get; set; }

        /// <summary>
        /// <para type="description">A User object.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByObject",
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNull]
        public User[] User { get; set; }

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
                    } else if(ShouldProcess(name))
                    {
                        var response = ApiHelper.Instance.UserManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(response);
                    }
                }
            } else if(ParameterSetName == "ByInternalId")
            {
                foreach(var id in InternalId)
                {
                    var item = ApiHelper.Instance.UserManager.Get(id);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"User not found by internal id {id}", ErrorCategory.InvalidArgument, id));
                    } else if(ShouldProcess(item.Name ?? item.Id.ToString()))
                    {
                        var response = ApiHelper.Instance.UserManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(response);
                    }
                }
            } else
            {
                foreach(var item in User)
                {
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"User cannot be null!", ErrorCategory.InvalidArgument, null));
                    } else if(ShouldProcess(item.Name ?? item.Id.ToString()))
                    {
                        var response = ApiHelper.Instance.UserManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(response);
                    }
                }
            }
        }
    }
}