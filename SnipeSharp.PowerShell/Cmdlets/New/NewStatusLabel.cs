using System;
using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Models.Enumerations;

namespace SnipeSharp.PowerShell.Cmdlets.New
{
    /// <summary>
    /// <para type="synopsis">Creates a new Snipe-IT status label.</para>
    /// <para type="description">The New-StatusLabel cmdlet creates a new status label object.</para>
    /// </summary>
    /// <example>
    ///   <code>New-StatusLabel -Name "Assignable" -Type Deployable</code>
    ///   <para>Create a new deployable status label named "Assignable".</para>
    /// </example>
    [Cmdlet(VerbsCommon.New, nameof(StatusLabel))]
    [OutputType(typeof(StatusLabel))]
    public class NewStatusLabel: PSCmdlet
    {
        /// <summary>
        /// The name of the status label.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        /// <summary>
        /// The type of status this label represents.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        public StatusType Type { get; set; }

        /// <summary>
        /// Any notes for the label.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Notes { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new StatusLabel {
                Name = this.Name,
                Type = this.Type,
                Notes = this.Notes
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.StatusLabels.Create(item));
        }
    }
}
