using SnipeSharp.Common;
using SnipeSharp.Attributes;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.Models
{
    [EndPointInformation(BaseUri: "suppliers", NotFoundMessage: "Supplier not found")]
    public class Supplier : CommonEndpointModel
    {
        [DeserializeAs(Name = "name")]
        [SerializeAs(Name = "name")]
        public new string Name { get; set; }

        [SerializeAs(Name = "address")]
        [DeserializeAs(Name = "address")]
        public string Address { get; set; }

        [SerializeAs(Name = "city")]
        [DeserializeAs(Name = "city")]
        public string City { get; set; }

        [SerializeAs(Name = "state")]
        [DeserializeAs(Name = "state")]
        public string State { get; set; }

        [SerializeAs(Name = "country")]
        [DeserializeAs(Name = "country")]
        public string Country { get; set; }

        [SerializeAs(Name = "zip")]
        [DeserializeAs(Name = "zip")]
        public string Zip { get; set; }

        [SerializeAs(Name = "fax")]
        [DeserializeAs(Name = "fax")]
        public string Fax { get; set; }

        [SerializeAs(Name = "phone")]
        [DeserializeAs(Name = "phone")]
        public string Phone { get; set; }

        [SerializeAs(Name = "email")]
        [DeserializeAs(Name = "email")]
        public string Email { get; set; }

        [SerializeAs(Name = "contact")]
        [DeserializeAs(Name = "contact")]
        public string Contact { get; set; }

        [SerializeAs(Name = "notes")]
        [DeserializeAs(Name = "notes")]
        public string Notes { get; set; }
    }
}
