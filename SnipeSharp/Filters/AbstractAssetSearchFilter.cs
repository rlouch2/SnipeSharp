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
        [SerializeAs("status_id", CommonModelConverter)]
        public StatusLabel StatusLabel { get; set; }

        /// <summary>
        /// The status meta, e.g. deployed, deleted, archived, etc.
        /// </summary>
        [SerializeAs("status")]
        public FilterStatusMeta? StatusMeta { get; set; }

        /// <summary>
        /// Only search for assets with that are requestable (or not).
        /// </summary>
        [SerializeAs("requestable")]
        public bool? IsRequestable { get; set; }

        /// <summary>
        /// Only search for assets of this model.
        /// </summary>
        [SerializeAs("model_id", CommonModelConverter)]
        public Model Model { get; set; }

        /// <summary>
        /// Only search for assets in this category.
        /// </summary>
        [SerializeAs("category_id", CommonModelConverter)]
        public Category Category { get; set; }

        /// <summary>
        /// Only search for assets at this location.
        /// </summary>
        [SerializeAs("location_id", CommonModelConverter)]
        public Location Location { get; set; }

        /// <summary>
        /// Only search for assets purchased from this supplier.
        /// </summary>
        [SerializeAs("supplier_id", CommonModelConverter)]
        public Supplier Supplier { get; set; }

        /// <summary>
        /// Only search for assets assigned to this user/asset/location.
        /// </summary>
        [SerializeAs("assigned_to", CommonModelConverter)]
        public CommonEndPointModel AssignedTo { get; set; }

        /// <summary>
        /// Only search for assets assigned to this type (user, asset, or location).
        /// </summary>
        [SerializeAs("assigned_type")]
        public AssignedToType? AssignedToType { get; set; } = null;

        /// <summary>
        /// Only search for assets owned by this company.
        /// </summary>
        [SerializeAs("company_id", CommonModelConverter)]
        public Company Company { get; set; }

        /// <summary>
        /// Only search for assets built by this manufacturer.
        /// </summary>
        [SerializeAs("manufacturer_id", CommonModelConverter)]
        public Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// Only search for assets with this depreciation.
        /// </summary>
        [SerializeAs("depreciation_id", CommonModelConverter)]
        public Depreciation Depreciation { get; set; }

        /// <summary>
        /// Only search for assets from this order.
        /// </summary>
        [SerializeAs("order_number")]
        public string OrderNumber { get; set; }

        /// <summary>Additional filtering by custom fields using exact column names as keys.</summary>
        public Dictionary<string, string> CustomFields { get; set; } = new Dictionary<string, string>();

        /// <summary>Internal serialization dictionary for <see cref="CustomFields"/>.</summary>
        [SerializeAs("filter")]
        protected Dictionary<string, string> _customFields { get; set; } = null;

        internal AbstractAssetSearchFilter()
        {
        }
    }
}
