using System;
using System.Collections;
using System.Collections.Generic;
using SnipeSharp.Models;

namespace SnipeSharp.Collections
{
    /// <summary>A custom dictionary wrapper for asset custom fields, allowing string->string mapping.</summary>
    public sealed class CustomFieldDictionary : IDictionary<string, AssetCustomField>
    {
        /// <summary>
        /// Create a new Custom Field dictionary.
        /// </summary>
        internal CustomFieldDictionary()
        {
            Friendly = new FriendlyNameDictionary(this);
        }

        private Dictionary<string, AssetCustomField> BackingDictionary = new Dictionary<string, AssetCustomField>();

        /// <value>The underlying model dictionary.</value>
        public IDictionary<string, AssetCustomField> Models => (IDictionary<string, AssetCustomField>)this;

        /// <summary>Maps the friendly names to the internal database column names.</summary>
        private Dictionary<string, string> FriendlyNames = new Dictionary<string, string>();

        /// <summary>This same dictionary, but mapping from friendly names instead of internal column names.</summary>
        public IReadOnlyDictionary<string, string> Friendly { get; }

        /// <summary>The string values of the fields in this dictionary.</summary>
        public IEnumerable<string> StringValues => GetValues();

        /// <inheritdoc />
        public ICollection<string> Keys => BackingDictionary.Keys;

        /// <inheritdoc />
        public ICollection<AssetCustomField> Values => BackingDictionary.Values;

        /// <inheritdoc />
        public int Count => BackingDictionary.Count;

        /// <inheritdoc />
        public bool IsReadOnly => ((IDictionary<string,AssetCustomField>)BackingDictionary).IsReadOnly;

        AssetCustomField IDictionary<string, AssetCustomField>.this[string key]
        {
            get => BackingDictionary[key];
            set
            {
                if(!BackingDictionary.ContainsKey(key))
                {
                    Add(key, value);
                } else
                {
                    if(null == value.FriendlyName)
                    {
                        value = new AssetCustomField
                        {
                            Format = value.Format,
                            FriendlyName = value.Field,
                            Field = value.Field,
                            Value = value.Value
                        };
                    }
                    BackingDictionary[key] = value;
                    RecalculateFriendlyNames();
                }
            }
        }

        /// <summary>Get and set custom field values by SnipeIT database column name.</summary>
        /// <param name="key">The database column name</param>
        public string this[string key]
        {
            get => BackingDictionary[key].Value;
            set
            {
                if(BackingDictionary.TryGetValue(key, out var model))
                    model.Value = value;
                else
                {
                    model = new AssetCustomField { FriendlyName = key, Field = key, Value = value };
                    FriendlyNames[key] = key;
                }
                BackingDictionary[key] = model;
            }
        }

        /// <summary>Attempt to get custom field values by SnipeIT database column name.</summary>
        /// <param name="key">The database column name</param>
        /// <param name="value">The value of the field, or null.</param>
        /// <returns>True, if the field is present.</returns>
        public bool TryGetValue(string key, out string value)
        {
            if(BackingDictionary.TryGetValue(key, out var model))
            {
                value = model.Value;
                return true;
            }
            value = null;
            return false;
        }

        private IEnumerable<string> GetValues()
        {
            foreach(var value in Values)
                yield return value.Value;
        }

        /// <summary>Add custom field values by SnipeIT database column name.</summary>
        public void Add(string key, string value)
        {
            Add(key, new AssetCustomField { FriendlyName = key, Field = key, Value = value });
            FriendlyNames[key] = key;
        }

        /// <summary>Clear the friendly name map and repopulate it.</summary>
        public void RecalculateFriendlyNames()
        {
            FriendlyNames.Clear();
            foreach(var pair in this)
                FriendlyNames[pair.Value.FriendlyName] = pair.Key;
        }

        /// <inheritdoc />
        public void Add(string key, AssetCustomField value)
        {
            if(null == value)
                throw new ArgumentNullException(paramName: nameof(value));
            if(null == value.FriendlyName)
            {
                value = new AssetCustomField
                {
                    Format = value.Format,
                    FriendlyName = value.Field,
                    Field = value.Field,
                    Value = value.Value
                };
            }
            BackingDictionary.Add(key, value);
            FriendlyNames.Add(value.FriendlyName, value.Field);
        }

        /// <inheritdoc />
        public bool ContainsKey(string key)
            => BackingDictionary.ContainsKey(key);

        /// <inheritdoc />
        public bool Remove(string key)
        {
            var result = BackingDictionary.Remove(key);
            if(result)
                RecalculateFriendlyNames();
            return result;
        }

        /// <inheritdoc />
        bool IDictionary<string, AssetCustomField>.TryGetValue(string key, out AssetCustomField value)
            => BackingDictionary.TryGetValue(key, out value);

        /// <inheritdoc />
        public void Clear()
        {
            BackingDictionary.Clear();
            FriendlyNames.Clear();
        }

        /// <inheritdoc />
        public IEnumerator<KeyValuePair<string, AssetCustomField>> GetEnumerator()
            => BackingDictionary.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        void ICollection<KeyValuePair<string, AssetCustomField>>.Add(KeyValuePair<string, AssetCustomField> item)
            => Add(item.Key, item.Value);

        /// <inheritdoc />
        public bool Contains(KeyValuePair<string, AssetCustomField> item)
            => ((IDictionary<string,AssetCustomField>)BackingDictionary).Contains(item);

        void ICollection<KeyValuePair<string, AssetCustomField>>.CopyTo(KeyValuePair<string, AssetCustomField>[] array, int arrayIndex)
            => ((IDictionary<string,AssetCustomField>)BackingDictionary).CopyTo(array, arrayIndex);

        bool ICollection<KeyValuePair<string, AssetCustomField>>.Remove(KeyValuePair<string, AssetCustomField> item)
        {
            var result = ((IDictionary<string,AssetCustomField>)BackingDictionary).Remove(item);
            if(result)
                RecalculateFriendlyNames();
            return result;
        }

        IEnumerator<KeyValuePair<string, AssetCustomField>> IEnumerable<KeyValuePair<string, AssetCustomField>>.GetEnumerator()
            => ((IDictionary<string,AssetCustomField>)BackingDictionary).GetEnumerator();

        private sealed class FriendlyNameDictionary : IReadOnlyDictionary<string, string>
        {
            private readonly CustomFieldDictionary CustomFields;
            internal FriendlyNameDictionary(CustomFieldDictionary dictionary)
            {
                CustomFields = dictionary;
            }

            public string this[string key] => CustomFields[CustomFields.FriendlyNames[key]];

            public IEnumerable<string> Keys => CustomFields.FriendlyNames.Keys;

            public IEnumerable<string> Values => CustomFields.StringValues;

            public int Count => CustomFields.Count;

            public bool ContainsKey(string key)
                => CustomFields.FriendlyNames.ContainsKey(key);

            public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
            {
                foreach(var key in Keys)
                    yield return new KeyValuePair<string, string>(key, CustomFields[CustomFields.FriendlyNames[key]]);
            }

            public bool TryGetValue(string key, out string value)
                => CustomFields.TryGetValue(CustomFields.FriendlyNames[key], out value);

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
