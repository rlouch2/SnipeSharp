using System;

namespace SnipeSharp.Serialization
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    internal sealed class FieldAttribute : Attribute, ISerializeAs, IDeserializeAs
    {
        public string DeserializeAs { get; set; }
        public string SerializeAs { get; set; }
        public FieldConverter Converter { get; set; } = FieldConverter.None;
        public bool IsRequired { get; set; } = false;

        string ISerializeAs.Key => SerializeAs;

        string IDeserializeAs.Key => DeserializeAs;

        internal FieldAttribute()
        {
            // the nice one.
        }

        internal FieldAttribute(string fieldName)
        {
            DeserializeAs = fieldName;
            SerializeAs = fieldName;
        }
    }
}
