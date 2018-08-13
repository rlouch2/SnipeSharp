using System.Collections.Generic;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.Serialization;

namespace SnipeSharp.EndPoint.Filters
{
    /// <summary>
    /// Implements ISortableSearchFilter. No fancy type-checking on the sorting column or anything here, just a plain old filter with custom field support if you want it.
    /// </summary>
    public sealed class SearchFilter : ISortableSearchFilter<string>, ICustomFields<object>
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

        /// <inheritdoc />
        public Dictionary<string, object> CustomFields { get; set; } = new Dictionary<string, object>();
        
        /// <summary>
        /// Instantiates a new SearchFilter.
        /// </summary>
        public SearchFilter()
        {
        }

        /// <summary>
        /// Instantiates a new SearchFilter with the supplied search string.
        /// </summary>
        /// <param name="searchString">A string to search for.</param>
        public SearchFilter(string searchString)
        {
            Search = searchString;
        }

        /// <summary>
        /// Adds a custom field to this filter.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        /// <param name="value">The value of the field.</param>
        /// <returns>A reference to this instance after the AddField operation has completed.</returns>
        public SearchFilter AddField(string name, object value)
        {
            CustomFields[name] = value;
            return this;
        }
    }
}
