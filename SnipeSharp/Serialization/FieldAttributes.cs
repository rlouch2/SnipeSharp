using System;

namespace SnipeSharp.Serialization
{
    internal sealed class FieldAttribute : Attribute
    {
        public string DeserializeAs { get; private set; }
        public string SerializeAs { get; set; }
        public FieldConverter Converter { get; set; } = FieldConverter.None;
        public bool ShouldSerialize { get; set; } = false;
        internal FieldAttribute(string deserializeAs, string serializeAs, FieldConverter converter = FieldConverter.None) : this(deserializeAs, true, converter)
        {
            SerializeAs = serializeAs;
        }
        internal FieldAttribute(string deserializeAs, bool serialize = false, FieldConverter converter = FieldConverter.None)
        {
            DeserializeAs = deserializeAs;
            if(serialize)
                SerializeAs = deserializeAs;
            Converter = converter;
            ShouldSerialize = serialize;
        }
    }

    internal enum FieldConverter
    {
        None,
        CommonModelConverter,
        MonthsConverter,
        DateTimeConverter,
        TimeSpanConverter,
        PermissionsConverter,
        MessagesConverter
    }
}