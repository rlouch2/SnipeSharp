using SnipeSharp.Common;
using SnipeSharp.Attributes;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.Models
{
    [EndPointInformation(BaseUri: "depreciations", NotFoundMessage: "Depreciation not found")]
    public class Depreciation : CommonEndpointModel
    {
        private string _months;

        [DeserializeAs(Name = "months")]
        [SerializeAs(Name = "months")]
        [RequiredField]
        public string Months
        {
            get
            {
                return _months;
            }
            set
            {
                _months = (value != null) ? value : null;
            }
        }
    }
}

