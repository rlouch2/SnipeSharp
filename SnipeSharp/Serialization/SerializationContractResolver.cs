using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SnipeSharp.EndPoint.Models;
using System.Reflection;

namespace SnipeSharp.Serialization
{
    internal sealed class SerializationContractResolver : DefaultContractResolver
    {
        public static readonly SerializationContractResolver Instance = new SerializationContractResolver();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            var attribute = member.GetCustomAttribute<FieldAttribute>();
            if(attribute != null && attribute.ShouldSerialize)
            {
                property.PropertyName = attribute.SerializeAs;
                switch(attribute.Converter)
                {
                    case FieldConverter.CommonModelConverter:
                        property.Converter = property.MemberConverter = CustomCommonModelConverter.Instance;
                        break;
                    case FieldConverter.TimeSpanConverter:
                        property.Converter = property.MemberConverter = CustomTimeSpanConverter.Instance;
                        break;
                    case FieldConverter.DateTimeConverter:
                        property.Converter = property.MemberConverter = CustomDateTimeConverter.Instance;
                        break;
                    case FieldConverter.AvailableActionsConverter:
                    case FieldConverter.PermissionsConverter:
                    case FieldConverter.MessagesConverter:
                    case FieldConverter.MonthsConverter:
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