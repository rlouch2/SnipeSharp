using SnipeSharp.Attributes;
using SnipeSharp.Common;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.Models
{
    [EndPointInformation(BaseUri: "manufacturers", NotFoundMessage: "Manufacturer not found")]
    public class Manufacturer : CommonEndpointModel
    {
        [DeserializeAs(Name = "url")]
        [SerializeAs(Name = "url")]
        public string Url { get; set; }

        [DeserializeAs(Name = "image")]
        public string Image { get; set; }

        [DeserializeAs(Name = "support_url")]
        [SerializeAs(Name = "support_url")]
        public string SupportUrl { get; set; }

        [DeserializeAs(Name = "support_phone")]
        [SerializeAs(Name = "support_phone")]
        public string SupportPhone { get; set; }

        [DeserializeAs(Name = "support_email")]
        [SerializeAs(Name = "support_email")]
        public string SupportEmail { get; set; }

        [DeserializeAs(Name = "assets_count")]
        public long AssetsCount { get; set; }

        [DeserializeAs(Name = "licenses_count")]
        public long LicensesCount { get; set; }
    }
}
