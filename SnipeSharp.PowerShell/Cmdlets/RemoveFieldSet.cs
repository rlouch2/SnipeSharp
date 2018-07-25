using System;
using System.Management.Automation;
using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Common;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT Field set.</para>
    /// <para type="description">The Remove-FieldSet cmdlet removes one or more FieldSet objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Remove-FieldSet 12</code>
    ///   <para>Removes a FieldSet by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-FieldSet FieldSet4368</code>
    ///   <para>Removes a FieldSet explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-FieldSet</code>
    ///   <para>Removes the first 100 FieldSet objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-FieldSet</para>
    [Cmdlet(VerbsCommon.Remove, "FieldSet",
        DefaultParameterSetName = "ByName",
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(IRequestResponse))]
    public class RemoveFieldSet: PSCmdlet
    {
        /// <summary>
        /// <para type="description">The name of the FieldSet.</para>
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
        /// <para type="description">The internal Id of the FieldSet.</para>
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
        /// <para type="description">A FieldSet object.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByObject",
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNull]
        public FieldSet[] FieldSet { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(ParameterSetName == "ByName")
            {
                foreach(var name in Name)
                {
                    var item = ApiHelper.Instance.FieldSetManager.Get(name);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Field set not found by name \"{name}\"", ErrorCategory.InvalidArgument, name));
                    } else if(ShouldProcess(name))
                    {
                        var respone = ApiHelper.Instance.FieldSetManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(respone);
                    }
                }
            } else if(ParameterSetName == "ByInternalId")
            {
                foreach(var id in InternalId)
                {
                    var item = ApiHelper.Instance.FieldSetManager.Get(id);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Field set not found by internal id {id}", ErrorCategory.InvalidArgument, id));
                    } else if(ShouldProcess(item.Name ?? item.Id.ToString()))
                    {
                        var respone = ApiHelper.Instance.FieldSetManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(respone);
                    }
                }
            } else
            {
                foreach(var item in FieldSet)
                {
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Field set cannot be null!", ErrorCategory.InvalidArgument, null));
                    } else if(ShouldProcess(item.Name ?? item.Id.ToString()))
                    {
                        var respone = ApiHelper.Instance.FieldSetManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(respone);
                    }
                }
            }
        }
    }
}