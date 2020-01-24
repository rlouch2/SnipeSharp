using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace SnipeSharp.Serialization
{
    internal sealed class DeserializationContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            var attribute = member.GetCustomAttribute<FieldAttribute>(true) as IDeserializeAs ?? member.GetCustomAttribute<DeserializeAsAttribute>(true);
            if(null != attribute && null != attribute.Key)
            {
                property.PropertyName = attribute.Key;
                property.Writable = true;
                switch(attribute.Converter)
                {
                    case FieldConverter.MonthsConverter:
                        property.Converter = CustomMonthsConverter.Instance;
                        break;
                    case FieldConverter.SimpleDate:
                        property.Converter = SimpleDateConverter.Instance;
                        break;
                    case FieldConverter.DateTimeConverter:
                        property.Converter = CustomDateTimeConverter.Instance;
                        break;
                    case FieldConverter.TimeSpanConverter:
                        property.Converter = CustomTimeSpanConverter.Instance;
                        break;
                    case FieldConverter.PermissionsConverter:
                        property.Converter = CustomIntBoolDictionaryConverter.Instance;
                        break;
                    case FieldConverter.MessagesConverter:
                        property.Converter = CustomMessageConverter.Instance;
                        break;
                    case FieldConverter.AvailableActionsConverter:
                        property.Converter = CustomAvailableActionsConverter.Instance;
                        break;
                    case FieldConverter.CustomFieldDictionaryConverter:
                        property.Converter = CustomFieldDictionaryConverter.Instance;
                        break;
                    case FieldConverter.FalseyUriConverter:
                        property.Converter = FalseyUriConverter.Instance;
                        break;
                    case FieldConverter.ReadOnlyResponseCollectionConverter:
                        property.Converter = CustomReadOnlyResponseCollectionConverter.Instance;
                        break;
                    default:
                        break;
                }
            } else
            {
                property.Ignored = true;
            }
            return property;
        }
    }
}
