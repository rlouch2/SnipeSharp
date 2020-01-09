using System;
using Newtonsoft.Json;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomNullableBooleanConverter : JsonConverter<bool?>
    {
        internal static readonly CustomNullableBooleanConverter Instance = new CustomNullableBooleanConverter();
        public override bool? ReadJson(JsonReader reader, Type objectType, bool? existingValue, bool hasExistingValue, JsonSerializer serializer)
            => serializer.Deserialize<bool?>(reader);

        public override void WriteJson(JsonWriter writer, bool? value, JsonSerializer serializer)
        {
            if(null == value)
                writer.WriteNull();
            else
                writer.WriteRawValue((bool)value ? "true" : "false");
        }
    }
}
