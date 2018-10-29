using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SnipeSharp.Models;
using System.Reflection;

namespace SnipeSharp.Serialization
{
    internal sealed class SerializationContractResolver : DefaultContractResolver
    {
        public static readonly SerializationContractResolver Instance = new SerializationContractResolver();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            var attribute = member.GetCustomAttribute<FieldAttribute>(true);
            if(!(attribute is null) && attribute.ShouldSerialize)
            {
                property.PropertyName = attribute.SerializeAs;
                property.Readable = true;
                switch(attribute.Converter)
                {
                    case FieldConverter.CommonModelConverter:
                        property.Converter = CustomCommonModelConverter.Instance;
                        break;
                    case FieldConverter.CommonModelArrayConverter:
                        property.Converter = CustomCommonModelArrayConverter.Instance;
                        break;
                    case FieldConverter.TimeSpanConverter:
                        property.Converter = CustomTimeSpanConverter.Instance;
                        break;
                    case FieldConverter.DateTimeConverter:
                        property.Converter = CustomDateTimeConverter.Instance;
                        break;
                    case FieldConverter.AssetStatusConverter:
                        property.Converter = CustomAssetStatusConverter.Instance;
                        break;
                    case FieldConverter.CustomFieldDictionaryConverter:
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
