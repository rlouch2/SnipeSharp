using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace SnipeSharp.Serialization
{
    internal sealed class EnumJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
            => typeToConvert.IsEnum;

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
            => (JsonConverter?)Activator.CreateInstance(
                typeof(EnumJsonConverter<>).MakeGenericType(typeToConvert),
                BindingFlags.Public | BindingFlags.Instance,
                binder: null, args: Array.Empty<object>(), culture: null);
    }

    internal sealed class EnumJsonConverter<T> : JsonConverter<T> where T : Enum
    {
        private readonly Type ConversionType;
        private readonly IReadOnlyDictionary<string,T> NameToValue;
        private readonly IReadOnlyDictionary<T,string> ValueToName;
        public EnumJsonConverter()
        {
            ConversionType = typeof(T);
            var nameToValue = new Dictionary<string,T>();
            var valueToName = new Dictionary<T,string>();
            foreach(var value in Enum.GetValues(ConversionType))
            {
                var name = Enum.GetName(ConversionType, value) ?? throw new ArgumentNullException();// TODO: better exception
                var attr = ConversionType
                    .GetMember(name)
                    .FirstOrDefault(member => member.DeclaringType == ConversionType)
                    ?.GetCustomAttribute<EnumMemberAttribute>(false);
                name = attr?.Value ?? name;
                nameToValue[name] = (T)value;
                valueToName[(T)value] = name;
            }
            NameToValue = nameToValue;
            ValueToName = valueToName;
        }
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if(!reader.Read())
                throw new JsonException();
            var str = reader.GetString();
            if(null == str)
                return default(T?);
            if(NameToValue.TryGetValue(str, out var value))
                return value;
            return (T)Enum.Parse(ConversionType, str);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(ValueToName.TryGetValue(value, out var name) ? name : value.ToString());
        }
    }
}
