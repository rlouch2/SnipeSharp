using System;
using System.Collections.Generic;
using System.Reflection;
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
                var target = type.GetField(attribute.IndicatorFieldName, BindingFlags.Instance | BindingFlags.NonPublic);
                Assert.NotNull(target); // target field doesn't exist, or is static, or is public.
                Assert.Equal(typeof(bool), target.FieldType); // and the target field must be a boolean field
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
    }
}
