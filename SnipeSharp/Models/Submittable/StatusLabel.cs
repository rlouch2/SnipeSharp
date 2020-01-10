using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A Status label.
    /// Status labels are used out to organize Assets and manage their state.
    /// </summary>
    [PathSegment("statuslabels")]
    public sealed class StatusLabel : CommonEndPointModel, IAvailableActions, IUpdatable<StatusLabel>
    {
        /// <summary>Create a new StatusLabel object.</summary>
        public StatusLabel() { }

        /// <summary>Create a new StatusLabel object with the supplied ID, for use with updating.</summary>
        internal StatusLabel(int id)
        {
            Id = id;
        }

        /// <inheritdoc />
        [Field(DeserializeAs = "id")]
        public override int Id { get; set; }

        /// <inheritdoc />
        /// <remarks>This field is required and must have a unique value.</remarks>
        [Field("name", IsRequired = true)]
        public override string Name { get; set; }

        private StatusType _type = StatusType.Undeployable;

        /// <value>Indicates the type of label; valid values are <see cref="StatusType.Pending"/>, <see cref="StatusType.Deployable"/>, <see cref="StatusType.Undeployable"/> and <see cref="StatusType.Archived"/></value>
        [Field("type", IsRequired = true)]
        public StatusType? Type
        {
            get => _type;
            set => _type = value ?? StatusType.Undeployable;
        }

        /// <value>Gets if this label is of the Deployable type or not.</value>
        public bool IsDeployable => _type == StatusType.Deployable;

        /// <value>Gets if this label is of the Archived type or not.</value>
        public bool IsArchived => _type == StatusType.Archived;

        /// <value>Gets if this label is of the Pending type or not.</value>
        public bool IsPending => _type == StatusType.Pending;

        /// <value>The color of the lable in the web navigation.</value>
        [Field(DeserializeAs = "color")]
        public string Color { get; private set; }

        /// <value>Whether or not this label shows in the web navigation.</value>
        [Field(DeserializeAs = "show_in_nav")]
        public bool? ShouldShowInNav { get; private set; }

        /// <value>Whether or not this label is a default label.</value>
        [Field(DeserializeAs = "default_lable")]
        public bool? IsDefaultLabel { get; private set; }

        /// <value>The number of assets with this label.</value>
        [Field(DeserializeAs = "assets_count")]
        public int? AssetsCount { get; private set; }

        /// <value>Description of the label.</value>
        [Field("notes")]
        public string Notes { get; set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public AvailableAction AvailableActions { get; private set; }

        /// <summary>Converts this label into an AssetStatus, for use with Assets.</summary>
        public AssetStatus ToAssetStatus()
            => new AssetStatus { StatusId = Id, Name = Name, StatusType = Type };

        /// <inheritdoc />
        public StatusLabel CloneForUpdate() => new StatusLabel(this.Id);

        /// <inheritdoc />
        public StatusLabel WithValuesFrom(StatusLabel other)
            => new StatusLabel(this.Id)
            {
                Name = other.Name,
                Type = other.Type,
                Notes = other.Notes
            };
    }
}
