namespace SnipeSharp.PowerShell.BindingTypes
{
    /// <summary>
    /// Type for binding queries.
    /// </summary>
    internal struct BindingQueryUnion
    {
        /// <summary>
        /// What type is the binding?
        /// </summary>
        internal enum Type
        {
            Invalid = 0,
            String = 1,
            Integer = 2
        }

        internal Type BindingType;
        internal string StringValue;
        internal bool CaseSensitive;
        internal int IntegerValue;

        /// <inheritdoc/>
        public override string ToString()
        {
            if(null != StringValue)
                return StringValue;
            switch(BindingType)
            {
                case Type.Integer:
                    return IntegerValue.ToString();
                default:
                    return string.Empty;
            }
        }
    }
}
