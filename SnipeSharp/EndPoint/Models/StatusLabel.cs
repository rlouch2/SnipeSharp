using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// A Status label.
    /// Status labels are used out to organize Assets and manage their state.
    /// </summary>
    [PathSegment("statuslabels")]
    public sealed class StatusLabel : CommonEndPointModel, IAvailableActions
    {
        /// <inheritdoc />
        [Field("id")]
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required and must have a unique value.</remarks>
        [Field("name", true, required: true)]
        public override string Name { get; set; }

        [Field("type")]
        public string Type { get; set; }

        [Field("color")]
        public string Color { get; set; }

        [Field("show_in_nav")]
        public bool? ShouldShowInNav { get; set; }

        [Field("default_lable")]
        public bool? IsDefaultLabel { get; set; }

        /// <value>The number of assets with this label.</value>
        [Field("assets_count")]
        public int? AssetsCount { get; private set; }

        [Field("notes")]
        public string Notes { get; set; }

        /// <inheritdoc />
        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <inheritdoc />
        [Field("available_actions")]
        public HashSet<AvailableAction> AvailableActions { get; set; }
    }
}
