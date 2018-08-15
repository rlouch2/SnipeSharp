using System;
using System.Collections.Generic;
using SnipeSharp.Models.Enumerations;
using Newtonsoft.Json;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomAvailableActionsConverter : JsonConverter
    {
        public static readonly CustomAvailableActionsConverter Instance = new CustomAvailableActionsConverter();
        public override bool CanConvert(Type objectType)
            => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var dictionary = serializer.Deserialize<Dictionary<AvailableAction, bool>>(reader);
            var set = new HashSet<AvailableAction>();
            foreach(var pair in dictionary)
                if(pair.Value)
                    set.Add(pair.Key);
            return set;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}
