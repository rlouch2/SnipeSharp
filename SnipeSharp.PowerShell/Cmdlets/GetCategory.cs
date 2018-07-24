using System;
using System.Management.Automation;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Gets a Snipe IT category.</para>
    /// <para type="description">The Get-Category cmdlet gets one or more category objects by name or by Snipe IT internal id number.</para>
    /// <para type="description">Whatever identifier is used, both accept pipeline input.</para>
    /// </summary>
    /// <example>
    ///   <code>Get-Category 14</code>
    ///   <para>Retrieve an category by its Internal Id.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Category Category4368</code>
    ///   <para>Retrieve an category explicitly by its Name.</para>
    /// </example>
    /// <example>
    ///   <code>1..100 | Get-Category</code>
    ///   <para>Retrieve the first 100 categories by their Snipe IT internal Id numbers.</para>
    /// </example>
    /// <para type="link">Find-Category</para>
    [Cmdlet(VerbsCommon.Get, "Category",
        DefaultParameterSetName = "ByName"
    )]
    public class GetCategory: PSCmdlet
    {
        /// <summary>
        /// <para type="description">The name of the Category.</para>
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
        /// <para type="description">The internal Id of the Category.</para>
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
                    var item = ApiHelper.Instance.CategoryManager.Get(name);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Category not found by name \"{name}\"", ErrorCategory.InvalidArgument, name));
                    } else
                    {
                        WriteObject(item);
                    }
                }
            } else
            {
                foreach(var id in InternalId)
                {
                    var item = ApiHelper.Instance.CategoryManager.Get(id);
                    if(item == null)
                    {
                        WriteError(new ErrorRecord(null, $"Category not found by internal id {id}", ErrorCategory.InvalidArgument, id));
                    } else
                    {
                        WriteObject(item);
                    }
                }
            }
        }
    }
}