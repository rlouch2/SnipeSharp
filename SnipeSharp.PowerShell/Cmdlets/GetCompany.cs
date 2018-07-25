using System;
using System.Management.Automation;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Gets a Snipe IT company.</para>
    /// <para type="description">The Get-Company cmdlet gets one or more company objects by name or by Snipe IT internal id number.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Get-Company 5</code>
    ///   <para>Retrieve an company by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Company Company4368</code>
    ///   <para>Retrieve an company explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Company</code>
    ///   <para>Retrieve the first 100 categories by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Company</para>
    [Cmdlet(VerbsCommon.Get, "Company",
        DefaultParameterSetName = "ByName"
    )]
    [OutputType(typeof(Company))]
    public class GetCompany: PSCmdlet
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
                    } else
                    {
                        WriteObject(item);
                    }
                }
            } else
            {
                foreach(var id in InternalId)
                {
                    var item = ApiHelper.Instance.CompanyManager.Get(id);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Company not found by internal id {id}", ErrorCategory.InvalidArgument, id));
                    } else
                    {
                        WriteObject(item);
                    }
                }
            }
        }
    }
}