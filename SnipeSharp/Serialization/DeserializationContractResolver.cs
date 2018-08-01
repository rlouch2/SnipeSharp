using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace SnipeSharp.Serialization
{
    internal sealed class DeserializationContractResolver : DefaultContractResolver
    {
        public static readonly DeserializationContractResolver Instance = new DeserializationContractResolver();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            var attribute = member.GetCustomAttribute<FieldAttribute>();
            if(attribute != null && attribute.DeserializeAs != null)
            {
                property.PropertyName = attribute.DeserializeAs;
                switch(attribute.Converter)
                {
                    case FieldConverter.MonthsConverter:
                        property.MemberConverter = CustomMonthsConverter.Instance;
                        break;
                    case FieldConverter.DateTimeConverter:
                        property.MemberConverter = CustomDateTimeConverter.Instance;
                        break;
                    case FieldConverter.TimeSpanConverter:
                        property.MemberConverter = CustomTimeSpanConverter.Instance;
                        break;
                    case FieldConverter.PermissionsConverter:
                        property.MemberConverter = CustomIntBoolDictionaryConverter.Instance;
                        break;
                    case FieldConverter.MessagesConverter:
                        property.MemberConverter = CustomMessageConverter.Instance;
                        break;
                    case FieldConverter.CommonModelConverter:
                    case FieldConverter.None:
                        break;
                }
                property.Converter = property.MemberConverter;
            } else
            {
                property.Ignored = true;
            }
            return property;
        }
    }
}