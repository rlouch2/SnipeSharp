using SnipeSharp.Attributes;
using System.Linq;
using SnipeSharp.Exceptions;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.Models
{
    [EndPointInformation(BaseUri: "categories", NotFoundMessage: "Category not found")]
    public class Category : CommonEndpointModel
    {
        [DeserializeAs(Name = "image")]
        public string Image { get; set; }

        private string _type;

        [DeserializeAs(Name = "type")]
        [SerializeAs(Name = "category_type")]
        [RequiredField]
        public string Type
        { // TODO: We should probably remove this and rely on the API to say it's invalid
            get { return _type; }
            set
            {
                // TODO: Move this logic somewhere else
                string[] validTypes = { "asset", "accessory", "consumable", "component" };
                if (validTypes.Contains(value.ToLower()))
                {
                    _type = value;
                }
                else
                {
                    throw new InvalidCategoryTypeException($"{value} Is an invalid category type.  Use {string.Join(", ", validTypes)}");
                }
            }
        }

        [DeserializeAs(Name = "eula")]
        [SerializeAs(Name = "eula")]
        public bool eula { get; set; }

        [DeserializeAs(Name = "checkin_email")]
        [SerializeAs(Name = "checkin_email")]
        public bool CheckinEmail { get; set; }

        [DeserializeAs(Name = "require_acceptance")]
        [SerializeAs(Name = "required_acceptance")]
        public bool RequireAcceptance { get; set; }

        [DeserializeAs(Name = "assets_count")]
        public long? AssetsCount { get; set; }

        [DeserializeAs(Name = "accessories_count")]
        public long? AccessoriesCount { get; set; }

        [DeserializeAs(Name = "consumables_count")]
        public long? ConsumablesCount { get; set; }

        [DeserializeAs(Name = "components_count")]
        public long? ComponentsCount { get; set; }
    }
}
