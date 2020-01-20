using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using SnipeSharp.Serialization;
using Xunit;

namespace SnipeSharp.Tests
{
    public sealed class PatchAttributeTests
    {
        [Fact]
        public void AllPatchAttributesAreValid()
        {
            Assert.All(GetAllAttributes<PatchAttribute>(), ((Type, PatchAttribute) tuple) => {
                var (type, attribute) = tuple;
                Assert.True(typeof(IPatchable).IsAssignableFrom(type)); // patch attributes can only be used on IPatchable classes
                Assert.NotNull(attribute.IndicatorFieldName);
                Assert.NotEmpty(attribute.IndicatorFieldName);
                var target = (MemberInfo)type.GetField(attribute.IndicatorFieldName, BindingFlags.Instance | BindingFlags.NonPublic)
                                      ?? type.GetProperty(attribute.IndicatorFieldName, BindingFlags.Instance | BindingFlags.NonPublic);
                // target field or property exists, is non-public, and is not static.
                Assert.NotNull(target);
                // and the target type is a boolean field or property
                Assert.Equal(typeof(bool), MemberTypes.Field == target.MemberType ? ((FieldInfo)target).FieldType : ((PropertyInfo)target).PropertyType);
                // and if the target is a property, it is readable.
                Assert.True(MemberTypes.Property == target.MemberType ? ((PropertyInfo)target).CanRead : true);
            });
        }

        [Fact]
        public void AllIPatchableTypesHavePrivateOnDeserializedMethod()
        {
            Assert.All(GetAllTypes<IPatchable>(), (Type type) => {
                if(type == typeof(IPatchable))
                    return;
                var onDeserializedMethod = type.GetMethod("OnDeserialized", BindingFlags.Instance | BindingFlags.NonPublic);
                Assert.NotNull(onDeserializedMethod);
                var onDeserializedAttribute = onDeserializedMethod.GetCustomAttribute<OnDeserializedAttribute>();
                Assert.NotNull(onDeserializedAttribute);
            });
        }

        private IEnumerable<(Type, T)> GetAllAttributes<T>()
            where T: Attribute
        {
            var assembly = Assembly.GetAssembly(typeof(T));
            var types = assembly.GetTypes();
            foreach(var type in types)
            {
                foreach(var property in type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    var attr = property.GetCustomAttribute<T>();
                    if(null != attr)
                        yield return (type, attr);
                }
                foreach(var property in type.GetProperties(BindingFlags.Public))
                {
                    var attr = property.GetCustomAttribute<T>();
                    if(null != attr)
                        yield return (type, attr);
                }
                foreach(var property in type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic))
                {
                    var attr = property.GetCustomAttribute<T>();
                    if(null != attr)
                        yield return (type, attr);
                }
                foreach(var property in type.GetProperties(BindingFlags.NonPublic))
                {
                    var attr = property.GetCustomAttribute<T>();
                    if(null != attr)
                        yield return (type, attr);
                }
            }
        }

        private IEnumerable<Type> GetAllTypes<T>()
        {
            var assembly = Assembly.GetAssembly(typeof(T));
            var types = assembly.GetTypes();
            foreach(var type in types)
                if(typeof(T).IsAssignableFrom(type))
                    yield return type;
        }
    }
}
