using System;
using Newtonsoft.Json;

namespace SnipeSharp.Serialization
{
    internal sealed class FalseyUriConverter : JsonConverter<Uri>
    {
        public static readonly FalseyUriConverter Instance = new FalseyUriConverter();
        public override Uri ReadJson(JsonReader reader, Type objectType, Uri existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var obj = serializer.Deserialize(reader) as string;
            if(null == obj)
                return null;
            return new Uri(obj);
        }

        public override void WriteJson(JsonWriter writer,  Uri value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}
