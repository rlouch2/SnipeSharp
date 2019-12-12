using System.Management.Automation;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Checks in a Snipe IT asset.</summary>
    /// <remarks>The CheckIn-Asset cmdlet checks in one or more asset objects.</remarks>
    /// <example>
    ///   <code>CheckIn-Asset Asset1234</code>
    ///   <para>Checks in the asset Asset1234.</para>
    /// </example>
    /// <example>
    ///   <code>Get-Asset -AssetTag 2345 | CheckIn-Asset</code>
    ///   <para>Checks in the asset with the tag 2345.</para>
    /// </example>
    /// <seealso cref="CheckOutAsset" />
    /// <seealso cref="GetAsset" />
    [Cmdlet("CheckIn", nameof(Asset))]
    [OutputType(typeof(RequestResponse<Asset>))]
    public sealed class CheckInAsset: Cmdlet
    {
        /// <summary>An Asset object.</summary>
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public AssetBinding Identity { get; set; }

        /// <summary>The note for the Asset's log.</summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Note { get; set; }

        /// <summary>The asset's new name. Defaults to the asset's current name.</summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string AssetName { get; set; }

        /// <summary>The asset's new location. Defaults to the asset's default location.</summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<Location> Location { get; set; }

        /// <summary>The asset's new status. Defaults to the asset's current status (minus any 'Deployed' metastatus).</summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public ObjectBinding<StatusLabel> Status { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(!this.ValidateHasExactlyOneValue(Identity, queryType: nameof(Identity)))
                return;

            var request = new AssetCheckInRequest(Identity.Value[0]);
            if(!string.IsNullOrEmpty(Note))
                request.Note = Note;
            if(null != Location)
                request.Location = Location?.Value[0];
            if(null != Status)
                request.StatusLabel = Status?.Value[0];
            if(!string.IsNullOrEmpty(AssetName))
                request.AssetName = AssetName;
            WriteObject(ApiHelper.Instance.Assets.CheckIn(request));
        }
    }
}
