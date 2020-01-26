using Newtonsoft.Json;
using SnipeSharp.Models;
using System;
using System.Collections.Generic;

namespace SnipeSharp.Serialization.Converters
{
    internal sealed class ReadOnlyResponseCollectionConverter : JsonConverter
    {
        public static readonly ReadOnlyResponseCollectionConverter Instance = new ReadOnlyResponseCollectionConverter();

        public override bool CanConvert(Type objectType)
            => objectType.IsGenericType && typeof(IReadOnlyCollection<>) == objectType.GetGenericTypeDefinition();

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // If objectType is IReadOnlyCollection<T>, make a ResponseCollection<T>, then deserialize into that.
            var type = typeof(ResponseCollection<>).MakeGenericType(objectType.GenericTypeArguments);
            return serializer.Deserialize(reader, type);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}
