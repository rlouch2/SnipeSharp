using RestSharp.Serializers;
using Newtonsoft.Json;

namespace SnipeSharp.Common
{
    internal class SnipeITJsonSerializer : ISerializer
    {
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
        public string ContentType { get; set; } = "application/json";

        public string Serialize(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}