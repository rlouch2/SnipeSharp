using System;

namespace SnipeSharp.Serialization
{
    internal class FieldAttribute : Attribute
    {
        public string DeserializeAs { get; private set; }
        public string SerializeAs { get; set; }
        public bool CanSerialize { get; set; } = false;
        public bool SerializeToId { get; set; } = false;
        internal FieldAttribute(string deserializeAs)
        {
            DeserializeAs = deserializeAs;
            SerializeAs = deserializeAs;
        }
    }
}