using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.PowerShell.BindingTypes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Checks out a Snipe IT accessory to a user.</summary>
    /// <remarks>The CheckOut-Accessory cmdlet checks out an accessory to a user.</remarks>
    /// <example>
    ///   <code>CheckOut-Accessory -Accessory 2 -AssignedUser "Marty McFly"</code>
    ///   <para>Checks out the accessory 2 to Marty McFly.</para>
    /// </example>
    /// <seealso cref="CheckInAccessory" />
    /// <seealso cref="GetAssignedAccessory" />
    [Cmdlet("CheckOut", nameof(Accessory))]
    [OutputType(typeof(RequestResponse<Asset>))]
    public sealed class CheckOutAccessory: Cmdlet
    {
        /// <summary>An Accessory identity.</summary>
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true
        )]
        public ObjectBinding<Accessory> Accessory { get; set; }

        /// <summary>The identity of a User to assign the Accessory to.</summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true
        )]
        public UserBinding AssignedUser { get; set; }

        /// <summary>The note for the Accessory's log.</summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Note { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if(!this.GetSingleValue(Accessory, out var accessory))
                return;
            if(!this.GetSingleValue(AssignedUser, out var user))
                return;
            WriteObject(ApiHelper.Instance.Accessories.CheckOut(new AccessoryCheckOutRequest(accessory, user)));
        }
    }
}
