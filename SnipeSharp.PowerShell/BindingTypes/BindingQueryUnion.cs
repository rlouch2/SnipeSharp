namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// What type is a binding?
    /// </summary>
    internal enum BindingType
    {
        Invalid = 0,
        String = 1,
        Integer = 2
    }

    /// <summary>The tag in a query string</summary>
    public enum BindingQueryType
    {
        // Common
        /// <value>No tag was found</value>
        Absent = 0,
        /// <value>Not a recognized tag</value>
        Invalid,
        /// <value>A case-insensitive name</value>
        Name,
        /// <value>A case-insensitive name</value>
        CaseInsensitiveName = Name,
        /// <value>A case-sensitive name</value>
        CaseSensitiveName,
        /// <value>An internal ID number</value>
        Id,
        /// <value>A search string</value>
        Search,

        // User
        /// <value>A username</value>
        UserName,
        /// <value>An email address</value>
        Email,

        // Asset
        /// <value>A serial number</value>
        Serial,
        /// <value>An asset tag</value>
        AssetTag
    }

    /// <summary>
    /// Type for binding queries.
    /// </summary>
    internal struct BindingQueryUnion
    {
        internal BindingType Type;
        internal string StringValue;
        internal bool CaseSensitive;
        internal int IntegerValue;

        /// <inheritdoc/>
        public override string ToString()
        {
            if(null != StringValue)
                return StringValue;
            switch(Type)
            {
                case BindingType.Integer:
                    return IntegerValue.ToString();
                default:
                    return string.Empty;
            }
        }
    }
}
