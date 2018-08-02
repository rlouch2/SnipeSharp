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

        public string Serialize(object @object)
        {
            var settings = new JsonSerializerSettings {
                ContractResolver = SerializationContractResolver.Instance,
                NullValueHandling = NullValueHandling.Ignore
            };
            settings.Converters.Add(LiftCustomFieldsCollectionConverter.Instance);
            return JsonConvert.SerializeObject(@object, settings);
        }
        public T Deserialize<T>(IRestResponse response)
        {
            var settings = new JsonSerializerSettings {
                ContractResolver = DeserializationContractResolver.Instance
            };
            return JsonConvert.DeserializeObject<T>(response.Content, settings);
        }
    }
}
