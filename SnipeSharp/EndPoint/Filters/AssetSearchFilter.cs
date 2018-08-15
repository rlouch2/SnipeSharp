using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint.Models;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Filters
{
    /// <summary>
    /// A filter for assets, featuring asset-only search fields.
    /// </summary>
    public sealed class AssetSearchFilter : AbstractAssetSearchFilter, ISortableSearchFilter<AssetSearchColumn>
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
        public AssetSearchColumn SortColumn { get; set; }

        /// <inheritdoc />
        [Field("order", true)]
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
