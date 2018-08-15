using System.Collections.Generic;

namespace SnipeSharp.Filters
{
    /// <summary>
    /// The untyped search filter interface, for filtering collections in the API.
    /// </summary>
    public interface ISearchFilter
    {
        /// <summary>
        /// The number of items to return in a single request. By default 50.
        /// </summary>
        /// <remarks>For optimum performance, try not to exceed 1000.</remarks>
        int? Limit { get; set; }

        /// <summary>
        /// The number of items to skip before taking the limit; for use in pagination and getting more than 1000 objects at once.
        /// </summary>
        int? Offset { get; set; }

        /// <summary>
        /// A filter string that will be used to search various fields.
        /// </summary>
        string Search { get; set; }
    }
}
