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
        public UserSearchColumn SortColumn { get; set; }

        /// <inheritdoc />
        [Field("order")]
        public SearchOrder? Order { get; set; }

        /// <summary>
        /// Search only deleted users.
        /// </summary>
        [Field("deleted", Converter = BoolStringConverter)]
        public bool? Deleted { get; set; }

        /// <summary>
        /// Only search for users that work for this company.
        /// </summary>
        [Field("company_id", Converter = CommonModelConverter)]
        public Company Company { get; set; }

        /// <summary>
        /// Only search for users at this location.
        /// </summary>
        [Field("location_id", Converter = CommonModelConverter)]
        public Location Location { get; set; }

        /// <summary>
        /// Only search for users in this group.
        /// </summary>
        [Field("group_id", Converter = CommonModelConverter)]
        public Group Group { get; set; }

        /// <summary>
        /// Only search for users in this department.
        /// </summary>
        [Field("department_id", Converter = CommonModelConverter)]
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
