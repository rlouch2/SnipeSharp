using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A request to associate an Accessory with a User.
    /// </summary>
    public sealed class AccessoryCheckOutRequest : ApiObject
    {
        /// <value>The Accessory that will be checked out.</value>
        /// <remarks>This property is not serialized, but instead used for its Id value.</remarks>
        public Accessory Accessory { get; private set; }

        /// <value>The assigned user.</value>
        [Field("assigned_to", Converter = CommonModelConverter)]
        public User AssignedUser { get; private set; }

        /// <value>The note to put in the log for this check-out event.</value>
        [Field("note")]
        public string Note { get; set; }

        /// <summary>
        /// Begins a new AccessoryCheckOutRequest assigning the supplied accessory to the supplied user.
        /// </summary>
        /// <param name="accessory">The accessory to assign.</param>
        /// <param name="user">The User to assign the accessory to.</param>
        public AccessoryCheckOutRequest(Accessory accessory, User user)
        {
            Accessory = accessory;
            AssignedUser = user;
        }
    }
}
