using System;

namespace SnipeSharp.Serialization
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    internal sealed class DeserializeAsAttribute : Attribute
    {
        public string Key { get; set; }
        public DeserializeAs DeserializeAs { get; private set; }

        internal DeserializeAsAttribute(string key, DeserializeAs deserializationType = DeserializeAs.Default)
        {
            if(string.IsNullOrEmpty(key))
                throw new ArgumentException("Key cannot be null or empty.", paramName: nameof(key));
            Key = key;
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

        Timespan,

        AvailableActions,

        SimpleDate,

        MonthStringAsInt,

        MessageDictionary,

        ReadOnlyCollection,

        MaybeFalseUri,

        CustomFieldDictionary,

        PermissionDictionary,

        /// <remarks>This should be replaced with <see cref="Converters.DateObjectConverter"/> or <see cref="Converters.TimestampConverter"/></remarks>
        [Obsolete]
        DateTimeConverter,
    }
}
