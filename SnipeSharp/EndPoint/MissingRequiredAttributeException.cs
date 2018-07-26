using System;

namespace SnipeSharp.EndPoint
{
    public class MissingRequiredAttributeException : Exception
    {
        public MissingRequiredAttributeException(string attributeName, string className): base($"Missing required attribute \"{attributeName}\" on class \"{className}\".")
        {
        }
    }
}