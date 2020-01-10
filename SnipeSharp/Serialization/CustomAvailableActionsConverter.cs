using System;
using System.Collections.Generic;
using SnipeSharp.Models.Enumerations;
using Newtonsoft.Json;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomAvailableActionsConverter : JsonConverter<AvailableAction>
    {
        public static readonly CustomAvailableActionsConverter Instance = new CustomAvailableActionsConverter();
        public override AvailableAction ReadJson(JsonReader reader, Type objectType, AvailableAction existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var dictionary = serializer.Deserialize<Dictionary<AvailableAction, bool>>(reader);
            var set = AvailableAction.None;
            if(null != dictionary)
                foreach(var pair in dictionary)
                    if(pair.Value)
                        set |= pair.Key;
            return set;
        }

        public override void WriteJson(JsonWriter writer, AvailableAction value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}
