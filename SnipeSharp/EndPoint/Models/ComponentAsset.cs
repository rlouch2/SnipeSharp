using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// A relation between a Component and an Assignee.
    /// </summary>
    public sealed class ComponentAssignee : ApiObject, IAvailableActions
    {
        /// <value>The ID number of the component.</value>
        [Field("assigned_pivot_id")]
        public int ComponentId { get; private set; }
        
        /// <value>The ID number of the assignee.</value>
        [Field("id")]
        public int AssigneeId { get; private set; }
        
        /// <value>A name describing the asset.</value>
        [Field("name")]
        public string Name { get; private set; }
        
        /// <value>How many of the component has been checked out to the asset.</value>
        [Field("qty")]
        public int Quantity { get; private set; }

        /// <value>The type of the assignee.</value>
        [Field("type")]
        public AssignedToType Type { get; private set; }
        
        /// <value>The creation date of this object in Snipe-IT.</value>
        [Field("created_at")]
        public DateTime? CreatedAt { get; private set; }

        /// <inheritdoc />
        [Field("available_actions", converter: AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }
    }
}
