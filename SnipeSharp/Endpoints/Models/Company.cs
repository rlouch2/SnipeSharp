using SnipeSharp.Attributes;
using SnipeSharp.Common;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.Models
{
    [EndPointInformation(BaseUri: "companies", NotFoundMessage: "Company not found")]
    public class Company : CommonEndpointModel
    {
        [DeserializeAs(Name = "image")]
        public string Image { get; set; }

        [DeserializeAs(Name = "assets_count")]
        public long? AssetsCount { get; set; }

        [DeserializeAs(Name = "licenses_count")]
        public long? LicensesCount { get; set; }

        [DeserializeAs(Name = "accessories_count")]
        public long? AccessoriesCount { get; set; }

        [DeserializeAs(Name = "consumables_count")]
        public long? ConsumablesCount { get; set; }

        [DeserializeAs(Name = "components_count")]
        public long? ComponentsCount { get; set; }

        [DeserializeAs(Name = "users_count")]
        public long? UsersCount { get; set; }
    }
}

