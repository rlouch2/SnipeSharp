using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint.Models;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Filters
{
    /// <summary>
    /// A filter for accessories, featuring accessory-only search fields.
    /// </summary>
    public sealed class AccessorySearchFilter : ISortableSearchFilter<AccessorySearchColumn>
    {
        /// <inheritdoc />
        [Field("limit", true)]
        public int? Limit { get; set; }

        /// <inheritdoc />
        [Field("offset", true)]
        public int? Offset { get; set; }

        /// <inheritdoc />
        [Field("search", true)]
        public string Search { get; set; }

        /// <inheritdoc />
        [Field("sort", true)]
        public AccessorySearchColumn SortColumn { get; set; }

        /// <inheritdoc />
        [Field("order", true)]
        public SearchOrder? Order { get; set; }

        /// <summary>
        /// Only search for accessories owned by this Company if set.
        /// </summary>
        [Field("company_id", true, converter: CommonModelConverter)]
        public Company Company { get; set; }

        /// <summary>
        /// Only search for accessories in this category if set.
        /// </summary>
        [Field("category_id", true, converter: CommonModelConverter)]
        public Category Category { get; set; }

        /// <summary>
        /// Only search for accessories by this manufacturer if set.
        /// </summary>
        [Field("manufacturer_id", true, converter: CommonModelConverter)]
        public Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// Only search for accessories by this supplier if set.
        /// </summary>
        [Field("supplier_id", true, converter: CommonModelConverter)]
        public Supplier Supplier { get; set; }

        /// <summary>
        /// Create a new search filter with no search parameters.
        /// </summary>
        public AccessorySearchFilter()
        {
        }

        /// <summary>
        /// Create a new search filter with a search parameter.
        /// </summary>
        /// <param name="searchString">The value to search for.</param>
        public AccessorySearchFilter(string searchString)
        {
            Search = searchString;
        }
    }
}
