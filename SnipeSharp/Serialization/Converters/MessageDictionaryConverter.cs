using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SnipeSharp.Serialization.Converters
{
    /// <summary>
    /// Convert response messages to a dictionary matching the messages returned in Json
    /// </summary>
    internal sealed class MessageDictionaryConverter : JsonConverter<Dictionary<string, string>>
    {
        internal static readonly MessageDictionaryConverter Instance = new MessageDictionaryConverter();

        public override Dictionary<string, string> ReadJson(JsonReader reader, Type objectType, Dictionary<string, string> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if(reader.TokenType == JsonToken.String)
                return new Dictionary<string, string> { ["general"] = serializer.Deserialize<string>(reader) };
            return serializer.Deserialize<Dictionary<string, string>>(reader);
        }

        public override void WriteJson(JsonWriter writer, Dictionary<string, string> value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}

