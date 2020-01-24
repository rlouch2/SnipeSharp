using System;

namespace SnipeSharp.Serialization
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    internal sealed class DeserializeAsAttribute : Attribute, IDeserializeAs
    {
        public string Key { get; set; }
        public FieldConverter Converter { get; set; }

        internal DeserializeAsAttribute(string key, FieldConverter? converter = null)
        {
            if(string.IsNullOrEmpty(key))
                throw new ArgumentException("Key cannot be null or empty.", paramName: nameof(key));
            Key = key;
            Converter = converter ?? FieldConverter.None;
        }
    }
}
