using System.Collections.Generic;
using SnipeSharp.Serialization;
using SnipeSharp.Models;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Filters
{
    /// <summary>
    /// Base class with common fields for the asset search filters.
    /// </summary>
    public abstract class AbstractAssetSearchFilter
    {
        /// <summary>
        /// Only search for assets with this status label.
        /// </summary>
        [Field("status_id", true, converter: CommonModelConverter)]
        public StatusLabel StatusLabel { get; set; }

        /// <summary>
        /// Only search for assets with this status.
        /// </summary>
        [Field("status", true)]
        public string Status { get; set; }

        /// <summary>
        /// Only search for assets with that are requestable (or not).
        /// </summary>
        [Field("requestable", true)]
        public bool? IsRequestable { get; set; }

        /// <summary>
        /// Only search for assets of this model.
        /// </summary>
        [Field("model_id", true, converter: CommonModelConverter)]
        public Model Model { get; set; }

        /// <summary>
        /// Only search for assets in this category.
        /// </summary>
        [Field("category_id", true, converter: CommonModelConverter)]
        public Category Category { get; set; }

        /// <summary>
        /// Only search for assets at this location.
        /// </summary>
        [Field("location_id", true, converter: CommonModelConverter)]
        public Location Location { get; set; }

        /// <summary>
        /// Only search for assets purchased from this supplier.
        /// </summary>
        [Field("supplier_id", true, converter: CommonModelConverter)]
        public Supplier Supplier { get; set; }

        /// <summary>
        /// Only search for assets assigned to this user/asset/location.
        /// </summary>
        [Field("assigned_to", true, converter: CommonModelConverter)]
        public CommonEndPointModel AssignedTo { get; set; }

        /// <summary>
        /// Only search for assets assigned to this type (user, asset, or location).
        /// </summary>
        [Field("assigned_type")]
        public AssignedToType AssignedToType { get; set; }

        /// <summary>
        /// Only search for assets owned by this company.
        /// </summary>
        [Field("company_id", true, converter: CommonModelConverter)]
        public Company Company { get; set; }

        /// <summary>
        /// Only search for assets built by this manufacturer.
        /// </summary>
        [Field("manufacturer_id", true, converter: CommonModelConverter)]
        public Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// Only search for assets with this depreciation.
        /// </summary>
        [Field("depreciation_id", true, converter: CommonModelConverter)]
        public Depreciation Depreciation { get; set; }

        /// <summary>
        /// Only search for assets from this order.
        /// </summary>
        [Field("order_number", true)]
        public string OrderNumber { get; set; }

        internal AbstractAssetSearchFilter()
        {
        }
    }
}