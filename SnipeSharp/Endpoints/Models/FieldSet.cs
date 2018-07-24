using SnipeSharp.Attributes;
using SnipeSharp.Common;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.Models
{
    [EndPointInformation(BaseUri: "fieldsets", NotFoundMessage: "Fieldset does not exist")]
    public class FieldSet : CommonEndpointModel
    {
        [DeserializeAs(Name = "fields")]
        public ResponseCollection<CustomField> Fields { get; set; }

        [DeserializeAs(Name = "models")]
        public ResponseCollection<Model> Models { get; set; }
    }
}
