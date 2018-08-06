using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// A license seat.
    /// </summary>
    public sealed class LicenseSeat : ApiObject, IAvailableActions
    {
        /// <value>Gets the Id of the seat</value>
        [Field("id")]
        public long Id { get; private set; }

        /// <value>Gets the id of the corresponding license.</value>
        [Field("license_id")]
        public long LicenseId { get; private set; }

        /// <value>Gets the corresponding assigned user, or null if the license is not assigned to a user.</value>
        /// <remarks>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</remarks>
        [Field("assigned_user")]
        public User AssignedUser { get; private set; }

        /// <value>Gets the corresponding assigned asset, or null if the license is not assigned to an asset.</value>
        /// <remarks>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</remarks>
        [Field("assigned_asset")]
        public Asset AssignedAsset { get; private set; }

        /// <value>Gets the location of the assignee, or null if the license is not assigned.</value>
        /// <remarks>When deserialized, this value does not have all properties filled. Fetch the value using the relevant endpoint to gather the rest of the information.</remarks>
        [Field("location")]
        public Location Location { get; private set; }

        /// <value>Gets if the license is reassignable.</value>
        /// <seealso cref="License.IsReassignable" />
        [Field("reassignable")]
        public bool IsReassignable { get; private set; }

        /// <value>Gets if this seat can be checked out.</value>
        [Field("user_can_checkout")]
        public bool? UserCanCheckOut { get; set; }

        /// <inheritdoc />
        /// <seealso cref="License" />
        [Field("available_actions", converter: AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }

        /// <value>Gets if this seat is checked out to an asset or user or not.</value>
        public bool IsCheckedOut => AssignedUser != null || AssignedAsset != null;
    }
}
