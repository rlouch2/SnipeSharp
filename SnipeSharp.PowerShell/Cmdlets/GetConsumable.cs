using System;
using System.Management.Automation;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Gets a Snipe IT consumable.</para>
    /// <para type="description">The Get-Consumable cmdlet gets one or more consumable objects by name or by Snipe IT internal id number.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Get-Consumable 14</code>
    ///   <para>Retrieve an consumable by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Consumable Consumable4368</code>
    ///   <para>Retrieve an consumable explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Consumable</code>
    ///   <para>Retrieve the first 100 categories by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Consumable</para>
    [Cmdlet(VerbsCommon.Get, "Consumable",
        DefaultParameterSetName = "ByName"
    )]
    public class GetConsumable: PSCmdlet
    {
        /// <summary>
        /// <para type="description">The name of the Consumable.</para>
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
        /// <para type="description">The internal Id of the Consumable.</para>
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
                    var item = ApiHelper.Instance.ConsumableManager.Get(name);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Consumable not found by name \"{name}\"", ErrorCategory.InvalidArgument, name));
                    } else
                    {
                        WriteObject(item);
                    }
                }
            } else
            {
                foreach(var id in InternalId)
                {
                    var item = ApiHelper.Instance.ConsumableManager.Get(id);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Consumable not found by internal id {id}", ErrorCategory.InvalidArgument, id));
                    } else
                    {
                        WriteObject(item);
                    }
                }
            }
        }
    }
}