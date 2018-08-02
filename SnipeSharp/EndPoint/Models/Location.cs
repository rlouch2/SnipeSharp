using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [PathSegment("locations")]
    public class Location : CommonEndPointModel
    {
        [Field("id")]
        public override int Id { get; set; }

        [Field("name", true)]
        public override string Name { get; set; }

        [Field("image", true)]
        public Uri ImageUri { get; set; }

        [Field("address", true)]
        public string Address { get; set; }

        [Field("address2", true)]
        public string Address2 { get; set; }

        [Field("city", true)]
        public string City { get; set; }

        [Field("state", true)]
        public string State { get; set; }

        [Field("country", true)]
        public string Country { get; set; }

        [Field("zip", true)]
        public string ZipCode { get; set; }

        [Field("assigned_assets_count")]
        public int? AssignedAssetsCount { get; set; }

        [Field("assets_count")]
        public int? AssetsCount { get; set; }

        [Field("users_count")]
        public int? UsersCount { get; set; }

        [Field("currency", true)]
        public string Currency { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; set; }

        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; set; }

        [Field("parent", "parent_id", converter: CommonModelConverter)]
        public Location ParentLocation { get; set; }

        [Field("manager", converter: CommonModelConverter)]
        public User Manager { get; set; }

        [Field("children")]
        public List<Location> ChildLocations { get; set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }

        [Field("ldap_ou", true)]
        public string LDAPOU { get; set; }
    }
}