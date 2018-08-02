using System.Collections.Generic;

namespace SnipeSharp.EndPoint.Filters
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

    /// <summary>
    /// The typed search filter interface, for filtering collections in the API and sorting the based on a column.
    /// </summary>
    /// <typeparam name="T">The sort column type; for example, an enumeration, or a string.</typeparam>
    public interface ISortableSearchFilter<T>: ISearchFilter
    {
        /// <summary>
        /// The column to sort on.
        /// </summary>
        /// <remarks>This should be converted to a string during serialization. If implementing your own, be sure to set the JsonConverter to StringEnumConverter and add EnumMember values to all members.</remarks>
        T SortColumn { get; set; }

        /// <summary>
        /// Whether to sort the request in ascending or descending order based on the sort column (by default the creaetion date).
        /// </summary>
        SearchOrder Order { get; set; }
    }
}
