using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using SnipeSharp.Serialization;
using System.Runtime.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(EnumJsonConverter<ApiResultStatus>))]
    public enum ApiResultStatus
    {
        Unknown = 0,

        [EnumMember(Value = Static.Result.SUCCESS)]
        Success,

        [EnumMember(Value = Static.Result.ERROR)]
        Error,
    }

    [JsonConverter(typeof(Serialization.SimpleApiResultConverter))]
    public class SimpleApiResult
    {
        public IReadOnlyDictionary<string, string> Messages { get; }
        public ApiResultStatus Status { get; }

        internal SimpleApiResult(ApiResultStatus status, IReadOnlyDictionary<string, string> messages)
        {
            Messages = messages;
            Status = status;
        }

        internal SimpleApiResult(ApiResult<object>? deserialized)
        {
            if(null == deserialized)
                throw new ArgumentNullException(nameof(deserialized));
            Status = deserialized.Status;
            Messages = deserialized.Messages;
        }
    }

    [JsonConverter(typeof(Serialization.ApiResultSerializerFactory))]
    public sealed class ApiResult<T>: SimpleApiResult
        where T: class?
    {
        public T? Payload { get; }

        internal ApiResult(ApiResultStatus status, T? payload, IReadOnlyDictionary<string, string> messages)
            : base(status, messages)
            => Payload = payload;

        public static implicit operator T?(ApiResult<T> self) => self.Payload;
    }

    internal static class ApiResultExtensions
    {
        internal static ApiResult<T> Validate<T>(this ApiResult<T> result) where T: class?
        {
            if(result.Status == ApiResultStatus.Unknown)
                throw new ArgumentException("Status cannot be unknown.", paramName: nameof(result.Status));
            return result;
        }
    }

    namespace Serialization
    {
        internal static class ApiResultHelpers
        {
            internal static Dictionary<string, string>? ConvertToDictionary(JsonElement a, JsonSerializerOptions options)
            {
                var props = a.ToObject<Dictionary<string, object>>(options);
                if(null == props)
                    return null;
                var dict = new Dictionary<string, string>();
                foreach(var pair in props)
                    dict[pair.Key] = pair.Value?.ToString() ?? string.Empty;
                return dict;
            }

            internal static Dictionary<string, string> ExtractMessageDictionary(IDictionary<string, JsonElement>? src, JsonSerializerOptions options)
            {
                if(null == src)
                    return new Dictionary<string, string>();
                var messageKey = src.Keys
                    .Where(key => key.ToLowerInvariant() == Static.Result.MESSAGES)
                    .FirstOrDefault();
                if(null == messageKey)
                    return new Dictionary<string, string>();
                var data = src[messageKey];
                if(JsonValueKind.String == data.ValueKind)
                    return new Dictionary<string, string>()
                    {
                        [Static.Result.GENERAL] = data.GetString() ?? throw new ArgumentNullException(
                            message: Static.Error.NULL_DESERIALIZING_STRING,
                            paramName: nameof(data))
                    };
                if(JsonValueKind.Object == data.ValueKind)
                    return ConvertToDictionary(data, options) ?? throw new ArgumentNullException(
                        message: Static.Error.NULL_DESERIALIZING_DICT,
                        paramName: nameof(data));
                throw new ArgumentException(Static.Error.UNKNOWN_MESSAGES_TYPE, paramName: nameof(src));
            }
        }

        internal sealed class ApiResultSerializerFactory : JsonConverterFactory
        {
            public override bool CanConvert(Type typeToConvert)
                => typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(ApiResult<>);

            public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
                => (JsonConverter?)Activator.CreateInstance(
                    typeof(ApiResultSerializer<>).MakeGenericType(typeToConvert.GetGenericArguments()),
                    BindingFlags.Public | BindingFlags.Instance,
                    binder: null, args: Array.Empty<object>(), culture: null);
        }

        internal sealed class PartialApiResult<T>
        {
            [JsonPropertyName(Static.Result.PAYLOAD)]
            public T? Payload { get; set; }

            [JsonPropertyName(Static.STATUS)]
            public ApiResultStatus Status { get; set; } = ApiResultStatus.Unknown;

            [JsonExtensionData]
            public IDictionary<string, JsonElement>? ExtensionData { get; set; }
        }

        internal sealed class ApiResultSerializer<T> : JsonConverter<ApiResult<T>>
            where T: class
        {
            public override ApiResult<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialApiResult<T>>(ref reader, options);
                if(null == partial)
                    return null;
                return new ApiResult<T>(
                    status: partial.Status,
                    payload: partial.Payload,
                    messages: ApiResultHelpers.ExtractMessageDictionary(partial.ExtensionData, options));
            }

            public override void Write(Utf8JsonWriter writer, ApiResult<T> value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }

        internal sealed class SimpleApiResultConverter : JsonConverter<SimpleApiResult>
        {
            public override SimpleApiResult? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialApiResult<object>>(ref reader, options);
                if(null == partial)
                    return null;
                return new SimpleApiResult(
                    status: partial.Status,
                    messages: ApiResultHelpers.ExtractMessageDictionary(partial.ExtensionData, options));
            }

            public override void Write(Utf8JsonWriter writer, SimpleApiResult value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }
    }
}
