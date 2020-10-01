using System;
using System.Collections.Generic;
using RestSharp;
using SnipeSharp.Client;
using SnipeSharp.EndPoint;
using SnipeSharp.Exceptions;
using SnipeSharp.Models;

namespace SnipeSharp
{
    /// <summary>
    /// Wrapper for a Snipe-IT Api.
    /// </summary>
    public sealed class SnipeItApi
    {
        internal readonly ISnipeItClient Client;

        private string token;

        /// <summary>
        /// The Token property represent the API Token that will be used to authenticate with the Snipe-IT API found at the URI in <see cref="SnipeItApi.Uri">Uri</see>.
        /// </summary>
        /// <value>The Token property gets/sets the value of the string field, _token, and updates the token of the internal client.</value>
        public string Token
        {
            get => token;
            set => Client.Token = token = value;
        }

        private Uri uri;

        /// <summary>
        /// The Uri property represent the base Uri of the Snipe-IT API that will be used.
        /// </summary>
        /// <value>The Uri property gets/sets the value of the Uri field, _uri, and updates the base URI of the internal client.</value>
        public Uri Uri
        {
            get => uri;
            set => Client.Uri = uri = value;
        }

        /// <summary>
        /// <para>Tests if the Token and Uri are set and connect to the API.</para>
        /// <para>This method may produce false negatives if there are other issues with the network or computer.</para>
        /// </summary>
        /// <remarks>This method returns true if the user is able to access /users/me, or if they receive a 403 error from that endpoint.</remarks>
        /// <returns>If the API is accessible or not.</returns>
        public bool TestConnection()
        {
            if(!Client.HasUri)
                throw new NullApiUriException();
            if(!Client.HasToken)
                throw new NullApiTokenException();
            try
            {
                Users.Me();
            } catch
            {
                // any other error return false
                return false;
            }
            return true;
        }

        /// <summary>
        /// Stores a map from the known endpoint types to the endpoint objects, so they can be generically queried.
        /// </summary>
        private readonly IReadOnlyDictionary<Type, object> _typeEndPointObjectMap;

        /// <summary>
        /// Constructs or retrieves a cached EndPoint corresponding to the type parameter for use with interacting with the API.
        /// </summary>
        /// <typeparam name="T">A <see cref="SnipeSharp.Models.AbstractBaseModel">AbstractBaseModel</see> with the attribute <see cref="SnipeSharp.EndPoint.PathSegmentAttribute">PathSegmentAttribute</see>.</typeparam>
        /// <returns>An <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> for the provided type.</returns>
        public EndPoint<T> GetEndPoint<T>() where T: AbstractBaseModel
        {
            if(_typeEndPointObjectMap.TryGetValue(typeof(T), out var endpoint))
                return (EndPoint<T>)endpoint;
            throw new ArgumentException("Unrecognized end point type", nameof(T), null);
        }

        /// <value>
        /// Returns an <see cref="EndPoint.AccountEndPoint"/>.
        /// </value>
        public /* readonly */ AccountEndPoint Account { get; }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.Models.Asset">Assets</see>.
        /// </value>
        public /* readonly */ AssetEndPoint Assets { get; }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.Models.Accessory">Accessories</see>.
        /// </value>
        public /* readonly */ AccessoryEndPoint Accessories { get; }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.Models.Category">Categories</see>.
        /// </value>
        public /* readonly */ EndPoint<Category> Categories { get; }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.Models.Company">Companies</see>.
        /// </value>
        public /* readonly */ EndPoint<Company> Companies { get; }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.Models.Component">Components</see>.
        /// </value>
        public /* readonly */ ComponentEndPoint Components { get; }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.Models.Consumable">Consumables</see>.
        /// </value>
        public /* readonly */ EndPoint<Consumable> Consumables { get; }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.Models.CustomField">Custom fields</see>.
        /// </value>
        public /* readonly */ CustomFieldEndPoint CustomFields { get; }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.Models.Department">Departments</see>.
        /// </value>
        public /* readonly */ EndPoint<Department> Departments { get; }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.Models.Depreciation">Depreciations</see>.
        /// </value>
        public /* readonly */ EndPoint<Depreciation> Depreciations { get; }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.Models.FieldSet">Field sets</see>.
        /// </value>
        public /* readonly */ FieldSetEndPoint FieldSets { get; }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.Models.Group">Groups</see>.
        /// </value>
        public /* readonly */ EndPoint<Group> Groups { get; }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.Models.License">Licenses</see>.
        /// </value>
        public /* readonly */ LicenseEndPoint Licenses { get; }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.Models.Location">Locations</see>.
        /// </value>
        public /* readonly */ EndPoint<Location> Locations { get; }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.Models.Maintenance">Maintenances</see>.
        /// </value>
        public /* readonly */ EndPoint<Maintenance> Maintenances { get; }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.Models.Manufacturer">Manufacturers</see>.
        /// </value>
        public /* readonly */ EndPoint<Manufacturer> Manufacturers { get; }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.Models.Model">Models</see>.
        /// </value>
        public /* readonly */ EndPoint<Model> Models { get; }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.Models.StatusLabel">StatusLabels</see>.
        /// </value>
        public /* readonly */ StatusLabelEndPoint StatusLabels { get; }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.Models.Supplier">Suppliers</see>.
        /// </value>
        public /* readonly */ EndPoint<Supplier> Suppliers { get; }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.Models.User">Users</see>.
        /// </value>
        public /* readonly */ UserEndPoint Users { get; }

        /// <summary>
        /// <para>Constructs a wrapper for the Snipe-IT web API.</para>
        /// <para>The Token and Uri must be set either in an initializer or manually after construction.</para>
        /// </summary>
        public SnipeItApi() : this(new RestClient())
        {
        }

        public SnipeItApi(IRestClient restClient): this(new RestSharpClient(restClient))
        {
        }

        /// <summary>
        /// <para>Constructs a wrapper for the Snipe-IT web API.</para>
        /// <para>The Token and Uri must be set either in an initializer or manually after construction.</para>
        /// </summary>
        /// <remarks>This constructor is for internal and testing use.</remarks>
        internal SnipeItApi(ISnipeItClient client)
        {
            Client = client;

            // endpoints
            Account = new AccountEndPoint(this);
            Assets = new AssetEndPoint(this);
            Accessories = new AccessoryEndPoint(this);
            Categories = new EndPoint<Category>(this);
            Companies = new EndPoint<Company>(this);
            Components = new ComponentEndPoint(this);
            Consumables = new EndPoint<Consumable>(this);
            CustomFields = new CustomFieldEndPoint(this);
            Departments = new EndPoint<Department>(this);
            Depreciations = new EndPoint<Depreciation>(this);
            FieldSets = new FieldSetEndPoint(this);
            Groups = new EndPoint<Group>(this);
            Licenses = new LicenseEndPoint(this);
            Locations = new EndPoint<Location>(this);
            Maintenances = new EndPoint<Maintenance>(this);
            Manufacturers = new EndPoint<Manufacturer>(this);
            Models = new EndPoint<Model>(this);
            StatusLabels = new StatusLabelEndPoint(this);
            Suppliers = new EndPoint<Supplier>(this);
            Users = new UserEndPoint(this);

            // lookup map
            _typeEndPointObjectMap = new Dictionary<Type, object>
            {
                {typeof(Asset), Assets},
                {typeof(Accessory), Accessories},
                {typeof(Category), Categories},
                {typeof(Company), Companies},
                {typeof(Component), Components},
                {typeof(Consumable), Consumables},
                {typeof(CustomField), CustomFields},
                {typeof(Department), Departments},
                {typeof(Depreciation), Depreciations},
                {typeof(FieldSet), FieldSets},
                {typeof(Group), Groups},
                {typeof(License), Licenses},
                {typeof(Location), Locations},
                {typeof(Maintenance), Maintenances},
                {typeof(Manufacturer), Manufacturers},
                {typeof(Model), Models},
                {typeof(StatusLabel), StatusLabels},
                {typeof(Supplier), Suppliers},
                {typeof(User), Users}
            };
        }
    }
}
