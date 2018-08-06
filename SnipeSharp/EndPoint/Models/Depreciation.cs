using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// A Depreciation.
    /// Depreciations are associated with objects and determine when End-Of-Life is relative to the PurchaseDate.
    /// </summary>
    [PathSegment("depreciations")]
    public sealed class Depreciation : CommonEndPointModel, IAvailableActions
    {
        /// <inheritdoc />
        [Field("id")]
        public override int Id { get; protected set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("name", true, required: true)]
        public override string Name { get; set; }

        /// <inheritdoc />
        /// <remarks>This field is required.</remarks>
        [Field("months", true, converter: MonthsConverter, required: true)]
        public int? Months { get; set; }

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
