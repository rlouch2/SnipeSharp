using System.Collections.Generic;
using SnipeSharp.Models;

namespace SnipeSharp.Collections
{
    /// <summary>A custom dictionary wrapper for asset custom fields, allowing string->string mapping.</summary>
    public sealed class CustomFieldDictionary : Dictionary<string, AssetCustomField>
    {
        /// <value>The underlying model dictionary.</value>
        public IDictionary<string, AssetCustomField> Models => (IDictionary<string, AssetCustomField>)this;

        private Dictionary<string, string> FriendlyNameMap = new Dictionary<string, string>();

        /// <summary>Maps the friendly names to the internal database column names.</summary>
        public IReadOnlyDictionary<string, string> FriendlyNames => FriendlyNameMap;

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

        /// <summary>Add custom field values by SnipeIT database column name.</summary>
        public void Add(string key, string value)
        {
            Add(key, new AssetCustomField { FriendlyName = key, Field = key, Value = value });
            FriendlyNameMap[key] = key;
        }
    }
}
