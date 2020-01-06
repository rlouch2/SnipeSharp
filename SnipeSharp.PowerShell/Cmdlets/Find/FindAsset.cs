using System.Management.Automation;
using SnipeSharp.Models;
using SnipeSharp.Models.Enumerations;
using SnipeSharp.Filters;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Finds a Snipe IT asset.</summary>
    /// <remarks>The Find-Asset cmdlet finds asset objects by filter.</remarks>
    /// <example>
    ///   <code>Find-Asset</code>
    ///   <para>Finds all assets.</para>
    /// </example>
    /// <example>
    ///   <code>Find-Asset "PotatoPeeler"</code>
    ///   <para>Finds assets that match the search string "PotatoPeeler".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Find, nameof(Asset), SupportsPaging = true, DefaultParameterSetName = nameof(FindAsset.ParameterSets.Default))]
    [OutputType(typeof(Asset))]
    public class FindAsset: FindObject<Asset, AssetSearchColumn, AssetSearchFilter>
    {
        internal enum ParameterSets
        {
            AssignedToUser,
            AssignedToLocation,
            AssignedToAsset,
            Default
        }

        /// <summary>
        /// Only search for assets with this status.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ObjectBinding<StatusLabel> StatusLabel { get; set; }

        /// <summary>
        /// Filter by status meta, e.g. Deployed or Archived or Requestable.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public FilterStatusMeta StatusMeta { get; set; }

        /// <summary>
        /// Only search for assets with that are requestable (or not).
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public bool IsRequestable { get; set; }

        /// <summary>
        /// Only search for assets of this model.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ObjectBinding<Model> Model { get; set; }

        /// <summary>
        /// Only search for assets in this category.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ObjectBinding<Category> Category { get; set; }

        /// <summary>
        /// Only search for assets at this location.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ObjectBinding<Location> Location { get; set; }

        /// <summary>
        /// Only search for assets purchased from this supplier.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ObjectBinding<Supplier> Supplier { get; set; }

        /// <summary>
        /// Only search for assets owned by this company.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ObjectBinding<Company> Company { get; set; }

        /// <summary>
        /// Only search for assets built by this manufacturer.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ObjectBinding<Manufacturer> Manufacturer { get; set; }

        /// <summary>
        /// Only search for assets with this depreciation.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public ObjectBinding<Depreciation> Depreciation { get; set; }

        /// <summary>
        /// Only search for assets from this order.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateIdentityNotNull]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Only search for assets assigned to this user.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = nameof(ParameterSets.AssignedToUser))]
        [ValidateIdentityNotNull]
        public UserBinding AssignedUser { get; set; }

        /// <summary>
        /// Only search for assets assigned to this location.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = nameof(ParameterSets.AssignedToLocation))]
        [ValidateIdentityNotNull]
        public ObjectBinding<Location> AssignedLocation { get; set; }

        /// <summary>
        /// Only search for assets assigned to this asset.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = nameof(ParameterSets.AssignedToAsset))]
        [ValidateIdentityNotNull]
        public AssetBinding AssignedAsset { get; set; }

        /// <inheritdoc />
        protected override bool PopulateFilter(AssetSearchFilter filter)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(StatusLabel)))
            {
                if(!this.GetSingleValue(StatusLabel, out var statusLabel))
                    return false;
                filter.StatusLabel = statusLabel;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Model)))
            {
                if(!this.GetSingleValue(Model, out var model))
                    return false;
                filter.Model = model;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Category)))
            {
                if (!this.GetSingleValue(Category, out var category))
                    return false;
                filter.Category = category;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
            {
                if(!this.GetSingleValue(Location, out var location))
                    return false;
                filter.Location = location;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Supplier)))
            {
                if(!this.GetSingleValue(Supplier, out var supplier))
                    return false;
                filter.Supplier = supplier;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
            {
                if(!this.GetSingleValue(Company, out var company))
                    return false;
                filter.Company = company;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Manufacturer)))
            {
                if(!this.GetSingleValue(Manufacturer, out var manufacturer))
                    return false;
                filter.Manufacturer = manufacturer;
            }
            if (MyInvocation.BoundParameters.ContainsKey(nameof(Depreciation)))
            {
                if(!this.GetSingleValue(Depreciation, out var depreciation))
                    return false;
                filter.Depreciation = depreciation;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(StatusMeta)))
                filter.StatusMeta = StatusMeta;
            if (MyInvocation.BoundParameters.ContainsKey(nameof(IsRequestable)))
                filter.IsRequestable = IsRequestable;
            if (MyInvocation.BoundParameters.ContainsKey(nameof(OrderNumber)))
                filter.OrderNumber = OrderNumber;
            switch(ParameterSetName)
            {
                case nameof(ParameterSets.AssignedToAsset):
                    if (!this.GetSingleValue(AssignedAsset, out var assignedAsset))
                        return false;
                    filter.AssignedTo = assignedAsset;
                    filter.AssignedToType = AssignedToType.Asset;
                    break;
                case nameof(ParameterSets.AssignedToLocation):
                    if (!this.GetSingleValue(AssignedLocation, out var assignedLocation))
                        return false;
                    filter.AssignedTo = assignedLocation;
                    filter.AssignedToType = AssignedToType.Location;
                    break;
                case nameof(ParameterSets.AssignedToUser):
                    if (!this.GetSingleValue(AssignedLocation, out var assignedUser))
                        return false;
                    filter.AssignedTo = assignedUser;
                    filter.AssignedToType = AssignedToType.User;
                    break;
                default:
                    break;
            }
            return true;
        }
    }
}
