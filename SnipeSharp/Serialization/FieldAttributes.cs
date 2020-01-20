using System;

namespace SnipeSharp.Serialization
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    internal sealed class FieldAttribute : Attribute
    {
        public string DeserializeAs { get; set; }
        public string SerializeAs { get; set; }
        public FieldConverter Converter { get; set; } = FieldConverter.None;
        public bool IsRequired { get; set; } = false;

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

    /// <summary>
    /// Converters for various fields.
    /// </summary>
    internal enum FieldConverter
    {
        None,

        /// <seealso cref="CustomCommonModelConverter" />
        CommonModelConverter,

        /// <seealso cref="CustomCommonModelArrayConverter" />
        CommonModelArrayConverter,

        /// <seealso cref="CustomAssetStatusConverter" />
        AssetStatusConverter,

        /// <seealso cref="CustomMonthsConverter" />
        MonthsConverter,

        /// <seealso cref="CustomDateTimeConverter" />
        DateTimeConverter,

        /// <seealso cref="CustomTimeSpanConverter" />
        TimeSpanConverter,

        /// <seealso cref="CustomIntBoolDictionaryConverter" />
        PermissionsConverter,

        /// <seealso cref="CustomMessageConverter" />
        MessagesConverter,

        /// <seealso cref="CustomAvailableActionsConverter" />
        AvailableActionsConverter,

        /// <seealso cref="CustomFieldDictionaryConverter" />
        CustomFieldDictionaryConverter,

        /// <seealso cref="Serialization.FalseyUriConverter" />
        FalseyUriConverter,

        /// <seealso cref="CustomReadOnlyResponseCollectionConverter" />
        ReadOnlyResponseCollectionConverter,
    }
}
