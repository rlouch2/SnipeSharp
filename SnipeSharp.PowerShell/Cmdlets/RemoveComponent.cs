using System;
using System.Management.Automation;
using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Common;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT Component.</para>
    /// <para type="description">The Remove-Component cmdlet removes one or more Component objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Remove-Component 12</code>
    ///   <para>Removes a Component by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-Component Component4368</code>
    ///   <para>Removes a Component explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-Component</code>
    ///   <para>Removes the first 100 Component objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Component</para>
    [Cmdlet(VerbsCommon.Remove, "Component",
        DefaultParameterSetName = "ByName",
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(IRequestResponse))]
    public class RemoveComponent: PSCmdlet
    {
        /// <summary>
        /// <para type="description">The name of the Component.</para>
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
        /// <para type="description">The internal Id of the Component.</para>
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
        /// <para type="description">A Component object.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByObject",
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNull]
        public Component[] Component { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(ParameterSetName == "ByName")
            {
                foreach(var name in Name)
                {
                    var item = ApiHelper.Instance.ComponentManager.Get(name);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Component not found by name \"{name}\"", ErrorCategory.InvalidArgument, name));
                    } else if(ShouldProcess(name))
                    {
                        var respone = ApiHelper.Instance.ComponentManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(respone);
                    }
                }
            } else if(ParameterSetName == "ByInternalId")
            {
                foreach(var id in InternalId)
                {
                    var item = ApiHelper.Instance.ComponentManager.Get(id);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Component not found by internal id {id}", ErrorCategory.InvalidArgument, id));
                    } else if(ShouldProcess(item.Name ?? item.Id.ToString()))
                    {
                        var respone = ApiHelper.Instance.ComponentManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(respone);
                    }
                }
            } else
            {
                foreach(var item in Component)
                {
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Component cannot be null!", ErrorCategory.InvalidArgument, null));
                    } else if(ShouldProcess(item.Name ?? item.Id.ToString()))
                    {
                        var respone = ApiHelper.Instance.ComponentManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(respone);
                    }
                }
            }
        }
    }
}