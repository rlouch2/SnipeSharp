using System;
using System.Collections.Generic;
using SnipeSharp.Collections;
using SnipeSharp.Models;
using Xunit;

namespace SnipeSharp.Tests
{
    public sealed class CustomFieldDictionaryTests
    {
        const string TEST_KEY = nameof(TEST_KEY);
        const string TEST_FRIENDLY_KEY = nameof(TEST_FRIENDLY_KEY);
        const string TEST_VALUE = nameof(TEST_VALUE);
        const string TEST_VALUE2 = nameof(TEST_VALUE2);

        static readonly AssetCustomField TEST_FIELD = new AssetCustomField
        {
            Field = TEST_KEY,
            FriendlyName = TEST_FRIENDLY_KEY,
            Format = null,
            Value = TEST_VALUE
        };

        static readonly AssetCustomField TEST_FIELD2 = new AssetCustomField
        {
            Field = TEST_KEY,
            FriendlyName = TEST_FRIENDLY_KEY,
            Format = null,
            Value = TEST_VALUE2
        };

        [Fact]
        public void New_IsEmpty()
        {
            var dict = new CustomFieldDictionary();
            Assert.Empty(dict);
            Assert.Empty(dict.Models);
            Assert.Same(dict, dict.Models);
            Assert.Empty(dict.StringValues);
            Assert.Empty(dict.Friendly);
        }

        [Fact]
        public void NotReadOnly()
        {
            var dict = new CustomFieldDictionary();
            Assert.False(dict.IsReadOnly);
        }

        [Fact]
        public void Add_WithString()
        {
            var dict = new CustomFieldDictionary();
            Assert.False(dict.ContainsKey(TEST_KEY));
            dict.Add(TEST_KEY, TEST_VALUE);
            Assert.Collection(dict.Keys, a => Assert.Equal(TEST_KEY, a));
            Assert.Collection(dict.Values, (AssetCustomField a) => {
                Assert.Equal(TEST_KEY, a.FriendlyName);
                Assert.Equal(TEST_KEY, a.Field);
                Assert.Null(a.Format);
                Assert.Equal(TEST_VALUE, a.Value);
            });
            Assert.True(dict.ContainsKey(TEST_KEY));
            Assert.False(dict.ContainsKey(TEST_FRIENDLY_KEY));
            Assert.Equal(dict.Count, dict.Friendly.Count);
            Assert.True(dict.Friendly.ContainsKey(TEST_KEY));
            Assert.False(dict.Friendly.ContainsKey(TEST_FRIENDLY_KEY));
            Assert.Collection(dict.Friendly.Keys, a => Assert.Equal(TEST_KEY, a));
            Assert.Collection(dict.Friendly.Values, a => Assert.Equal(TEST_VALUE, a));

            string value;
            Assert.True(dict.TryGetValue(TEST_KEY, out value));
            Assert.Equal(TEST_VALUE, value);
            Assert.Equal(TEST_VALUE, dict[TEST_KEY]);
            Assert.True(dict.Friendly.TryGetValue(TEST_KEY, out value));
            Assert.Equal(TEST_VALUE, value);
            Assert.Equal(TEST_VALUE, dict.Friendly[TEST_KEY]);

            Assert.False(dict.TryGetValue(TEST_VALUE, out value));
        }

        [Fact]
        public void Set_New_WithString()
        {
            var dict = new CustomFieldDictionary();
            dict[TEST_KEY] = TEST_VALUE;
            Assert.Collection(dict.Keys, a => Assert.Equal(TEST_KEY, a));
            Assert.Collection(dict.Values, (AssetCustomField a) => {
                Assert.Equal(TEST_KEY, a.FriendlyName);
                Assert.Equal(TEST_KEY, a.Field);
                Assert.Null(a.Format);
                Assert.Equal(TEST_VALUE, a.Value);
            });
            Assert.Equal(dict.Count, dict.Friendly.Count);
            Assert.True(dict.Friendly.ContainsKey(TEST_KEY));
            Assert.Collection(dict.Friendly.Keys, a => Assert.Equal(TEST_KEY, a));
            Assert.Collection(dict.Friendly.Values, a => Assert.Equal(TEST_VALUE, a));

            string value;
            Assert.True(dict.TryGetValue(TEST_KEY, out value));
            Assert.Equal(TEST_VALUE, value);
            Assert.Equal(TEST_VALUE, dict[TEST_KEY]);
            Assert.True(dict.Friendly.TryGetValue(TEST_KEY, out value));
            Assert.Equal(TEST_VALUE, value);
            Assert.Equal(TEST_VALUE, dict.Friendly[TEST_KEY]);

            Assert.False(dict.TryGetValue(TEST_VALUE, out value));
        }

        [Fact]
        public void Set_Existing_WithString()
        {
            var dict = new CustomFieldDictionary { [TEST_KEY] = TEST_VALUE };
            dict[TEST_KEY] = TEST_VALUE2;
            Assert.Collection(dict.Keys, a => Assert.Equal(TEST_KEY, a));
            Assert.Collection(dict.Values, (AssetCustomField a) => {
                Assert.Equal(TEST_KEY, a.FriendlyName);
                Assert.Equal(TEST_KEY, a.Field);
                Assert.Null(a.Format);
                Assert.Equal(TEST_VALUE2, a.Value);
            });
            Assert.Equal(dict.Count, dict.Friendly.Count);
            Assert.True(dict.Friendly.ContainsKey(TEST_KEY));
            Assert.Collection(dict.Friendly.Keys, a => Assert.Equal(TEST_KEY, a));
            Assert.Collection(dict.Friendly.Values, a => Assert.Equal(TEST_VALUE2, a));

            string value;
            Assert.True(dict.TryGetValue(TEST_KEY, out value));
            Assert.Equal(TEST_VALUE2, value);
            Assert.Equal(TEST_VALUE2, dict[TEST_KEY]);
            Assert.True(dict.Friendly.TryGetValue(TEST_KEY, out value));
            Assert.Equal(TEST_VALUE2, value);
            Assert.Equal(TEST_VALUE2, dict.Friendly[TEST_KEY]);

            Assert.False(dict.TryGetValue(TEST_VALUE2, out value));
        }

        [Fact]
        public void Add_WithField_UpdatesFriendlyNames()
        {
            var dict = new CustomFieldDictionary();
            IDictionary<string, AssetCustomField> dictRef = dict;
            dict.Add(TEST_FIELD);
            Assert.Collection(dict.Keys, a => Assert.Equal(TEST_KEY, a));
            Assert.Collection(dict.Values, (AssetCustomField a) => {
                Assert.Equal(TEST_FRIENDLY_KEY, a.FriendlyName);
                Assert.Equal(TEST_KEY, a.Field);
                Assert.Null(a.Format);
                Assert.Equal(TEST_VALUE, a.Value);
            });
            Assert.Equal(dict.Count, dict.Friendly.Count);
            Assert.False(dict.Friendly.ContainsKey(TEST_KEY));
            Assert.True(dict.Friendly.ContainsKey(TEST_FRIENDLY_KEY));
            Assert.Collection(dict.Friendly.Values, a => Assert.Equal(TEST_VALUE, a));

            string value;
            Assert.True(dict.TryGetValue(TEST_KEY, out value));
            Assert.Equal(TEST_VALUE, value);
            Assert.True(dict.Friendly.TryGetValue(TEST_FRIENDLY_KEY, out value));
            Assert.Equal(TEST_VALUE, value);
            Assert.Equal(TEST_VALUE, dict.Friendly[TEST_FRIENDLY_KEY]);

            Assert.False(dict.TryGetValue(TEST_VALUE, out value));

            var actual = dictRef[TEST_KEY];
            Assert.Equal(TEST_FRIENDLY_KEY, actual.FriendlyName);
            Assert.Equal(TEST_KEY, actual.Field);
            Assert.Null(actual.Format);
            Assert.Equal(TEST_VALUE, actual.Value);
        }

        [Fact]
        public void Add_WithField_DoesNotAcceptNull()
        {
            var dict = new CustomFieldDictionary();
            Assert.Throws<ArgumentNullException>(() => dict.Add(null));
            Assert.Throws<ArgumentNullException>(() => dict.Add(new AssetCustomField { Field = null }));
        }

        [Fact]
        public void Set_New_WithField()
        {
            var dict = new CustomFieldDictionary();
            IDictionary<string, AssetCustomField> dictRef = dict;
            dictRef[TEST_KEY] = TEST_FIELD;
            Assert.Collection(dict.Keys, a => Assert.Equal(TEST_KEY, a));
            Assert.Collection(dict.Values, (AssetCustomField a) => {
                Assert.Equal(TEST_FRIENDLY_KEY, a.FriendlyName);
                Assert.Equal(TEST_KEY, a.Field);
                Assert.Null(a.Format);
                Assert.Equal(TEST_VALUE, a.Value);
            });
            Assert.Equal(dict.Count, dict.Friendly.Count);
            Assert.False(dict.Friendly.ContainsKey(TEST_KEY));
            Assert.True(dict.Friendly.ContainsKey(TEST_FRIENDLY_KEY));
            Assert.Collection(dict.Friendly.Values, a => Assert.Equal(TEST_VALUE, a));

            string value;
            Assert.True(dict.TryGetValue(TEST_KEY, out value));
            Assert.Equal(TEST_VALUE, value);
            Assert.Equal(TEST_VALUE, dict[TEST_KEY]);
            Assert.True(dict.Friendly.TryGetValue(TEST_FRIENDLY_KEY, out value));
            Assert.Equal(TEST_VALUE, value);
            Assert.Equal(TEST_VALUE, dict.Friendly[TEST_FRIENDLY_KEY]);

            Assert.False(dict.TryGetValue(TEST_VALUE, out value));
        }

        [Fact]
        public void Set_Existing_WithField_NonNullFriendlyName()
        {
            var dict = new CustomFieldDictionary {{TEST_FIELD}};
            IDictionary<string, AssetCustomField> dictRef = dict;
            dictRef[TEST_KEY] = TEST_FIELD2;
            Assert.Collection(dict.Keys, a => Assert.Equal(TEST_KEY, a));
            Assert.Collection(dict.Values, (AssetCustomField a) => {
                Assert.Equal(TEST_FRIENDLY_KEY, a.FriendlyName);
                Assert.Equal(TEST_KEY, a.Field);
                Assert.Null(a.Format);
                Assert.Equal(TEST_VALUE2, a.Value);
            });
            Assert.Equal(dict.Count, dict.Friendly.Count);
            Assert.False(dict.Friendly.ContainsKey(TEST_KEY));
            Assert.True(dict.Friendly.ContainsKey(TEST_FRIENDLY_KEY));
            Assert.Collection(dict.Friendly.Values, a => Assert.Equal(TEST_VALUE2, a));

            string value;
            Assert.True(dict.TryGetValue(TEST_KEY, out value));
            Assert.Equal(TEST_VALUE2, value);
            Assert.Equal(TEST_VALUE2, dict[TEST_KEY]);
            Assert.True(dict.Friendly.TryGetValue(TEST_FRIENDLY_KEY, out value));
            Assert.Equal(TEST_VALUE2, value);
            Assert.Equal(TEST_VALUE2, dict.Friendly[TEST_FRIENDLY_KEY]);

            Assert.False(dict.TryGetValue(TEST_VALUE2, out value));
        }

        [Fact]
        public void Set_Existing_WithField_NullFriendlyName()
        {
            var dict = new CustomFieldDictionary {{TEST_FIELD}};
            IDictionary<string, AssetCustomField> dictRef = dict;
            dictRef[TEST_KEY] = new AssetCustomField
            {
                FriendlyName = null,
                Format = null,
                Field = TEST_KEY,
                Value = TEST_VALUE2
            };
            Assert.Collection(dict.Keys, a => Assert.Equal(TEST_KEY, a));
            Assert.Collection(dict.Values, (AssetCustomField a) => {
                Assert.Equal(TEST_KEY, a.FriendlyName);
                Assert.Equal(TEST_KEY, a.Field);
                Assert.Null(a.Format);
                Assert.Equal(TEST_VALUE2, a.Value);
            });
            Assert.Equal(dict.Count, dict.Friendly.Count);
            Assert.True(dict.Friendly.ContainsKey(TEST_KEY));
            Assert.False(dict.Friendly.ContainsKey(TEST_FRIENDLY_KEY));
            Assert.Collection(dict.Friendly.Values, a => Assert.Equal(TEST_VALUE2, a));
        }
    }
}