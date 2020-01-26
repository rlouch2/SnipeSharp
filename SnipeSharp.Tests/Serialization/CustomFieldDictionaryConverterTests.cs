using System;
using SnipeSharp.Serialization.Converters;
using Xunit;

namespace SnipeSharp.Tests
{
    public sealed class CustomFieldDictionaryConverterTests
    {
        [Fact]
        public void WriteJson_IsNotImplemented()
        {
            Assert.Throws<NotImplementedException>(() => new CustomFieldDictionaryConverter().WriteJson(null, null, null));
        }

        // TODO: when do we see arrays?
        // TODO: isolate deserializing assetcustomfield dictionary
    }
}
