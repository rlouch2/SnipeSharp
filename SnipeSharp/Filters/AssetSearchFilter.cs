using System.Collections.Generic;
using System.Runtime.Serialization;
using SnipeSharp.Serialization;

namespace SnipeSharp.Filters
{
    /// <summary>
    /// A filter for assets, featuring asset-only search fields.
    /// </summary>
    public sealed class AssetSearchFilter : AbstractAssetSearchFilter, ISortableSearchFilter<AssetSearchColumn?>
    {
        /// <inheritdoc />
        [Field("limit")]
        public int? Limit { get; set; } = null;

        /// <inheritdoc />
        [Field("offset")]
        public int? Offset { get; set; } = null;

        /// <inheritdoc />
        [Field("search")]
        public string Search { get; set; }

        /// <inheritdoc />
        [Field("sort")]
        public AssetSearchColumn? SortColumn { get; set; } = null;

        /// <inheritdoc />
        [Field("order")]
        public SearchOrder? Order { get; set; } = null;

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

        /// <summary>
        /// Adds a custom field to this filter.
        /// </summary>
        /// <remarks>These will be passed as a dictionary under the "filter" key.</remarks>
        /// <param name="name">The name of the field. This is the column name, not the friendly name.</param>
        /// <param name="value">The value of the field.</param>
        /// <returns>A reference to this instance after the AddField operation has completed.</returns>
        public AssetSearchFilter AddField(string name, string value)
        {
            CustomFields[name] = value;
            return this;
        }

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            if(null != CustomFields && CustomFields.Count > 0)
                _customFields = CustomFields;
        }
    }
}
