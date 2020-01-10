using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A relation between a Component and an Asset.
    /// </summary>
    public sealed class ComponentAsset : ApiObject, IAvailableActions
    {
        /// <value>The ID number of the association row.</value>
        [Field(DeserializeAs = "assigned_pivot_id")]
        public int AssignedPivotId { get; private set; }

        /// <value>The ID number of the asset.</value>
        [Field(DeserializeAs = "id")]
        public int AssetId { get; private set; }

        /// <value>A name describing the asset.</value>
        [Field(DeserializeAs = "name")]
        public string Name { get; private set; }

        /// <value>How many of the component has been checked out to the asset.</value>
        [Field(DeserializeAs = "qty")]
        public int Quantity { get; private set; }

        /// <value>The type of the assignee.</value>
        [Field(DeserializeAs = "type")]
        public AssignedToType Type { get; private set; }

        /// <value>The creation date of this object in Snipe-IT.</value>
        [Field(DeserializeAs = "created_at", Converter = FieldConverter.DateTimeConverter)]
        public DateTime? CreatedAt { get; private set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; private set; }
    }
}
