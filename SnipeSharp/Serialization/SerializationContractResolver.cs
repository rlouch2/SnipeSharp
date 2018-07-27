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
            if(attribute != null)
            {
                if(!attribute.CanSerialize)
                    property.Ignored = true;
                // if we should serialize CommonEndPointModels to Id and this field belongs to a subclass of it.
                if(attribute.SerializeToId && typeof(CommonEndPointModel).IsAssignableFrom(member.DeclaringType))
                    property.Converter = CommonEndPointModelIdConverter.Instance;
                property.PropertyName = attribute.SerializeAs;
            }
            return property;
        }
    }
}