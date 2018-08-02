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
            => JsonConvert.SerializeObject(@object, new JsonSerializerSettings {
                ContractResolver = SerializationContractResolver.Instance,
                NullValueHandling = NullValueHandling.Ignore
            });
        public T Deserialize<T>(IRestResponse response)
            => JsonConvert.DeserializeObject<T>(response.Content, new JsonSerializerSettings {
                ContractResolver = DeserializationContractResolver.Instance
            });
    }
}
