using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;
using System.Runtime.Serialization;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A Status label.
    /// Status labels are used out to organize Assets and manage their state.
    /// </summary>
    [PathSegment("statuslabels")]
    public sealed class StatusLabel : CommonEndPointModel, IAvailableActions, IPatchable
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
        [Patch(nameof(isNameModified))]
        public override string Name
        {
            get => name;
            set
            {
                isNameModified = true;
                name = value;
            }
        }
        private bool isNameModified = false;
        private string name;

        /// <value>Indicates the type of label; valid values are <see cref="StatusType.Pending"/>, <see cref="StatusType.Deployable"/>, <see cref="StatusType.Undeployable"/> and <see cref="StatusType.Archived"/></value>
        [Field("type", IsRequired = true)]
        [Patch(nameof(isTypeModified))]
        public StatusType? Type
        {
            get => type;
            set
            {
                isTypeModified = true;
                type = value ?? StatusType.Undeployable;
            }
        }
        private bool isTypeModified = false;
        private StatusType type;

        /// <value>Gets if this label is of the Deployable type or not.</value>
        public bool IsDeployable => type == StatusType.Deployable;

        /// <value>Gets if this label is of the Archived type or not.</value>
        public bool IsArchived => type == StatusType.Archived;

        /// <value>Gets if this label is of the Pending type or not.</value>
        public bool IsPending => type == StatusType.Pending;

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
        [Patch(nameof(isNotesModified))]
        public string Notes
        {
            get => notes;
            set
            {
                isNotesModified = true;
                notes = value;
            }
        }
        private bool isNotesModified = false;
        private string notes;

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

        void IPatchable.SetAllModifiedState(bool isModified)
        {
            isNameModified = isModified;
            isTypeModified = isModified;
            isNotesModified = isModified;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            ((IPatchable)this).SetAllModifiedState(false);
        }
    }
}
