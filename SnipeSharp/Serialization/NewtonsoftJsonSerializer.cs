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

        public static JsonSerializerSettings SerializerSettings { get; } =
            new JsonSerializerSettings {
                ContractResolver = new SerializationContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

        public static JsonSerializerSettings DeserializerSettings { get; } =
            new JsonSerializerSettings {
                ContractResolver = new DeserializationContractResolver()
            };

        public static JsonSerializer Serializer { get; } = JsonSerializer.CreateDefault(SerializerSettings);

        public string Serialize(object @object)
            => JsonConvert.SerializeObject(@object, SerializerSettings);

        public T Deserialize<T>(IRestResponse response)
            => JsonConvert.DeserializeObject<T>(response.Content, DeserializerSettings);
    }
}
