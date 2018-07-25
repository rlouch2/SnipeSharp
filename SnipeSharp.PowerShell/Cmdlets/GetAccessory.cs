using System;
using System.Management.Automation;
using System.Collections.Generic;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Gets a Snipe IT accessory.</para>
    /// <para type="description">The Get-Accessory cmdlet gets one or more accessory objects by name or by Snipe IT internal id number.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Get-Accessory 12</code>
    ///   <para>Retrieve an accessory by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Accessory Accessory4368</code>
    ///   <para>Retrieve an accessory explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Accessory</code>
    ///   <para>Retrieve the first 100 accessories by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Accessory</para>
    [Cmdlet(VerbsCommon.Get, "Accessory",
        DefaultParameterSetName = "ByName"
    )]
    [OutputType(typeof(Accessory))]
    public class GetAccessory: PSCmdlet
    {
        /// <summary>
        /// <para type="description">The name of the Accessory.</para>
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
        /// <para type="description">The internal Id of the Accessory.</para>
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
                    var item = ApiHelper.Instance.AccessoryManager.Get(name);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Accessory not found by name \"{name}\"", ErrorCategory.InvalidArgument, name));
                    } else
                    {
                        WriteObject(item);
                    }
                }
            } else
            {
                foreach(var id in InternalId)
                {
                    var item = ApiHelper.Instance.AccessoryManager.Get(id);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Accessory not found by internal id {id}", ErrorCategory.InvalidArgument, id));
                    } else
                    {
                        WriteObject(item);
                    }
                }
            }
        }
    }
}
