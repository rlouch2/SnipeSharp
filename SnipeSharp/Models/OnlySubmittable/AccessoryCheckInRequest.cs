using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A request to disassociate an Accessory with a User.
    /// </summary>
    public sealed class AccessoryCheckInRequest : ApiObject
    {
        /// <value>The Accessory that will be checked in.</value>
        /// <remarks>This property is not serialized, but instead used for its Id value.</remarks>
        public Accessory Accessory { get; private set; }

        /// <value>The note to put in the log for this check-out event.</value>
        [SerializeAs("note")]
        public string Note { get; set; }

        /// <summary>
        /// Begins a new AccessoryCheckInRequest disassociating the supplied accessory from its assignee.
        /// </summary>
        /// <param name="accessory">The accessory to disassociate.</param>
        public AccessoryCheckInRequest(Accessory accessory)
        {
            Accessory = accessory;
        }
    }
}
