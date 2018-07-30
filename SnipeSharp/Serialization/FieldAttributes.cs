using System;

namespace SnipeSharp.Serialization
{
    internal class FieldAttribute : Attribute
    {
        public string DeserializeAs { get; private set; }
        public string SerializeAs { get; set; }
        public FieldConverter FieldConverter { get; set; } = FieldConverter.None;
        public bool CanSerialize { get; set; } = false;
        internal FieldAttribute(string deserializeAs)
        {
            DeserializeAs = deserializeAs;
            SerializeAs = deserializeAs;
        }
    }

    internal enum FieldConverter
    {
        None,
        SerializeToId,
        StripMonthSuffix,
        ExtractDateTime
    }
}