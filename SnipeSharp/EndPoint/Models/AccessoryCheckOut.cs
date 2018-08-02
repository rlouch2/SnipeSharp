using System.Collections.Generic;
using SnipeSharp.Serialization;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// An Accessory/User relation.
    /// Describes a user that an asset is checked out to. 
    /// </summary>
    public sealed class AccessoryCheckOut : ApiObject, IAvailableActions
    {
        /// <summary>
        /// The Id of the Accessory in Snipe-IT.
        /// </summary>
        [Field("assigned_pivot_id")]
        public int AccessoryId { get; set; }
        
        /// <summary>
        /// The Id of the User in Snipe-IT.
        /// </summary>
        [Field("id")]
        public int UserId { get; set; }
        
        /// <summary>
        /// The user's username.
        /// </summary>
        [Field("username")]
        public string UserName { get; set; }
        
        /// <summary>
        /// The user's full name.
        /// </summary>
        [Field("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// The user's first name.
        /// </summary>
        [Field("first_name")]
        public string FirstName { get; set; }
        
        /// <summary>
        /// The user's last name.
        /// </summary>
        [Field("last_name")]
        public string LastName { get; set; }
        
        /// <summary>
        /// The user's employee number.
        /// </summary>
        [Field("employee_number")]
        public string EmployeeNumber { get; set; }
        
        /// <summary>
        /// The assignee type of this particular check out.
        /// </summary>
        /// <remarks>Currently, this field will always be User.</remarks>
        [Field("type")]
        public AssignedToType Type { get; set; }

        /// <inheritdoc />
        /// <remarks>Currently, this will always be <c>{CheckIn}</c>.</remarks>
        [Field("available_actions")]
        public HashSet<AvailableAction> AvailableActions { get; set; }
    }
}
