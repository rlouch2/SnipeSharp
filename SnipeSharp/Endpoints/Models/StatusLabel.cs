using SnipeSharp.Attributes;
using SnipeSharp.Common;
using System.Linq;
using SnipeSharp.Exceptions;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.Models
{
    [EndPointInformation(BaseUri: "statuslabels", NotFoundMessage: "Statuslabel not found")]
    public class StatusLabel : CommonEndpointModel
    {
        private string _type;

        [DeserializeAs(Name = "type")]
        [SerializeAs(Name = "type")]
        [RequiredField]
        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                // TODO: Move this logic somewhere else
                string[] validTypes = { "deployable", "pending", "archived" };
                if (validTypes.Contains(value.ToLower()))
                {
                    _type = value;
                } else
                {
                    throw new InvalidStatusLabelTypeException($"{value} Is an invalid status lable.  Use {string.Join(", ", validTypes)}");
                }
            }
        }

        [DeserializeAs(Name = "color")]
        [SerializeAs(Name = "color")]
        public string Color { get; set; }

        [DeserializeAs(Name = "show_in_nav")]
        [SerializeAs(Name = "show_in_nav")]
        public bool ShowInNav { get; set; }

        [DeserializeAs(Name = "assets_count")]
        public long? AssetsCount { get; set; }

        [DeserializeAs(Name = "notes")]
        [SerializeAs(Name = "notes")]
        public string Notes { get; set; }

        [SerializeAs(Name = "deployable")]
        [RequiredField]
        public bool Deployable { get; set; }

        [SerializeAs(Name = "pending")]
        [RequiredField]
        public bool Pending { get; set; }

        [SerializeAs(Name = "archived")]
        [RequiredField]
        public bool Archived { get; set; }
    }
}

