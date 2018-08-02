using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SnipeSharp.EndPoint.Models;

namespace SnipeSharp.Serialization
{
    internal sealed class LiftCustomFieldsCollectionConverter : CustomCreationConverter<Asset>
    {
        public static readonly LiftCustomFieldsCollectionConverter Instance = new LiftCustomFieldsCollectionConverter();
        
        public override Asset Create(Type objectType)
            => throw new NotImplementedException();

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            => throw new NotImplementedException();

        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // With assistance from https://stackoverflow.com/questions/14893614/how-to-serialize-a-dictionary-as-part-of-its-parent-object-using-json-net
            if(value == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            var asset = (Asset) value; // we need the InvalidCastException here!
            var properties = asset.GetType().GetProperties();
            writer.WriteStartObject();
            foreach(var property in properties)
            {
                if(property.Name == nameof(Asset.CustomFields))
                    continue;
                writer.WritePropertyName(property.Name);
                serializer.Serialize(writer, property.GetValue(asset));
            }
            foreach(var pair in asset.CustomFields)
            {
                writer.WritePropertyName(pair.Value.Field ?? pair.Key);
                serializer.Serialize(writer, pair.Value.Value);
            }
            writer.WriteEndObject();
        }
    }
}
