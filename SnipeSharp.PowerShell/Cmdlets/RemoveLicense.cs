using System;
using System.Management.Automation;
using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Common;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT License.</para>
    /// <para type="description">The Remove-License cmdlet removes one or more License objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Remove-License 12</code>
    ///   <para>Removes a License by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-License License4368</code>
    ///   <para>Removes a License explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-License</code>
    ///   <para>Removes the first 100 License objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-License</para>
    [Cmdlet(VerbsCommon.Remove, "License",
        DefaultParameterSetName = "ByName",
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(IRequestResponse))]
    public class RemoveLicense: PSCmdlet
    {
        /// <summary>
        /// <para type="description">The name of the License.</para>
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
        /// <para type="description">The internal Id of the License.</para>
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
        /// <para type="description">A License object.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByObject",
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNull]
        public License[] License { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(ParameterSetName == "ByName")
            {
                foreach(var name in Name)
                {
                    var item = ApiHelper.Instance.LicenseManager.Get(name);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"License not found by name \"{name}\"", ErrorCategory.InvalidArgument, name));
                    } else if(ShouldProcess(name))
                    {
                        var respone = ApiHelper.Instance.LicenseManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(respone);
                    }
                }
            } else if(ParameterSetName == "ByInternalId")
            {
                foreach(var id in InternalId)
                {
                    var item = ApiHelper.Instance.LicenseManager.Get(id);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"License not found by internal id {id}", ErrorCategory.InvalidArgument, id));
                    } else if(ShouldProcess(item.Name ?? item.Id.ToString()))
                    {
                        var respone = ApiHelper.Instance.LicenseManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(respone);
                    }
                }
            } else
            {
                foreach(var item in License)
                {
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"License cannot be null!", ErrorCategory.InvalidArgument, null));
                    } else if(ShouldProcess(item.Name ?? item.Id.ToString()))
                    {
                        var respone = ApiHelper.Instance.LicenseManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(respone);
                    }
                }
            }
        }
    }
}