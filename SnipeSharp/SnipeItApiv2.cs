using System;
using System.Collections.Generic;
using System.IO;
using RestSharp;
using SnipeSharp.EndPoint;
using SnipeSharp.EndPoint.Models;

namespace SnipeSharp
{
    public sealed class SnipeItApiv2
    {
        private string _token;
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

        public EndPoint<T> GetEndPoint<T>() where T: CommonEndPointModel
        {
            var type = typeof(T);
            if(!endpoints.ContainsKey(type))
                endpoints[type] = new EndPoint<T>(this);
            return endpoints[type] as EndPoint<T>;
        }

        public EndPoint<Asset> Assets => GetEndPoint<Asset>();
        public EndPoint<Accessory> Accessories => GetEndPoint<Accessory>();
        public EndPoint<Category> Categories => GetEndPoint<Category>();
        public EndPoint<Company> Companies => GetEndPoint<Company>();
        public EndPoint<Component> Components => GetEndPoint<Component>();
        public EndPoint<Consumable> Consumables => GetEndPoint<Consumable>();
        public EndPoint<CustomField> CustomFields => GetEndPoint<CustomField>();
        public EndPoint<Department> Departments => GetEndPoint<Department>();
        public EndPoint<Depreciation> Depreciations => GetEndPoint<Depreciation>();
        public EndPoint<FieldSet> FieldSets => GetEndPoint<FieldSet>();
        public EndPoint<Group> Groups => GetEndPoint<Group>();
        public EndPoint<License> Licenses => GetEndPoint<License>();
        public EndPoint<Location> Locations => GetEndPoint<Location>();
        public EndPoint<Maintenance> Maintenances => GetEndPoint<Maintenance>();
        public EndPoint<Manufacturer> Manufacturers => GetEndPoint<Manufacturer>();
        public EndPoint<Model> Models => GetEndPoint<Model>();
        public EndPoint<StatusLabel> StatusLabels => GetEndPoint<StatusLabel>();
        public EndPoint<Supplier> Suppliers => GetEndPoint<Supplier>();
        public EndPoint<User> Users => GetEndPoint<User>();

        public SnipeItApiv2()
        {
            RequestManager = new RestClientManager(this);
        }

        internal SnipeItApiv2(IRestClient client)
        {
            RequestManager = new RestClientManager(this, client);
        }
    }
}
