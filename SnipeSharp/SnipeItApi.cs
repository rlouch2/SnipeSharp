using System;
using System.Collections.Generic;
using System.IO;
using RestSharp;
using SnipeSharp.EndPoint;
using SnipeSharp.EndPoint.Models;
using Newtonsoft.Json;
using SnipeSharp.Serialization;

namespace SnipeSharp
{
    /// <summary>
    /// Wrapper for a Snipe-IT Api.
    /// </summary>
    public sealed class SnipeItApi
    {
        private string _token;

        /// <summary>
        /// The Token property represent the API Token that will be used to authenticate with the Snipe-IT API found at the URI in <see cref="SnipeItApi.Uri">Uri</see>.
        /// </summary>
        /// <value>The Token property gets/sets the value of the string field, _token, and resets the token in the <see cref="RequestManager">RequestManager</see> when changed.</value>
        public string Token
        {
            get => _token;
            set
            {
                _token = value;
                RequestManager.ResetToken();
            }
        }

        private Uri _uri;

        /// <summary>
        /// The Uri property represent the base Uri of the Snipe-IT API that will be used.
        /// </summary>
        /// <value>The Uri property gets/sets the value of the Uri field, _uri, and resets the URI in the <see cref="RequestManager">RequestManager</see> when changed.</value>
        public Uri Uri
        {
            get => _uri;
            set
            {
                _uri = value;
                RequestManager.ResetUri();
            }
        }

        internal readonly RestClientManager RequestManager;

        private Dictionary<Type, object> endpoints = new Dictionary<Type, object>();

        /// <summary>
        /// <para>Tests if the Token and Uri are set and connect to the API.</para>
        /// <para>This method may produce false negatives if there are other issues with the network or computer.</para>
        /// </summary>
        /// <returns>If the API is accessible or not.</returns>
        public bool TestConnection()
        {
            try
            {
                RequestManager.SetTokenAndUri();
                Users.Me();
            } catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Constructs or retrieves a cached EndPoint corresponding to the type parameter for use with interacting with the API.
        /// </summary>
        /// <typeparam name="T">A <see cref="SnipeSharp.EndPoint.Models.CommonEndPointModel">CommonEndPointModel</see> with the attribute <see cref="SnipeSharp.EndPoint.PathSegmentAttribute">PathSegmentAttribute</see>.</typeparam>
        /// <returns>An <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> for the provided type.</returns>
        public EndPoint<T> GetEndPoint<T>() where T: CommonEndPointModel
        {
            var type = typeof(T);
            if(!endpoints.ContainsKey(type))
                endpoints[type] = new EndPoint<T>(this);
            return endpoints[type] as EndPoint<T>;
        }

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.EndPoint.Models.Asset">Assets</see>.
        /// </value>
        public EndPoint<Asset> Assets => GetEndPoint<Asset>();

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.EndPoint.Models.Accessory">Accessories</see>.
        /// </value>
        public EndPoint<Accessory> Accessories => GetEndPoint<Accessory>();

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.EndPoint.Models.Category">Categories</see>.
        /// </value>
        public EndPoint<Category> Categories => GetEndPoint<Category>();

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.EndPoint.Models.Company">Companies</see>.
        /// </value>
        public EndPoint<Company> Companies => GetEndPoint<Company>();

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.EndPoint.Models.Component">Components</see>.
        /// </value>
        public EndPoint<Component> Components => GetEndPoint<Component>();

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.EndPoint.Models.Consumable">Consumables</see>.
        /// </value>
        public EndPoint<Consumable> Consumables => GetEndPoint<Consumable>();

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.EndPoint.Models.CustomField">Custom fields</see>.
        /// </value>
        public EndPoint<CustomField> CustomFields => GetEndPoint<CustomField>();

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.EndPoint.Models.Department">Departments</see>.
        /// </value>
        public EndPoint<Department> Departments => GetEndPoint<Department>();

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.EndPoint.Models.Depreciation">Depreciations</see>.
        /// </value>
        public EndPoint<Depreciation> Depreciations => GetEndPoint<Depreciation>();

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.EndPoint.Models.FieldSet">Field sets</see>.
        /// </value>
        public EndPoint<FieldSet> FieldSets => GetEndPoint<FieldSet>();

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.EndPoint.Models.Group">Groups</see>.
        /// </value>
        public EndPoint<Group> Groups => GetEndPoint<Group>();

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.EndPoint.Models.License">Licenses</see>.
        /// </value>
        public EndPoint<License> Licenses => GetEndPoint<License>();

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.EndPoint.Models.Location">Locations</see>.
        /// </value>
        public EndPoint<Location> Locations => GetEndPoint<Location>();

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.EndPoint.Models.Maintenance">Maintenances</see>.
        /// </value>
        public EndPoint<Maintenance> Maintenances => GetEndPoint<Maintenance>();

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.EndPoint.Models.Manufacturer">Manufacturers</see>.
        /// </value>
        public EndPoint<Manufacturer> Manufacturers => GetEndPoint<Manufacturer>();

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.EndPoint.Models.Model">Models</see>.
        /// </value>
        public EndPoint<Model> Models => GetEndPoint<Model>();

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.EndPoint.Models.StatusLabel">StatusLabels</see>.
        /// </value>
        public EndPoint<StatusLabel> StatusLabels => GetEndPoint<StatusLabel>();

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.EndPoint.Models.Supplier">Suppliers</see>.
        /// </value>
        public EndPoint<Supplier> Suppliers => GetEndPoint<Supplier>();

        /// <value>
        /// Returns an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see> suitable for <see cref="SnipeSharp.EndPoint.Models.User">Users</see>.
        /// </value>
        public EndPoint<User> Users => GetEndPoint<User>();

        /// <summary>
        /// <para>Constructs a wrapper for the Snipe-IT web API.</para>
        /// <para>The Token and Uri must be set either in an initializer or manually after construction.</para>
        /// </summary>
        public SnipeItApi()
        {
            RequestManager = new RestClientManager(this);
        }

        /// <summary>
        /// <para>Constructs a wrapper for the Snipe-IT web API using the specified IRestClient for use in testing.</para>
        /// <para>The Token and Uri must be set either in an initializer or manually after construction.</para>
        /// </summary>
        /// <param name="client">An IRestClient subclass instance.</param>
        internal SnipeItApi(IRestClient client)
        {
            RequestManager = new RestClientManager(this, client);
        }

        public string Serialize(object @object)
            => RequestManager.Serialize(@object);
    }
}
