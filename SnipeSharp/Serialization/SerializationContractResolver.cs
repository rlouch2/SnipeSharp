using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace SnipeSharp.Serialization
{
    internal sealed class SerializationContractResolver : DefaultContractResolver
    {
        public static bool TryGetConverter(PropertyInfo property, FieldConverter fieldConverter, out JsonConverter converter)
        {
            switch(fieldConverter)
            {
                case FieldConverter.CommonModelConverter:
                    converter = CustomCommonModelConverter.Instance;
                    return true;
                case FieldConverter.CommonModelArrayConverter:
                    converter = CustomCommonModelArrayConverter.Instance;
                    return true;
                case FieldConverter.TimeSpanConverter:
                    converter = CustomTimeSpanConverter.Instance;
                    return true;
                case FieldConverter.DateTimeConverter:
                    converter = CustomDateTimeConverter.Instance;
                    return true;
                case FieldConverter.AssetStatusConverter:
                    converter = CustomAssetStatusConverter.Instance;
                    return true;
                case FieldConverter.SimpleDate:
                    converter = SimpleDateConverter.Instance;
                    return true;
                case FieldConverter.CustomFieldDictionaryConverter:
                case FieldConverter.AvailableActionsConverter:
                case FieldConverter.PermissionsConverter:
                case FieldConverter.MessagesConverter:
                case FieldConverter.MonthsConverter:
                case FieldConverter.FalseyUriConverter:
                case FieldConverter.ReadOnlyResponseCollectionConverter:
                    converter = null;
                    return false;
                case FieldConverter.None:
                default:
                    if(null == property)
                    {
                        converter = null;
                        return false;
                    }
                    if(property.PropertyType.IsAssignableFrom(typeof(bool?)))
                    {
                        converter = CustomNullableBooleanConverter.Instance;
                        return true;
                    }

                    // otherwise
                    converter = null;
                    return false;
            }
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            var attribute = member.GetCustomAttribute<SerializeAsAttribute>(inherit: false);
            if((null != attribute && !string.IsNullOrEmpty(attribute.Key)))
            {
                property.PropertyName = attribute.Key;
                property.Readable = true;
                var patch = member.GetCustomAttribute<PatchAttribute>(true);
                if(null != patch)
                {
                    var targetField = member.DeclaringType.GetField(patch.IndicatorFieldName, BindingFlags.Instance | BindingFlags.NonPublic);
                    if(null != targetField)
                        property.ShouldSerialize = (instance) => (bool)targetField.GetValue(instance);
                    else
                    {
                        var targetProperty = member.DeclaringType.GetProperty(patch.IndicatorFieldName, BindingFlags.Instance | BindingFlags.NonPublic);
                        property.ShouldSerialize = (instance) => (bool)targetProperty.GetValue(instance);
                    }
                }
                if(TryGetConverter(member as PropertyInfo, attribute.Converter, out var converter))
                    property.Converter = converter;
            } else
            {
                property.Ignored = true;
            }
            return property;
        }
    }
}
