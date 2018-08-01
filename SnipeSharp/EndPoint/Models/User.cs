using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [EndPointInformation("users", "")]
    public class User : CommonEndPointModel
    {
        [Field("id")]
        public override long Id { get; set; }

        [Field("gravatar")]
        public Uri AvatarUrl { get; set; }

        [Field("name")]
        public override string Name { get; set; }

        [Field("first_name")]
        public string FirstName { get; set; }

        [Field("last_name")]
        public string LastName { get; set; }

        [Field("username")]
        public string UserName { get; set; }

        [Field("employee_num")]
        public string EmployeeNumber { get; set; }

        [Field("manager", converter: CommonModelConverter)]
        public User Manager { get; set; }

        [Field("jobtitle")]
        public string JobTitle { get; set; }

        [Field("phone")]
        public string PhoneNumber { get; set; }

        [Field("address")]
        public string Address { get; set; }

        [Field("city")]
        public string City { get; set; }

        [Field("state")]
        public string State { get; set; }

        [Field("country")]
        public string Country { get; set; }

        [Field("zip")]
        public string ZipCode { get; set; }

        [Field("email")]
        public string EmailAddress { get; set; }

        [Field("department", converter: CommonModelConverter)]
        public Department Department { get; set; }

        [Field("location", converter: CommonModelConverter)]
        public Location Location { get; set; }

        [Field("notes")]
        public string Notes { get; set; }

        [Field("permissions", converter: PermissionsConverter)]
        public Dictionary<string, bool> Permissions { get; set; }

        [Field("activated")]
        public bool? IsActivated { get; set; }

        [Field("two_factor_activated")]
        public bool? IsTwoFactorActivated { get; set; }

        [Field("assets_count")]
        public int? AssetsCount { get; set; }

        [Field("licenses_count")]
        public int? LicensesCount { get; set; }

        [Field("accessories_count")]
        public int? AccessoriesCount { get; set; }

        [Field("consumables_count")]
        public int? ConsumablesCount { get; set; }

        [Field("company", converter: CommonModelConverter)]
        public Company Company { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; set; }

        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; set; }

        [Field("last_login", converter: DateTimeConverter)]
        public DateTime? LastLogin { get; set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }

        [Field("groups")]
        public ResponseCollection<Group> Groups { get; set; }
    }
}