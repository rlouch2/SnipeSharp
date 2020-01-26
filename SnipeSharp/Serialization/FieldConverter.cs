namespace SnipeSharp.Serialization
{
    /// <summary>
    /// Converters for various fields.
    /// </summary>
    internal enum FieldConverter
    {
        None = 0,

        /// <seealso cref="SimpleDateConverter" />
        SimpleDate,

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

        /// <seealso cref="CustomFieldDictionaryConverter" />
        CustomFieldDictionaryConverter,

        /// <seealso cref="Serialization.FalseyUriConverter" />
        FalseyUriConverter,

        /// <seealso cref="CustomReadOnlyResponseCollectionConverter" />
        ReadOnlyResponseCollectionConverter,
    }
}
