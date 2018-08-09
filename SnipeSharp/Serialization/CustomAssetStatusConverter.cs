using System;
using Newtonsoft.Json;
using SnipeSharp.EndPoint.Models;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomAssetStatusConverter : JsonConverter
    {
        internal static readonly CustomAssetStatusConverter Instance = new CustomAssetStatusConverter();
        public override bool CanConvert(Type objectType)
            => true;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            => throw new NotImplementedException();

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var item = value as AssetStatus;
            writer.WriteValue(item.StatusId);
        }
    }
}
