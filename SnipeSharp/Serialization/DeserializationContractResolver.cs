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
            if(attribute != null)
            {
                property.PropertyName = attribute.DeserializeAs;
                switch(attribute.FieldConverter)
                {
                    case FieldConverter.StripMonthSuffix:
                        property.MemberConverter = StripMonthSuffixConverter.Instance;
                        break;
                    case FieldConverter.ExtractDateTime:
                        property.MemberConverter = CustomDateTimeConverter.Instance;
                        break;
                    case FieldConverter.SerializeToId:
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