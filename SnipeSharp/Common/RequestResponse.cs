using Newtonsoft.Json;
using SnipeSharp.Endpoints.Models;
using SnipeSharp.JsonConverters;
using SnipeSharp.Serialization;
using System.Collections.Generic;
using System.Linq;
using RestSharp.Deserializers;

namespace SnipeSharp.Common
{
    public class RequestResponse : IRequestResponse
    {
        [DeserializeAs(Name = "messages")]
        [JsonConverter(typeof(CustomMessageConverter))]
        public Dictionary<string, string> Messages { get; set; }

        [DeserializeAs(Name = "payload")]
        [JsonConverter(typeof(DetectJsonObjectType))]
        public ICommonEndpointModel Payload { get; set; }

        [DeserializeAs(Name = "status")]
        public string Status { get; set; }

        public override string ToString()
        {
            return $"{Status}: {Messages.First().Value}";
        }
    }
}
