using SnipeSharp.Serialization;
using SnipeSharp.Models;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Filters
{
    /// <summary>
    /// A filter for assets, with no limit on sort column.
    /// </summary>
    public sealed class CustomAssetSearchFilter : AbstractAssetSearchFilter, ISortableSearchFilter<string>
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
        public string SortColumn { get; set; }

        /// <inheritdoc />
        [Field("order")]
        public SearchOrder? Order { get; set; }

        /// <summary>
        /// Initialize a new instance of the CustomAssetSearchFilter class.
        /// </summary>
        public CustomAssetSearchFilter()
        {
        }

        /// <summary>
        /// Initialize a new instance of the CustomAssetSearchFilter class with the specified search string.
        /// </summary>
        public CustomAssetSearchFilter(string searchString)
        {
            Search = searchString;
        }
    }
}
