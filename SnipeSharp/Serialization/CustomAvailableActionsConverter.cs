using System;
using System.Collections.Generic;
using SnipeSharp.Models.Enumerations;
using Newtonsoft.Json;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomAvailableActionsConverter : JsonConverter<HashSet<AvailableAction>>
    {
        public static readonly CustomAvailableActionsConverter Instance = new CustomAvailableActionsConverter();
        public override HashSet<AvailableAction> ReadJson(JsonReader reader, Type objectType, HashSet<AvailableAction> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var dictionary = serializer.Deserialize<Dictionary<AvailableAction, bool>>(reader);
            var set = new HashSet<AvailableAction>();
            foreach(var pair in dictionary)
                if(pair.Value)
                    set.Add(pair.Key);
            return set;
        }

        public override void WriteJson(JsonWriter writer, HashSet<AvailableAction> value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}
