using System;
using System.Management.Automation;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Audits a Snipe IT asset.</summary>
    /// <remarks>
    ///   The Invoke-AssetAudit cmdlet audits one or more asset objects.
    /// </remarks>
    /// <example>
    ///   <code>Invoke-AssetAudit 14 -Location 'Site 1'</code>
    ///   <para>Audits the asset with the ID 14 at location "Site 1".</para>
    /// </example>
    [Cmdlet(VerbsLifecycle.Invoke, "AssetAudit")]
    [OutputType(typeof(RequestResponse<AssetAudit>))]
    public sealed class InvokeAssetAudit: Cmdlet
    {
        /// <summary>An Asset identity.</summary>
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public AssetBinding[] Identity { get; set; }

        /// <summary>The audit location.</summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true
        )]
        public ObjectBinding<Location> Location { get; set; }

        /// <summary>The date of the next expected audit.</summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public DateTime? NextAuditDate { get; set; }

        /// <summary>Any notes for the audit log.</summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [AllowEmptyString()]
        [AllowNull()]
        public string Notes { get; set; } = null;

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(!this.GetSingleValue(Location, out var location, queryType: nameof(Location), required: true))
                return;
            foreach(var assetIdentity in Identity)
            {
                if(this.GetSingleValue(assetIdentity, out var asset, queryType: assetIdentity.Query, required: true))
                    WriteObject(ApiHelper.Instance.Assets.Audit(asset, location, nextAuditDate: NextAuditDate.Value, notes: Notes));
            }
        }
    }
}
