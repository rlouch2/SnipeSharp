using SnipeSharp.Serialization;
using SnipeSharp.EndPoint.Models;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Filters
{
    /// <summary>
    /// A filter for assets, with no limit on sort column.
    /// </summary>
    public sealed class CustomAssetSearchFilter : ISortableSearchFilter<string>
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

        [Field("status_id", true, converter: CommonModelConverter)]
        public StatusLabel StatusLabel { get; set; }

        [Field("status", true)]
        public string Status { get; set; }

        [Field("requestable", true)]
        public bool? IsRequestable { get; set; }

        [Field("model_id", true, converter: CommonModelConverter)]
        public Model Model { get; set; }

        [Field("category_id", true, converter: CommonModelConverter)]
        public Category Category { get; set; }

        [Field("location_id", true, converter: CommonModelConverter)]
        public Location Location { get; set; }

        [Field("supplier_id", true, converter: CommonModelConverter)]
        public Supplier Supplier { get; set; }

        [Field("assigned_to", true, converter: CommonModelConverter)]
        public CommonEndPointModel AssignedTo { get; set; }

        [Field("assigned_type")]
        public AssignedToType AssignedToType { get; set; }

        [Field("company_id", true, converter: CommonModelConverter)]
        public Company Company { get; set; }

        [Field("manufacturer_id", true, converter: CommonModelConverter)]
        public Manufacturer Manufacturer { get; set; }

        [Field("depreciation_id", true, converter: CommonModelConverter)]
        public Depreciation Depreciation { get; set; }

        [Field("order_number", true)]
        public string OrderNumber { get; set; }

        public CustomAssetSearchFilter()
        {
        }

        public CustomAssetSearchFilter(string searchString)
        {
            Search = searchString;
        }
    }
}
