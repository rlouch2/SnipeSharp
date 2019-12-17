using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SnipeSharp.Collections;
using SnipeSharp.Models;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomFieldDictionaryConverter : JsonConverter
    {
        internal static readonly CustomFieldDictionaryConverter Instance = new CustomFieldDictionaryConverter();
        public override bool CanConvert(Type objectType)
            => true;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(reader.TokenType == JsonToken.StartArray)
            {
                serializer.Deserialize(reader); // discard, we don't want an array.
                return existingValue;
            } else
            {
                var values = serializer.Deserialize<Dictionary<string, AssetCustomField>>(reader);
                var dictionary = new CustomFieldDictionary();
                foreach(var pair in values)
                {
                    pair.Value.FriendlyName = pair.Key;
                    dictionary.Add(pair.Value.Field, pair.Value);
                }
                dictionary.RecalculateFriendlyNames();
                return dictionary;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}
