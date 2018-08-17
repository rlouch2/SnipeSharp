using SnipeSharp.Serialization;
using SnipeSharp.Models;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Filters
{
    /// <summary>
    /// A filter for users, featuring user-only search fields.
    /// </summary>
    public sealed class UserSearchFilter : ISortableSearchFilter<UserSearchColumn>
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
        public UserSearchColumn SortColumn { get; set; }

        /// <inheritdoc />
        [Field("order", true)]
        public SearchOrder? Order { get; set; }

        /// <summary>
        /// Include deleted users when searching.
        /// </summary>
        [Field("deleted", true)]
        public bool? IncludeDeleted { get; set; }

        /// <summary>
        /// Only search for users that work for this company.
        /// </summary>
        [Field("company_id", true, converter: CommonModelConverter)]
        public Company Company { get; set; }

        /// <summary>
        /// Only search for users at this location.
        /// </summary>
        [Field("location_id", true, converter: CommonModelConverter)]
        public Location Location { get; set; }

        /// <summary>
        /// Only search for users in this group.
        /// </summary>
        [Field("group_id", true, converter: CommonModelConverter)]
        public Group Group { get; set; }

        /// <summary>
        /// Only search for users in this department.
        /// </summary>
        [Field("department_id", true, converter: CommonModelConverter)]
        public Department Department { get; set; }

        /// <summary>
        /// Initialize a new instance of the UserSearchFilter class.
        /// </summary>
        public UserSearchFilter()
        {
        }

        /// <summary>
        /// Initialize a new instance of the UserSearchFilter class with the specified search string.
        /// </summary>
        public UserSearchFilter(string searchString)
        {
            Search = searchString;
        }
    }
}
