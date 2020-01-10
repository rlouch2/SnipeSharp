using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using SnipeSharp.Models;

namespace SnipeSharp.Serialization
{
    internal sealed class DeserializationContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            var attribute = member.GetCustomAttribute<FieldAttribute>(true);
            if(null != attribute && null != attribute.DeserializeAs)
            {
                property.PropertyName = attribute.DeserializeAs;
                property.Writable = true;
                switch(attribute.Converter)
                {
                    case FieldConverter.MonthsConverter:
                        property.Converter = CustomMonthsConverter.Instance;
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
