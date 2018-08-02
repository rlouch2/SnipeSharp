using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.EndPoint.Models;
using static SnipeSharp.Serialization.FieldConverter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SnipeSharp.EndPoint.Filters
{
    /// <summary>
    /// A filter for accessories, featuring accessory-only search fields.
    /// </summary>
    public sealed class AccessorySearchFilter : ISortableSearchFilter<AccessorySearchColumn>
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
        public AccessorySearchColumn SortColumn { get; set; }

        /// <inheritdoc />
        [Field("order", true)]
        public SearchOrder Order { get; set; }

        /// <summary>
        /// Only search for accessories owned by this Company if set.
        /// </summary>
        [Field("company_id", true, converter: CommonModelConverter)]
        public Company Company { get; set; }

        /// <summary>
        /// Only search for accessories in this category if set.
        /// </summary>
        [Field("category_id", true, converter: CommonModelConverter)]
        public Category Category { get; set; }

        /// <summary>
        /// Only search for accessories by this manufacturer if set.
        /// </summary>
        [Field("manufacturer_id", true, converter: CommonModelConverter)]
        public Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// Only search for accessories by this supplier if set.
        /// </summary>
        [Field("supplier_id", true, converter: CommonModelConverter)]
        public Supplier Supplier { get; set; }

        /// <summary>
        /// Create a new search filter with no search parameters.
        /// </summary>
        public AccessorySearchFilter()
        {
        }

        /// <summary>
        /// Create a new search filter with a search parameter.
        /// </summary>
        /// <param name="searchString">The value to search for.</param>
        public AccessorySearchFilter(string searchString)
        {
            Search = searchString;
        }
    }

    /// <summary>
    /// Columns an Accessory search can be sorted on.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccessorySearchColumn
    {
        /// <summary>The internal Id number.</summary>
        [EnumMember(Value = "id")]
        Id,
        /// <summary>The name of the accessory.</summary>
        [EnumMember(Value = "name")]
        Name,
        /// <summary>The model number of the accessory.</summary>
        [EnumMember(Value = "model_number")]
        ModelNumber,
        /// <summary>The category of the accessory.</summary>
        /// <remarks>This value, while there is special code for it in the API, does not actually work as it is not a listed sortable column for Accessories.</remarks>
        [EnumMember(Value = "category")]
        Category,
        /// <summary>The creation date of the accessory.</summary>
        [EnumMember(Value = "created_at")]
        CreatedAt,
        /// <summary>The minimum amount of accessories left before a warning is given.</summary>
        [EnumMember(Value = "min_amt")]
        MinimumQuantity,
        /// <summary>The Id of the Company.</summary>
        [EnumMember(Value = "company_id")]
        CompanyId,
        /// <summary>The Company that owns the Asset.</summary>
        /// <remarks>
        /// <para>This value, while there is special code for it in the API, does not actually work as it is not a listed sortable column for Accessories.</para>
        /// <para>Use <see cref="CompanyId">CompanyId</see> instead.</para>
        /// </remarks>
        [EnumMember(Value = "company")]
        Company
    }
}
