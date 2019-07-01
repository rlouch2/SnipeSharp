using SnipeSharp.Serialization;

namespace SnipeSharp.Filters
{
    /// <summary>
    /// A filter for assets, featuring asset-only search fields.
    /// </summary>
    public sealed class AssetSearchFilter : AbstractAssetSearchFilter, ISortableSearchFilter<AssetSearchColumn>
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
        public AssetSearchColumn SortColumn { get; set; }

        /// <inheritdoc />
        [Field("order")]
        public SearchOrder? Order { get; set; }

        /// <summary>
        /// Initialize a new instance of the AssetSearchFilter class.
        /// </summary>
        public AssetSearchFilter()
        {
        }

        /// <summary>
        /// Initialize a new instance of the AssetSearchFilter class with the specified search string.
        /// </summary>
        public AssetSearchFilter(string searchString)
        {
            Search = searchString;
        }
    }
}
