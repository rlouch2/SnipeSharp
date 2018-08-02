using System;
using System.Collections.Generic;
using System.Linq;
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
            var results = new Dictionary<string, string>();
            var token = JToken.Load(reader);

            if(token.Type == JTokenType.String)
                results["general"] = token.ToObject<string>();
            else if(token.Type == JTokenType.Object)
                foreach (JProperty subToken in token)
                    results[subToken.Name] = subToken.Value[0].ToString();
            return results;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}

