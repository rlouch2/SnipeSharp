using System;

namespace SnipeSharp.Serialization
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    internal sealed class DeserializeAsAttribute : Attribute
    {
        public string Key { get; set; }
        public FieldConverter Converter { get; private set; }
        public DeserializeAs DeserializeAs { get; private set; }

        internal DeserializeAsAttribute(string key, FieldConverter converter = FieldConverter.None)
        {
            if(string.IsNullOrEmpty(key))
                throw new ArgumentException("Key cannot be null or empty.", paramName: nameof(key));
            Key = key;
            Converter = converter;
            DeserializeAs = DeserializeAs.Default;
        }

        internal DeserializeAsAttribute(string key, DeserializeAs deserializationType)
        {
            if(string.IsNullOrEmpty(key))
                throw new ArgumentException("Key cannot be null or empty.", paramName: nameof(key));
            Key = key;
            Converter = FieldConverter.None;
            DeserializeAs = deserializationType;
        }
    }

    /// <summary>
    /// Any special converters for Deserialization
    /// </summary>
    internal enum DeserializeAs
    {
        Default = 0,

        Timestamp,

        DateObject,

        AvailableActions
    }
}
