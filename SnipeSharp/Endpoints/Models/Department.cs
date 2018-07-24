using SnipeSharp.Common;
using SnipeSharp.Attributes;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.Models
{
    [EndPointInformation(BaseUri: "departments", NotFoundMessage: "Department not found")]
    public class Department : CommonEndpointModel
    {
        [DeserializeAs(Name = "company_id")]
        [SerializeAs(Name = "company_id")]
        public Company Company { get; set; }

        [DeserializeAs(Name = "manager")]
        [SerializeAs(Name = "manager_id")]
        public User Manager { get; set; }

        [DeserializeAs(Name = "location")]
        [SerializeAs(Name = "location_id")]
        public Location Location { get; set; }
    }
}
