using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace SnipeSharp.Serialization
{
    internal sealed class SerializationContractResolver : DefaultContractResolver
    {
        public static readonly SerializationContractResolver Instance = new SerializationContractResolver();

        public static JsonConverter GetConverter(FieldAttribute attribute)
        {
            switch(attribute.Converter)
            {
                case FieldConverter.CommonModelConverter:
                    return CustomCommonModelConverter.Instance;
                case FieldConverter.CommonModelArrayConverter:
                    return CustomCommonModelArrayConverter.Instance;
                case FieldConverter.TimeSpanConverter:
                    return CustomTimeSpanConverter.Instance;
                case FieldConverter.DateTimeConverter:
                    return CustomDateTimeConverter.Instance;
                case FieldConverter.AssetStatusConverter:
                    return CustomAssetStatusConverter.Instance;
                case FieldConverter.BoolStringConverter:
                    return CustomBoolStringConverter.Instance;
                case FieldConverter.CustomFieldDictionaryConverter:
                case FieldConverter.AvailableActionsConverter:
                case FieldConverter.PermissionsConverter:
                case FieldConverter.MessagesConverter:
                case FieldConverter.MonthsConverter:
                case FieldConverter.None:
                default:
                    return null;
            }
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            var attribute = member.GetCustomAttribute<FieldAttribute>(true);
            if(!(attribute is null) && !string.IsNullOrEmpty(attribute.SerializeAs))
            {
                property.PropertyName = attribute.SerializeAs;
                property.Readable = true;
                var converter = GetConverter(attribute);
                if(converter != null)
                    property.Converter = converter;
            } else
            {
                property.Ignored = true;
            }
            return property;
        }
    }
}
