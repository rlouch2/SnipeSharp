using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using SnipeSharp.Common;

namespace SnipeSharp.JsonConverters
{
    class CustomFieldConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // TODO: There's probably a hell of a lot that can go wrong here
            var token = JToken.Load(reader);
            var result = new Dictionary<string, string>();

            foreach (JToken subToken in token)
            {
                var children = subToken.Children();
                foreach (var child in children)
                {
                    result.Add(child.Value<string>("field"), child.Value<string>("value"));
                }
            }
            
            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
}
