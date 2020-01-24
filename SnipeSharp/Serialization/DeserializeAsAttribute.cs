using System;

namespace SnipeSharp.Serialization
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    internal sealed class DeserializeAsAttribute : Attribute
    {
        public string Key { get; set; }
        public FieldConverter Converter { get; private set; }

        internal DeserializeAsAttribute(string key, FieldConverter converter = FieldConverter.None)
        {
            if(string.IsNullOrEmpty(key))
                throw new ArgumentException("Key cannot be null or empty.", paramName: nameof(key));
            Key = key;
            Converter = converter;
        }
    }
}
