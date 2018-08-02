using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;
using System.Linq;

namespace SnipeSharp.EndPoint.Models
{
    public class RequestResponse<T>: ApiObject where T: ApiObject
    {
        [Field("messages", converter: MessagesConverter)]
        public Dictionary<string, string> Messages { get; set; }

        [Field("payload")]
        public T Payload { get; set; }

        [Field("status")]
        public string Status { get; set; }

        public override string ToString()
            => $"{Status}: {Messages.First().Value}";
    }
}

