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

        private StatusType _type = StatusType.Undeployable;
        
        /// <value>Indicates the type of label; valid values are <see cref="StatusType.Pending"/>, <see cref="StatusType.Deployable"/>, <see cref="StatusType.Undeployable"/> and <see cref="StatusType.Archived"/></value>
        [Field("type", true, required: true)]
        public StatusType? Type
        {
            get => _type;
            set
            {
                _type = value ?? StatusType.Undeployable;
                if(_type == StatusType.Deployed)
                    _type = StatusType.Deployable;
            }
        }

        /// <value>Gets if this label is of the Deployable type or not.</value>
        public bool IsDeployable => _type == StatusType.Deployable;

        /// <value>Gets if this label is of the Archived type or not.</value>
        public bool IsArchived => _type == StatusType.Archived;

        /// <value>Gets if this label is of the Pending type or not.</value>
        public bool IsPending => _type == StatusType.Pending;

        /// <value>The color of the lable in the web navigation.</value>
        [Field("color")]
        public string Color { get; private set; }

        /// <value>Whether or not this label shows in the web navigation.</value>
        [Field("show_in_nav")]
        public bool? ShouldShowInNav { get; private set; }

        /// <value>Whether or not this label is a default label.</value>
        [Field("default_lable")]
        public bool? IsDefaultLabel { get; private set; }

        /// <value>The number of assets with this label.</value>
        [Field("assets_count")]
        public int? AssetsCount { get; private set; }

        /// <value>Description of the label.</value>
        [Field("notes", true)]
        public string Notes { get; set; }

        /// <inheritdoc />
        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <inheritdoc />
        [Field("available_actions", converter: AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; set; }

        /// <summary>Converts this label into an AssetStatus, for use with Assets.</summary>
        public AssetStatus ToAssetStatus()
            => new AssetStatus { StatusId = Id, Name = Name, StatusType = Type };
    }
}
