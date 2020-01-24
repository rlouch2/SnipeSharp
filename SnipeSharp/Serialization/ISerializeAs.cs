namespace SnipeSharp.Serialization
{
    internal interface ISerializeAs
    {
        string Key { get; }
        FieldConverter Converter { get; }
        bool IsRequired { get; }
    }
}
