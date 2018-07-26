using Newtonsoft.Json;
using SnipeSharp.JsonConverters;
using System.Collections.Generic;
using System.Linq;
using RestSharp.Deserializers;

namespace SnipeSharp.EndPoint.Models
{
    public class RequestResponse: ApiObject
    {
        [DeserializeAs(Name = "messages")]
        [JsonConverter(typeof(MessageConverter))]
        public Dictionary<string, string> Messages { get; set; }

        [DeserializeAs(Name = "payload")]
        [JsonConverter(typeof(DetectJsonObjectType))]
        public CommonEndPointModel Payload { get; set; }

        [DeserializeAs(Name = "status")]
        public string Status { get; set; }

        public override string ToString()
        {
            return $"{Status}: {Messages.First().Value}";
        }
    }
}
