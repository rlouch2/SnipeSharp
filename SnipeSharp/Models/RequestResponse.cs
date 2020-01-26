using System.Collections.Generic;
using SnipeSharp.Serialization;
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
        [DeserializeAs("messages", DeserializeAs.MessageDictionary)]
        public Dictionary<string, string> Messages { get; private set; } = new Dictionary<string, string>();

        /// <value>Gets the payload value.</value>
        [DeserializeAs("payload")]
        public T Payload { get; private set; } = null;

        /// <value>The status of the request; usually "success" or "error".</value>
        [DeserializeAs("status")]
        public string Status { get; private set; } = string.Empty;

        /// <inheritdoc />
        public override string ToString()
            => $"{Status}: {Messages.First().Value}";
    }
}
