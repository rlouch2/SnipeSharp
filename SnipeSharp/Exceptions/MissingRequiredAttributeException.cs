using System;

namespace SnipeSharp.Exceptions
{
    public sealed class MissingRequiredAttributeException : Exception
    {
        public MissingRequiredAttributeException(string attributeName, string className): base($"Missing required attribute \"{attributeName}\" on class \"{className}\".")
        {
        }
    }
}
