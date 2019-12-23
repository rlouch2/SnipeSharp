using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;
using System.Linq;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A response from the API, which may indicate success or error, have messages, and possibly have a payload.
    /// </summary>
    /// <typeparam name="T">The payload type.</typeparam>
    public sealed class RequestResponse<T>: ApiObject where T: ApiObject
    {
        /// <value>Any messages returned by the API; the default key is "general".</value>
        [Field(DeserializeAs = "messages", Converter = MessagesConverter)]
        public Dictionary<string, string> Messages { get; private set; } = new Dictionary<string, string>();

        /// <value>Gets the payload value.</value>
        [Field(DeserializeAs = "payload")]
        public T Payload { get; private set; } = null;

        /// <value>The status of the request; usually "success" or "error".</value>
        [Field(DeserializeAs = "status")]
        public string Status { get; private set; } = string.Empty;

        /// <inheritdoc />
        public override string ToString()
            => $"{Status}: {Messages.First().Value}";
    }
}
