using System;
using System.Management.Automation;
using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.Common;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Removes a Snipe IT Company.</para>
    /// <para type="description">The Remove-Company cmdlet removes one or more Company objects by name or by Snipe IT internal id number from the Snipe IT database.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Remove-Company 12</code>
    ///   <para>Removes a Company by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Remove-Company Company4368</code>
    ///   <para>Removes a Company explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Remove-Company</code>
    ///   <para>Removes the first 100 Company objects by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Company</para>
    [Cmdlet(VerbsCommon.Remove, "Company",
        DefaultParameterSetName = "ByName",
        ConfirmImpact = ConfirmImpact.High,
        SupportsShouldProcess = true
    )]
    [OutputType(typeof(IRequestResponse))]
    public class RemoveCompany: PSCmdlet
    {
        /// <summary>
        /// <para type="description">The name of the Company.</para>
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
        /// <para type="description">The internal Id of the Company.</para>
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
        /// <para type="description">A Company object.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByObject",
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        [ValidateNotNull]
        public Company[] Company { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(ParameterSetName == "ByName")
            {
                foreach(var name in Name)
                {
                    var item = ApiHelper.Instance.CompanyManager.Get(name);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Company not found by name \"{name}\"", ErrorCategory.InvalidArgument, name));
                    } else if(ShouldProcess(name))
                    {
                        var response = ApiHelper.Instance.CompanyManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(response);
                    }
                }
            } else if(ParameterSetName == "ByInternalId")
            {
                foreach(var id in InternalId)
                {
                    var item = ApiHelper.Instance.CompanyManager.Get(id);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Company not found by internal id {id}", ErrorCategory.InvalidArgument, id));
                    } else if(ShouldProcess(item.Name ?? item.Id.ToString()))
                    {
                        var response = ApiHelper.Instance.CompanyManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(response);
                    }
                }
            } else
            {
                foreach(var item in Company)
                {
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Company cannot be null!", ErrorCategory.InvalidArgument, null));
                    } else if(ShouldProcess(item.Name ?? item.Id.ToString()))
                    {
                        var response = ApiHelper.Instance.CompanyManager.Delete(item);
                        if(ShowResponse.IsPresent)
                            WriteObject(response);
                    }
                }
            }
        }
    }
}