using System;
using System.Management.Automation;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>
    /// <para type="synopsis">Checks in a Snipe IT asset.</para>
    /// <para type="description">The CheckIn-Asset cmdlet checks in one or more asset objects.</para>
    /// </summary>
    /// <example>
    ///   <code>CheckIn-Asset Asset1234</code>
    ///   <para>Checks in the asset Asset1234.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Asset -AssetTag 2345 | CheckIn-Asset</code>
    ///   <para>Checks in the asset with the tag 2345.</para>
    /// </example>
    /// <para type="link">CheckOut-Asset</para>
    /// <para type="link">Get-Asset</para>
    [Cmdlet("CheckIn", nameof(Asset))]
    [OutputType(typeof(RequestResponse<Asset>))]
    public sealed class CheckInAsset: PSCmdlet
    {
        /// <summary>
        /// <para type="description">An Asset object.</para>
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public AssetBinding Identity { get; set; }

        /// <summary>
        /// <para type="description">The note for the Asset's log.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Note { get; set; }

        /// <summary>
        /// <para type="description">The asset's new name. Defaults to the asset's current name.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string AssetName { get; set; }

        /// <summary>
        /// <para type="description">The asset's new location. Defaults to the asset's default location.</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Location> Location { get; set; }

        /// <summary>
        /// <para type="description">The asset's new status. Defaults to the asset's current status (minus any 'Deployed' metastatus).</para>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<StatusLabel> Status { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(Identity.Object is null)
            {
                WriteError(new ErrorRecord(Identity.Error, "Asset not found.", ErrorCategory.InvalidArgument, Identity.Query));
                return;
            }
            var request = new AssetCheckInRequest(Identity.Object);
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Note)))
                request.Note = Note;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
                request.Location = Location?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(StatusLabel)))
                request.StatusLabel = Status?.Object;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(AssetName)))
                request.AssetName = AssetName;
            else
                request.AssetName = request.Asset.Name;
            WriteObject(ApiHelper.Instance.Assets.CheckIn(request));
        }
    }
}
