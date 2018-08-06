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
    [CreationConverter(typeof(StatusLabelCreationConverter))]
    public sealed class StatusLabel : CommonEndPointModel, IAvailableActions
    {
        /// <inheritdoc />
        [Field("id")]
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required and must have a unique value.</remarks>
        [Field("name", true, required: true)]
        [CreationField("name", required: true)]
        public override string Name { get; set; }

        private StatusType _type = StatusType.Undeployable;
        
        /// <value>Indicates the type of label; valid values are <see cref="StatusType.Pending"/>, <see cref="StatusType.Deployable"/>, <see cref="StatusType.Undeployable"/> and <see cref="StatusType.Archived"/></value>
        /// <remarks>To set this value, use <see cref="IsDeployable"/>, <see cref="IsPending"/>, and <see cref="IsArchived"/>.</remarks>
        [Field("type")]
        [CreationField("type", required: true)]
        public StatusType? Type
        {
            get => _type;
            internal set
            {
                _type = value ?? StatusType.Undeployable;
                _isDeployable = _type == StatusType.Deployable;
                _isPending = _type == StatusType.Pending;
                _isArchived = _type == StatusType.Archived;
            }
        }

        private bool _isDeployable = false;
        private bool _isArchived = false;
        private bool _isPending = false;

        /// <value>Gets/sets if this label is of the Deployable type or not.</value>
        /// <remarks>Also updates IsArchived, IsPending, and Type.</remarks>
        [Field("deployable", true)]
        public bool IsDeployable
        {
            get => _isDeployable;
            set
            {
                _isDeployable = value;
                if(_isDeployable)
                {
                    _isArchived = false;
                    _isPending = false;
                    _type = StatusType.Deployable;
                } else if(_type == StatusType.Deployable)
                {
                    _type = StatusType.Undeployable;
                }
            }
        }

        /// <value>Gets/sets if this label is of the Archived type or not.</value>
        /// <remarks>Also updates IsDeployable, IsPending, and Type.</remarks>
        [Field("archived", true)]
        public bool IsArchived
        {
            get => _isArchived;
            set
            {
                _isArchived = value;
                if(_isArchived)
                {
                    _isDeployable = false;
                    _isPending = false;
                    _type = StatusType.Archived;
                } else if(_type == StatusType.Archived)
                {
                    _type = StatusType.Undeployable;
                }
            }
        }

        /// <value>Gets/sets if this label is of the Pending type or not.</value>
        /// <remarks>Also updates IsArchived, IsDeployable, and Type.</remarks>
        [Field("pending", true)]
        public bool IsPending
        {
            get => _isPending;
            set
            {
                _isPending = value;
                if(_isPending)
                {
                    _isArchived = false;
                    _isDeployable = false;
                    _type = StatusType.Pending;
                } else if(_type == StatusType.Pending)
                {
                    _type = StatusType.Undeployable;
                }
            }
        }

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
        [CreationField("notes")]
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
    }
}
