using System;
using System.Management.Automation;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.Cmdlets.New
{
    /// <summary>
    /// <para type="synopsis">Creates a new Snipe-IT field set.</para>
    /// <para type="description">The New-FieldSet cmdlet creates a new field set object.</para>
    /// </summary>
    /// <example>
    ///   <code>New-FieldSet -Name "Peeler"</code>
    ///   <para>Create a new field set named "Peeler".</para>
    /// </example>
    [Cmdlet(VerbsCommon.New, nameof(FieldSet))]
    [OutputType(typeof(FieldSet))]
    public class NewFieldSet: PSCmdlet
    {
        /// <summary>
        /// The name of the field set.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        
        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new FieldSet {
                Name = this.Name
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.FieldSets.Create(item));
        }
    }
}
