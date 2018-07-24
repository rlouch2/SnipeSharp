using SnipeSharp.Attributes;
using SnipeSharp.Common;
using System.Collections.Generic;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.Models
{
    [EndPointInformation(BaseUri: "locations", NotFoundMessage: "Location not found")]
    public class Location : CommonEndpointModel
    {
        [DeserializeAs(Name = "image")]
        public string Image { get; set; }

        [DeserializeAs(Name = "address")]
        [SerializeAs(Name = "address")]
        public string Address { get; set; }

        [DeserializeAs(Name = "city")]
        public string City { get; set; }

        [DeserializeAs(Name = "state")]
        [SerializeAs(Name = "state")]
        public string State { get; set; }

        [DeserializeAs(Name = "country")]
        [SerializeAs(Name = "country")]
        public string Country { get; set; }

        [DeserializeAs(Name = "zip")]
        [SerializeAs(Name = "zip")]
        public string Zip { get; set; }

        [DeserializeAs(Name = "assets_count")]
        public long? AssetsCount { get; set; }

        [DeserializeAs(Name = "users_count")]
        public long? UsersCount { get; set; }

        [DeserializeAs(Name = "parent")]
        [SerializeAs(Name = "parent_id")]
        public Location Parent { get; set; }

        [DeserializeAs(Name = "manager")]
        public User Manager { get; set; }

        [DeserializeAs(Name = "children")]
        public List<Location> Children { get; set; }
    }
}
