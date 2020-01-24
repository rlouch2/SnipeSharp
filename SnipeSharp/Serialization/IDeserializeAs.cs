namespace SnipeSharp.Serialization
{
    internal interface IDeserializeAs
    {
        string Key { get; }
        FieldConverter Converter { get; }
    }
}
