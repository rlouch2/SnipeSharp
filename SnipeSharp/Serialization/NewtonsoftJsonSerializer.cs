using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;
using RestSharp.Deserializers;

namespace SnipeSharp.Serialization
{
    internal sealed class NewtonsoftJsonSerializer : ISerializer, IDeserializer
    {
        public string ContentType { get; set; } = "application/json";
        public string DateFormat { get; set; }
        public string RootElement { get; set; }
        public string Namespace { get; set; }

        private readonly JsonSerializerSettings serializerSettings;
        private readonly JsonSerializerSettings deserializerSettings;

        public string Serialize(object @object)
            => JsonConvert.SerializeObject(@object, serializerSettings);
        
        public T Deserialize<T>(IRestResponse response)
            => JsonConvert.DeserializeObject<T>(response.Content, deserializerSettings);

        public NewtonsoftJsonSerializer()
        {
            serializerSettings = new JsonSerializerSettings {
                ContractResolver = SerializationContractResolver.Instance,
                NullValueHandling = NullValueHandling.Ignore
            };
            serializerSettings.Converters.Add(AssetLiftCustomFieldsCollectionConverter.Instance);
            serializerSettings.Converters.Add(ObjectLiftCustomFieldsCollectionConverter.Instance);
            deserializerSettings = new JsonSerializerSettings {
                ContractResolver = DeserializationContractResolver.Instance
            };
        }
    }
}
