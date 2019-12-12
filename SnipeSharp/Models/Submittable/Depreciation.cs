using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A Depreciation.
    /// Depreciations are associated with objects and determine when End-Of-Life is relative to the PurchaseDate.
    /// </summary>
    [PathSegment("depreciations")]
    public sealed class Depreciation : CommonEndPointModel, IAvailableActions, IUpdatable<Depreciation>
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
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("name", IsRequired = true)]
        public override string Name { get; set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("months", Converter = MonthsConverter, IsRequired = true)]
        public int? Months { get; set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "created_at", Converter = DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "updated_at", Converter = DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        /// <inheritdoc />
        [Field(DeserializeAs = "available_actions", Converter = AvailableActionsConverter)]
        public HashSet<AvailableAction> AvailableActions { get; private set; }

        /// <inheritdoc />
        public Depreciation CloneForUpdate() => new Depreciation(this.Id);

        /// <inheritdoc />
        public Depreciation WithValuesFrom(Depreciation other)
            => new Depreciation(this.Id)
            {
                Name = other.Name,
                Months = other.Months
            };
    }
}
