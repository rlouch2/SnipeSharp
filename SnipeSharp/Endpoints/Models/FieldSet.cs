using SnipeSharp.Attributes;
using SnipeSharp.Common;
using Newtonsoft.Json;

namespace SnipeSharp.Endpoints.Models
{
    [EndPointInformation(BaseUri: "fieldsets", NotFoundMessage: "Fieldset does not exist")]
    public class FieldSet : CommonEndpointModel
    {
        [JsonProperty("fields")]
        public ResponseCollection<CustomField> Fields { get; set; }

        [JsonProperty("models")]
        public ResponseCollection<Model> Models { get; set; }
    }
}
