using System.Management.Automation;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Creates a new Snipe-IT depreciation.</summary>
    /// <remarks>The New-Depreciation cmdlet creates a new depreciation object.</remarks>
    /// <example>
    ///   <code>New-Depreciation -Name "General Potato Peeler" -Months 36</code>
    ///   <para>Create a new depreciation named "General Potato Peeler" with all required properties set.</para>
    /// </example>
    [Cmdlet(VerbsCommon.New, nameof(Depreciation))]
    [OutputType(typeof(Depreciation))]
    public class NewDepreciation: PSCmdlet
    {
        /// <summary>
        /// The name of the depreciation.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// How long the depreciation lasts in months.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        public int Months { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            var item = new Depreciation {
                Name = this.Name,
                Months = this.Months
            };
            //TODO: error handling
            WriteObject(ApiHelper.Instance.Depreciations.Create(item));
        }
    }
}
