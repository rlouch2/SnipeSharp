using System;

namespace SnipeSharp.Serialization
{
    internal sealed class CreationFieldAttribute : Attribute
    {
        public string Name { get; private set; }
        public FieldConverter Converter { get; set; } = FieldConverter.None;
        public bool IsRequired { get; set; } = false;
        
        internal CreationFieldAttribute(string name, FieldConverter converter = FieldConverter.None, bool required = false)
        {
            Name = name;
            Converter = converter;
            IsRequired = required;
        }
    }
}
