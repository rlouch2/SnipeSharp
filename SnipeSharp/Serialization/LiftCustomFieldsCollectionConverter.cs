using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SnipeSharp.EndPoint.Models;

namespace SnipeSharp.Serialization
{
    internal abstract class LiftCustomFieldsCollectionConverter<T> : CustomCreationConverter<ICustomFields<T>>
    {
        public override ICustomFields<T> Create(Type objectType)
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

            var customFieldsObject = (ICustomFields<T>) value; // we need the InvalidCastException here!
            var properties = value.GetType().GetProperties();
            writer.WriteStartObject();
            foreach(var property in properties)
            {
                if(property.Name == nameof(Asset.CustomFields))
                    continue;
                writer.WritePropertyName(property.Name);
                serializer.Serialize(writer, property.GetValue(value));
            }
            if(customFieldsObject.CustomFields != null)
            {
                foreach(var pair in customFieldsObject.CustomFields)
                {
                    writer.WritePropertyName(GetKey(pair));
                    serializer.Serialize(writer, GetValue(pair));
                }
            }
            writer.WriteEndObject();
        }

        protected abstract string GetKey(KeyValuePair<string, T> pair);
        protected abstract object GetValue(KeyValuePair<string, T> pair);
    }

    internal sealed class AssetLiftCustomFieldsCollectionConverter : LiftCustomFieldsCollectionConverter<AssetCustomField>
    {
        public static readonly AssetLiftCustomFieldsCollectionConverter Instance = new AssetLiftCustomFieldsCollectionConverter();

        protected override string GetKey(KeyValuePair<string, AssetCustomField> pair)
            => pair.Value.Field ?? pair.Key;

        protected override object GetValue(KeyValuePair<string, AssetCustomField> pair)
            => pair.Value.Value;
    }

    internal sealed class ObjectLiftCustomFieldsCollectionConverter : LiftCustomFieldsCollectionConverter<object>
    {
        public static readonly ObjectLiftCustomFieldsCollectionConverter Instance = new ObjectLiftCustomFieldsCollectionConverter();

        protected override string GetKey(KeyValuePair<string, object> pair)
            => pair.Key;

        protected override object GetValue(KeyValuePair<string, object> pair)
            => pair.Value;
    }
}
