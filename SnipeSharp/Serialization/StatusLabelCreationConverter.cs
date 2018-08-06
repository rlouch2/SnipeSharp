using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.Exceptions;

namespace SnipeSharp.Serialization
{
    internal sealed class StatusLabelCreationConverter : CustomCreationConverter<StatusLabel>
    {
        public override StatusLabel Create(Type objectType)
            => throw new NotImplementedException();
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            => throw new NotImplementedException();

        public override bool CanWrite => true;
        public override bool CanRead => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var label = (StatusLabel) value;
            if(value == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            var properties = typeof(StatusLabel).GetProperties();
            writer.WriteStartObject();
            foreach(var property in properties)
            {
                var attribute = property.GetCustomAttribute<CreationFieldAttribute>();
                if(attribute == null)
                    continue;
                var objectValue = property.GetValue(label);
                if(objectValue == null)
                    continue;
                writer.WritePropertyName(attribute.Name);
                serializer.Serialize(writer, objectValue);
            }
            writer.WriteEndObject();
        }
    }
}