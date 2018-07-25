using System;
using System.Management.Automation;
using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Common;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT Depreciation.</para>
    /// <para type="description">The Remove-Depreciation cmdlet removes one or more Depreciation objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Remove-Depreciation 12</code>
    ///   <para>Removes a Depreciation by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-Depreciation Depreciation4368</code>
    ///   <para>Removes a Depreciation explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-Depreciation</code>
    ///   <para>Removes the first 100 Depreciation objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Depreciation</para>
    [Cmdlet(VerbsCommon.Remove, "Depreciation",
        DefaultParameterSetName = "ByName",
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(IRequestResponse))]
    public class RemoveDepreciation: PSCmdlet
    {
        /// <summary>
        /// <para type="description">The name of the Depreciation.</para>
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
        /// <para type="description">The internal Id of the Depreciation.</para>
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
        /// <para type="description">A Depreciation object.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByObject",
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNull]
        public Depreciation[] Depreciation { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(ParameterSetName == "ByName")
            {
                foreach(var name in Name)
                {
                    var item = ApiHelper.Instance.DepreciationManager.Get(name);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Depreciation not found by name \"{name}\"", ErrorCategory.InvalidArgument, name));
                    } else if(ShouldProcess(name))
                    {
                        var respone = ApiHelper.Instance.DepreciationManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(respone);
                    }
                }
            } else if(ParameterSetName == "ByInternalId")
            {
                foreach(var id in InternalId)
                {
                    var item = ApiHelper.Instance.DepreciationManager.Get(id);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Depreciation not found by internal id {id}", ErrorCategory.InvalidArgument, id));
                    } else if(ShouldProcess(item.Name ?? item.Id.ToString()))
                    {
                        var respone = ApiHelper.Instance.DepreciationManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(respone);
                    }
                }
            } else
            {
                foreach(var item in Depreciation)
                {
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Depreciation cannot be null!", ErrorCategory.InvalidArgument, null));
                    } else if(ShouldProcess(item.Name ?? item.Id.ToString()))
                    {
                        var respone = ApiHelper.Instance.DepreciationManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(respone);
                    }
                }
            }
        }
    }
}