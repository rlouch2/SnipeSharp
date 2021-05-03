using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnipeSharp.Exceptions
{
    public class ApiHttpException: Exception
    {
        public readonly string MessageContent;
        public readonly HttpStatusCode StatusCode;
        public ApiHttpException(HttpStatusCode status, string message)
        {
            StatusCode = status;
            MessageContent = message;
        }

        public string? ExtractErrorMessage()
            => JsonSerializer.Deserialize<ApiErrorMessage>(MessageContent)?.Error;
    }

    internal sealed class ApiErrorMessage {
        [JsonPropertyName("error")]
        public string? Error { get; set; }
    }
}
