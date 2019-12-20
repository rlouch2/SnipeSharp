using System;
using System.Collections.Generic;
using SnipeSharp.Models;
using SnipeSharp.Serialization;

namespace SnipeSharp.Filters
{
    /// <summary>
    /// Implements ISortableSearchFilter. No fancy type-checking on the sorting column or anything here, just a plain old filter with custom field support if you want it.
    /// </summary>
    public sealed class SearchFilter : ISortableSearchFilter<string>
    {
        /// <inheritdoc />
        [Field("limit")]
        public int? Limit { get; set; }

        /// <inheritdoc />
        [Field("offset")]
        public int? Offset { get; set; }

        /// <summary>Backing field for <see cref="Search"/>.</summary>
        private string _SearchString;
        /// <inheritdoc />
        /// <exception cref="System.ArgumentNullException">If attempting to set a null value.</exception>
        [Field("search")]
        public string Search {
            get => _SearchString;
            set
            {
                if(null == value)
                    throw new ArgumentNullException(paramName: nameof(value));
                _SearchString = value;
            }
        }

        /// <inheritdoc />
        [Field("sort")]
        public string SortColumn { get; set; }

        /// <inheritdoc />
        [Field("order")]
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
        /// <exception cref="System.ArgumentNullException">If <paramref name="searchString"/> is null.</exception>
        public SearchFilter(string searchString)
        {
            if(null == searchString)
                throw new ArgumentNullException(paramName: nameof(searchString));
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
