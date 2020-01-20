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
    /// A Depreciation.
    /// Depreciations are associated with objects and determine when End-Of-Life is relative to the PurchaseDate.
    /// </summary>
    [PathSegment("depreciations")]
    public sealed class Depreciation : CommonEndPointModel, IAvailableActions, IPatchable
    {
        /// <summary>Create a new Depreciation object.</summary>
        public Depreciation() { }

        /// <summary>Create a new Depreciation object with the supplied ID, for use with updating.</summary>
        internal Depreciation(int id)
        {
            Id = id;
        }

        /// <inheritdoc />
        [Field(DeserializeAs = "id")]
        public override int Id { get; set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
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

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("months", Converter = MonthsConverter, IsRequired = true)]
        [Patch(nameof(isMonthsModified))]
        public int? Months
        {
            get => months;
            set
            {
                isMonthsModified = true;
                months = value;
            }
        }
        private bool isMonthsModified = false;
        private int? months;

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public AvailableAction AvailableActions { get; private set; }

        void IPatchable.SetAllModifiedState(bool isModified)
        {
            isNameModified = isModified;
            isMonthsModified = isModified;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            ((IPatchable)this).SetAllModifiedState(false);
        }
    }
}
