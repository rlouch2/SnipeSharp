using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SnipeSharp.Serialization.Converters;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SnipeSharp.Serialization
{
    internal sealed class DeserializationContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            var attribute = member.GetCustomAttribute<DeserializeAsAttribute>(inherit: false);
            if(null != attribute)
            {
                property.PropertyName = attribute.Key;
                property.Writable = true;
                if(FieldConverter.None != attribute.Converter)
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
                else
                    switch(attribute.DeserializeAs)
                    {
                        case DeserializeAs.Default:
                            break;
                        case DeserializeAs.Timestamp:
                            property.Converter = TimestampConverter.Instance;
                            break;
                        case DeserializeAs.DateObject:
                            property.Converter = DateObjectConverter.Instance;
                            break;
                        case DeserializeAs.AvailableActions:
                            property.Converter = AvailableActionsConverter.Instance;
                            break;
                    }
            } else
            {
                property.Ignored = true;
            }
            return property;
        }

        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            // start with the defaults
            var list = base.GetSerializableMembers(objectType);
            // add non-public, readable, serializable properties
            foreach(var member in objectType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic))
                if(member.CanWrite)
                    list.Add(member);
            return list;
        }
    }
}
