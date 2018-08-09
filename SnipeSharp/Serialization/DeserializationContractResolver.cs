using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using SnipeSharp.EndPoint.Models;

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
                    case FieldConverter.CommonModelConverter:
                        if(attribute.OverrideAffinity)
                            property.Converter = CustomCommonModelConverter.Instance;
                        break;
                    case FieldConverter.AssetStatusConverter:
                    case FieldConverter.None:
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
