using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SnipeSharp.Models;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomFieldDictionaryConverter<T> : JsonConverter where T: class
    {
        internal static readonly CustomFieldDictionaryConverter<T> Instance = new CustomFieldDictionaryConverter<T>();
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
                return serializer.Deserialize<Dictionary<string, T>>(reader);
            }    
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}
