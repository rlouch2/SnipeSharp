using System.Collections;
using System.Collections.Generic;
using SnipeSharp.Models;

namespace SnipeSharp.Collections
{
    /// <summary>A custom dictionary wrapper for asset custom fields, allowing string->string mapping.</summary>
    public sealed class CustomFieldDictionary : Dictionary<string, AssetCustomField>
    {
        /// <summary>
        /// Create a new Custom Field dictionary.
        /// </summary>
        internal CustomFieldDictionary()
        {
            Friendly = new FriendlyNameDictionary(this);
        }

        /// <value>The underlying model dictionary.</value>
        public IDictionary<string, AssetCustomField> Models => (IDictionary<string, AssetCustomField>)this;

        private Dictionary<string, string> FriendlyNameMap = new Dictionary<string, string>();

        /// <summary>Maps the friendly names to the internal database column names.</summary>
        public IReadOnlyDictionary<string, string> FriendlyNames => FriendlyNameMap;

        /// <summary>This same dictionary, but mapping from friendly names instead of internal column names.</summary>
        public IReadOnlyDictionary<string, string> Friendly { get; }

        /// <summary>The string values of the fields in this dictionary.</summary>
        public IEnumerable<string> StringValues => GetValues();

        /// <summary>Get and set custom field values by SnipeIT database column name.</summary>
        /// <param name="key">The database column name</param>
        public new string this[string key]
        {
            get => base[key].Value;
            set
            {
                if(base.TryGetValue(key, out var model))
                    model.Value = value;
                else
                {
                    model = new AssetCustomField { FriendlyName = key, Field = key, Value = value };
                    FriendlyNameMap[key] = key;
                }
                base[key] = model;
            }
        }

        /// <summary>Attempt to get custom field values by SnipeIT database column name.</summary>
        /// <param name="key">The database column name</param>
        /// <param name="value">The value of the field, or null.</param>
        /// <returns>True, if the field is present.</returns>
        public bool TryGetValue(string key, out string value)
        {
            if(base.TryGetValue(key, out var model))
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
            FriendlyNameMap[key] = key;
        }

        /// <summary>Clear the friendly name map and repopulate it.</summary>
        public void RecalculateFriendlyNames()
        {
            FriendlyNameMap.Clear();
            foreach(var pair in this)
                FriendlyNameMap[pair.Value.FriendlyName] = pair.Key;
        }
    }

    internal sealed class FriendlyNameDictionary : IReadOnlyDictionary<string, string>
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
