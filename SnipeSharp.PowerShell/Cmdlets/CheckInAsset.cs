using System;
using System.Management.Automation;
using SnipeSharp.Common;
using SnipeSharp.PowerShell.BindingTypes;

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
    [Cmdlet("CheckIn", "Asset")]
    [OutputType(typeof(IRequestResponse))]
    public class CheckInAsset: PSCmdlet
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
        public AssetIdentity[] Identity { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            foreach(var item in Identity)
            {
                if(item.Asset == null)
                {
                    WriteError(new ErrorRecord(null, $"Asset not found by Identity {item.Identity}", ErrorCategory.InvalidArgument, item.Identity));
                    continue;
                }
                WriteObject(ApiHelper.Instance.AssetManager.Checkin(item.Asset));
            }
        }
    }
}