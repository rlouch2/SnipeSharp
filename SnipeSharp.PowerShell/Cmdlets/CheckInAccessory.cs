using System.Management.Automation;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.Models;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Checks in a Snipe IT accessory.</summary>
    /// <remarks>The CheckIn-Accessory cmdlet checks in one or more asset objects.</remarks>
    /// <example>
    ///   <code>CheckIn-Accessory 6</code>
    ///   <para>Checks in the assigned accessory with ID 6.</para>
    /// </example>
    /// <seealso cref="CheckOutAccessory" />
    /// <seealso cref="GetAssignedAccessory" />
    [Cmdlet("CheckIn", nameof(Accessory))]
    [OutputType(typeof(RequestResponse<Asset>))]
    public sealed class CheckInAccessory: BaseCmdlet
    {
        /// <summary>An Asset object.</summary>
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public ObjectBinding<Accessory> Identity { get; set; }

        /// <summary>The note for the Asset's log.</summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Note { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(!ValidateHasExactlyOneValue(Identity, queryType: nameof(Identity)))
                return;

            var request = new AccessoryCheckInRequest(Identity.Value[0]);
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Note)))
                request.Note = Note;
            WriteObject(ApiHelper.Instance.Accessories.CheckIn(request));
        }
    }
}
