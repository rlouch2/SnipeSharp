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
            if(attribute != null && attribute.CanSerialize)
            {
                property.PropertyName = attribute.SerializeAs;
                switch(attribute.FieldConverter)
                {
                    case FieldConverter.SerializeToId:
                        property.MemberConverter = CommonEndPointModelIdConverter.Instance;
                        break;
                    case FieldConverter.ExtractTimeSpanDays:
                        property.MemberConverter = CustomTimeSpanDaysConverter.Instance;
                        break;
                    case FieldConverter.ExtractDateTime:
                        property.MemberConverter = CustomDateTimeConverter.Instance;
                        break;
                    case FieldConverter.IntegerPermissions:
                    case FieldConverter.StripMonthSuffix:
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