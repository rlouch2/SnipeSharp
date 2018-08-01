using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [EndPointInformation("locations", "")]
    public class Location : CommonEndPointModel
    {
        [Field("id")]
        public override int Id { get; set; }

        [Field("name")]
        public override string Name { get; set; }

        [Field("image")]
        public Uri ImageUri { get; set; }

        [Field("address")]
        public string Address { get; set; }

        [Field("address2")]
        public string Address2 { get; set; }

        [Field("city")]
        public string City { get; set; }

        [Field("state")]
        public string State { get; set; }

        [Field("country")]
        public string Country { get; set; }

        [Field("zip")]
        public string ZipCode { get; set; }

        [Field("assigned_assets_count")]
        public int? AssignedAssetsCount { get; set; }

        [Field("assets_count")]
        public int? AssetsCount { get; set; }

        [Field("users_count")]
        public int? UsersCount { get; set; }

        [Field("currency")]
        public string Currency { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; set; }

        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; set; }

        [Field("parent", converter: CommonModelConverter)]
        public Location ParentLocation { get; set; }

        [Field("manager", converter: CommonModelConverter)]
        public User Manager { get; set; }

        [Field("children")]
        public List<Location> ChildLocations { get; set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }
}