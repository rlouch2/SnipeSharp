using System;
using System.Management.Automation;
using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Common;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT Model.</para>
    /// <para type="description">The Remove-Model cmdlet removes one or more Model objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Remove-Model 12</code>
    ///   <para>Removes a Model by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-Model Model4368</code>
    ///   <para>Removes a Model explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-Model</code>
    ///   <para>Removes the first 100 Model objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Model</para>
    [Cmdlet(VerbsCommon.Remove, "Model",
        DefaultParameterSetName = "ByName",
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(IRequestResponse))]
    public class RemoveModel: PSCmdlet
    {
        /// <summary>
        /// <para type="description">The name of the Model.</para>
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
        /// <para type="description">The internal Id of the Model.</para>
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
        /// <para type="description">A Model object.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByObject",
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNull]
        public Model[] Model { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(ParameterSetName == "ByName")
            {
                foreach(var name in Name)
                {
                    var item = ApiHelper.Instance.ModelManager.Get(name);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Model not found by name \"{name}\"", ErrorCategory.InvalidArgument, name));
                    } else if(ShouldProcess(name))
                    {
                        var respone = ApiHelper.Instance.ModelManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(respone);
                    }
                }
            } else if(ParameterSetName == "ByInternalId")
            {
                foreach(var id in InternalId)
                {
                    var item = ApiHelper.Instance.ModelManager.Get(id);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Model not found by internal id {id}", ErrorCategory.InvalidArgument, id));
                    } else if(ShouldProcess(item.Name ?? item.Id.ToString()))
                    {
                        var respone = ApiHelper.Instance.ModelManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(respone);
                    }
                }
            } else
            {
                foreach(var item in Model)
                {
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Model cannot be null!", ErrorCategory.InvalidArgument, null));
                    } else if(ShouldProcess(item.Name ?? item.Id.ToString()))
                    {
                        var respone = ApiHelper.Instance.ModelManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(respone);
                    }
                }
            }
        }
    }
}