using SnipeSharp.Serialization;
using SnipeSharp.Models;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Filters
{
    /// <summary>
    /// A filter for manufacturers, featuring manufacturer-only search fields.
    /// </summary>
    public sealed class ManufacturerSearchFilter : ISortableSearchFilter<ManufacturerSearchColumn>
    {
        /// <inheritdoc />
        [Field("limit")]
        public int? Limit { get; set; }

        /// <inheritdoc />
        [Field("offset")]
        public int? Offset { get; set; }

        /// <inheritdoc />
        [Field("search")]
        public string Search { get; set; }

        /// <inheritdoc />
        [Field("sort")]
        public ManufacturerSearchColumn SortColumn { get; set; }

        /// <inheritdoc />
        [Field("order")]
        public SearchOrder? Order { get; set; }

        /// <summary>
        /// Search only deleted users.
        /// </summary>
        [Field("deleted", Converter = BoolStringConverter)]
        public bool? Deleted { get; set; }

        /// <summary>
        /// Initialize a new instance of the ManufacturerSearchFilter class.
        /// </summary>
        public ManufacturerSearchFilter()
        {
        }

        /// <summary>
        /// Initialize a new instance of the ManufacturerSearchFilter class with the specified search string.
        /// </summary>
        public ManufacturerSearchFilter(string searchString)
        {
            Search = searchString;
        }
    }
}
