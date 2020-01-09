using SnipeSharp.Serialization;
using SnipeSharp.Models;
using SnipeSharp.Models.Enumerations;
using static SnipeSharp.Serialization.FieldConverter;
using System.Collections.Generic;

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
        [Field("status_id", Converter = CommonModelConverter)]
        public StatusLabel StatusLabel { get; set; }

        /// <summary>
        /// The status meta, e.g. deployed, deleted, archived, etc.
        /// </summary>
        [Field("status")]
        public FilterStatusMeta? StatusMeta { get; set; }

        /// <summary>
        /// Only search for assets with that are requestable (or not).
        /// </summary>
        [Field("requestable")]
        public bool? IsRequestable { get; set; }

        /// <summary>
        /// Only search for assets of this model.
        /// </summary>
        [Field("model_id", Converter = CommonModelConverter)]
        public Model Model { get; set; }

        /// <summary>
        /// Only search for assets in this category.
        /// </summary>
        [Field("category_id", Converter = CommonModelConverter)]
        public Category Category { get; set; }

        /// <summary>
        /// Only search for assets at this location.
        /// </summary>
        [Field("location_id", Converter = CommonModelConverter)]
        public Location Location { get; set; }

        /// <summary>
        /// Only search for assets purchased from this supplier.
        /// </summary>
        [Field("supplier_id", Converter = CommonModelConverter)]
        public Supplier Supplier { get; set; }

        /// <summary>
        /// Only search for assets assigned to this user/asset/location.
        /// </summary>
        [Field("assigned_to", Converter = CommonModelConverter)]
        public CommonEndPointModel AssignedTo { get; set; }

        /// <summary>
        /// Only search for assets assigned to this type (user, asset, or location).
        /// </summary>
        [Field("assigned_type")]
        public AssignedToType? AssignedToType { get; set; } = null;

        /// <summary>
        /// Only search for assets owned by this company.
        /// </summary>
        [Field("company_id", Converter = CommonModelConverter)]
        public Company Company { get; set; }

        /// <summary>
        /// Only search for assets built by this manufacturer.
        /// </summary>
        [Field("manufacturer_id", Converter = CommonModelConverter)]
        public Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// Only search for assets with this depreciation.
        /// </summary>
        [Field("depreciation_id", Converter = CommonModelConverter)]
        public Depreciation Depreciation { get; set; }

        /// <summary>
        /// Only search for assets from this order.
        /// </summary>
        [Field("order_number")]
        public string OrderNumber { get; set; }

        /// <summary>Additional filtering by custom fields using exact column names as keys.</summary>
        public Dictionary<string, string> CustomFields { get; set; } = new Dictionary<string, string>();

        /// <summary>Internal serialization dictionary for <see cref="CustomFields"/>.</summary>
        [Field("filter")]
        protected Dictionary<string, string> _customFields { get; set; } = null;

        internal AbstractAssetSearchFilter()
        {
        }
    }
}
