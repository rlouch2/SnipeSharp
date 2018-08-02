using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomIntBoolDictionaryConverter : JsonConverter
    {
        public static readonly CustomIntBoolDictionaryConverter Instance = new CustomIntBoolDictionaryConverter();
        public override bool CanConvert(Type objectType)
            => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var rawDictionary = serializer.Deserialize<Dictionary<string, int>>(reader);
            var newDictionary = new Dictionary<string, bool>();
            foreach(var pair in rawDictionary)
                newDictionary[pair.Key] = pair.Value != 0;
            return newDictionary;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}
