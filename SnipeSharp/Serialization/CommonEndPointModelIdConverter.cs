﻿using System;
using Newtonsoft.Json;
using SnipeSharp.EndPoint.Models;

namespace SnipeSharp.Serialization
{
    internal sealed class CommonEndPointModelIdConverter : JsonConverter
    {
        internal static readonly CommonEndPointModelIdConverter Instance = new CommonEndPointModelIdConverter();
        public override bool CanConvert(Type objectType)
            => true;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            => throw new NotImplementedException();

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var item = value as CommonEndPointModel;
            writer.WriteValue(item.Id);
        }
    }
}