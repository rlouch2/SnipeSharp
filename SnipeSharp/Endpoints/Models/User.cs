using SnipeSharp.Common;
using System.Collections.Generic;
using SnipeSharp.Attributes;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.Models
{
    [EndPointInformation(BaseUri: "users", NotFoundMessage: "User not found")]
    public class User : CommonEndpointModel
    {
        [DeserializeAs(Name = "name")]
        [SerializeAs(Name = "name")]
        public new string Name { get; set; }

        [DeserializeAs(Name = "accessories_count")]
        public long? AccessoriesCount { get; set; }

        [DeserializeAs(Name = "activated")]
        [SerializeAs(Name = "activated")]
        public bool Activated { get; set; }

        [DeserializeAs(Name = "address")]
        [SerializeAs(Name = "address")]
        public string Address { get; set; }

        [DeserializeAs(Name = "assets_count")]
        public long? AssetsCount { get; set; }

        [DeserializeAs(Name = "avatar")]
        public string Avatar { get; set; }

        [DeserializeAs(Name = "city")]
        [SerializeAs(Name = "city")]
        public string City { get; set; }

        [DeserializeAs(Name = "company")]
        [SerializeAs(Name = "company_id")]
        public Company Company { get; set; }

        [DeserializeAs(Name = "consumables_count")]
        public long ConsumablesCount { get; set; }

        [DeserializeAs(Name = "country")]
        [SerializeAs(Name = "country")]
        public string Country { get; set; }

        [DeserializeAs(Name = "email")]
        [SerializeAs(Name = "email")]
        public string Email { get; set; }

        [DeserializeAs(Name = "employee_num")]
        [SerializeAs(Name = "employee_num")]
        public string EmployeeNum { get; set; }

        [DeserializeAs(Name = "firstname")]
        [SerializeAs(Name = "first_name")]
        [RequiredField]
        public string Firstname { get; set; }

        [DeserializeAs(Name = "jobtitle")]
        [SerializeAs(Name = "jobtitle")]
        public string Jobtitle { get; set; }

        [DeserializeAs(Name = "last_login")]
        public ResponseDate LastLogin { get; set; }

        [DeserializeAs(Name = "lastname")]
        [SerializeAs(Name = "last_name")]
        public string Lastname { get; set; }

        [DeserializeAs(Name = "licenses_count")]
        public long? LicensesCount { get; set; }

        [DeserializeAs(Name = "location")]
        [SerializeAs(Name = "location_id")]
        public Location Location { get; set; }

        [DeserializeAs(Name = "manager")]
        [SerializeAs(Name = "manager_id")]
        public User Manager { get; set; }

        [DeserializeAs(Name = "notes")]
        [SerializeAs(Name = "notes")]
        public string Notes { get; set; }

        [DeserializeAs(Name = "permissions")]
        public Dictionary<string, string> Permissions { get; set; }

        [DeserializeAs(Name = "phone")]
        [SerializeAs(Name = "phone")]
        public string Phone { get; set; }

        [DeserializeAs(Name = "state")]
        [SerializeAs(Name = "state")]
        public string State { get; set; }

        [DeserializeAs(Name = "two_factor_activated")]
        public bool TwoFactorActivated { get; set; }

        [DeserializeAs(Name = "username")]
        [SerializeAs(Name = "username")]
        [RequiredField]
        public string Username { get; set; }

        [DeserializeAs(Name = "zip")]
        [SerializeAs(Name = "zip")]
        public object Zip { get; set; }

        [SerializeAs(Name = "password")]
        [RequiredField]
        public string Password { get; set; }

        [DeserializeAs(Name = "department")]
        [SerializeAs(Name = "department_id")]
        public Department Department { get; set; }
    }
}

