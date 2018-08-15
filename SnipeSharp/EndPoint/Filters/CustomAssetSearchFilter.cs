using SnipeSharp.Serialization;
using SnipeSharp.EndPoint.Models;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Filters
{
    /// <summary>
    /// A filter for assets, with no limit on sort column.
    /// </summary>
    public sealed class CustomAssetSearchFilter : AbstractAssetSearchFilter, ISortableSearchFilter<string>
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
        public string SortColumn { get; set; }

        /// <inheritdoc />
        [Field("order", true)]
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
