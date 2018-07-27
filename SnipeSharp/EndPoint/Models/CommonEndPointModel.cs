using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SnipeSharp.EndPoint.Models
{
    public abstract class CommonEndPointModel: ApiObject
    {
        public abstract long Id { get; set; }
        public abstract string Name { get; set; }
        public abstract DateTime CreatedAt { get; set; }
        public abstract DateTime UpdatedAt { get; set; }

        // TODO - We're doing this so when it's passed in the header for create action we get the ID
        public override string ToString()
        {
            return Id.ToString();
        }
    }

    internal sealed class CommonEndPointModelIdConverter : JsonConverter
    {
        internal static readonly CommonEndPointModelIdConverter Instance = new CommonEndPointModelIdConverter();
        public override bool CanConvert(Type objectType) => true;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) => throw new NotImplementedException();

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var item = value as CommonEndPointModel;
            writer.WriteValue(item.Id);
        }
    }
}