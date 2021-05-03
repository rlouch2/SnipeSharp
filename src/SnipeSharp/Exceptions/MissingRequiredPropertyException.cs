using System;

namespace SnipeSharp.Exceptions
{
    /// <summary>
    /// The exception that is thrown when an attribute is missing from a class.
    /// </summary>
    public sealed class MissingRequiredPropertyException : Exception
    {
        public MissingRequiredPropertyException(string propertyName, string className): base($"Missing required property \"{propertyName}\" when deserializing class \"{className}\".")
        {
        }
    }
}
