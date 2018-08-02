using System;

namespace SnipeSharp.Serialization
{
    internal sealed class FieldAttribute : Attribute
    {
        public string DeserializeAs { get; private set; }
        public string SerializeAs { get; set; }
        public FieldConverter Converter { get; set; } = FieldConverter.None;
        public bool ShouldSerialize { get; set; } = false;
        public bool IsRequired { get; set; } = false;
        internal FieldAttribute(string deserializeAs, string serializeAs, FieldConverter converter = FieldConverter.None, bool required = false) : this(deserializeAs, true, converter, required)
        {
            SerializeAs = serializeAs;
        }
        internal FieldAttribute(string deserializeAs, bool serialize = false, FieldConverter converter = FieldConverter.None, bool required = false)
        {
            DeserializeAs = deserializeAs;
            if(serialize)
                SerializeAs = deserializeAs;
            Converter = converter;
            ShouldSerialize = serialize;
            IsRequired = required;
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
        MessagesConverter,
        AvailableActionsConverter
    }
}