using SnipeSharp.Attributes;
using SnipeSharp.Common;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.Models
{
    [EndPointInformation(BaseUri: "models", NotFoundMessage: "AssetModel not found")]
    public class Model : CommonEndpointModel
    {
        [DeserializeAs(Name = "manufacturer")]
        [SerializeAs(Name = "manufacturer_id")]
        [RequiredField]
        public Manufacturer Manufacturer { get; set; }

        [DeserializeAs(Name = "category")]
        [SerializeAs(Name = "category_id")]
        [RequiredField]
        public Category Category { get; set; }

        [DeserializeAs(Name = "image")]
        public string Image { get; set; }

        [DeserializeAs(Name = "model_number")]
        [SerializeAs(Name = "model_number")]
        public string ModelNumber { get; set; }

        [DeserializeAs(Name = "depreciation")]
        [SerializeAs(Name = "depreciation_id")]
        public Depreciation Depreciation { get; set; }

        [DeserializeAs(Name = "assets_count")]
        public long AssetsCount { get; set; }

        [DeserializeAs(Name = "eol")]
        [SerializeAs(Name = "eol")]
        public string Eol { get; set; }

        [DeserializeAs(Name = "notes")]
        [SerializeAs(Name = "notes")]
        public string Notes { get; set; }

        [DeserializeAs(Name = "fieldset")]
        [SerializeAs(Name = "fieldset_id")]
        public FieldSet FieldSet { get; set; }

        [DeserializeAs(Name = "deleted_at")]
        public ResponseDate DeletedAt { get; set; }
    }
}

