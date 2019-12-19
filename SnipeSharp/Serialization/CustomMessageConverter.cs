using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SnipeSharp.Serialization
{
    /// <summary>
    /// Convert response messages to a dictionary matching the messages returned in Json
    /// </summary>
    internal sealed class CustomMessageConverter : JsonConverter
    {
        internal static readonly CustomMessageConverter Instance = new CustomMessageConverter();

        public override bool CanConvert(Type objectType)
            => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(reader.TokenType == JsonToken.String)
                return new Dictionary<string, string> { ["general"] = serializer.Deserialize<string>(reader) };
            return serializer.Deserialize<Dictionary<string, string>>(reader);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}

