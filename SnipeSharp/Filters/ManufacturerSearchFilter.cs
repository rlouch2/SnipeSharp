using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Filters
{
    /// <summary>
    /// A filter for manufacturers, featuring manufacturer-only search fields.
    /// </summary>
    public sealed class ManufacturerSearchFilter : ISortableSearchFilter<ManufacturerSearchColumn?>
    {
        /// <inheritdoc />
        [SerializeAs("limit")]
        public int? Limit { get; set; }

        /// <inheritdoc />
        [SerializeAs("offset")]
        public int? Offset { get; set; }

        /// <inheritdoc />
        [SerializeAs("search")]
        public string Search { get; set; }

        /// <inheritdoc />
        [SerializeAs("sort")]
        public ManufacturerSearchColumn? SortColumn { get; set; }

        /// <inheritdoc />
        [SerializeAs("order")]
        public SearchOrder? Order { get; set; }

        /// <summary>
        /// Search only deleted manufacturers.
        /// </summary>
        [SerializeAs("deleted")]
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
