using System;
using System.Collections.Generic;
using System.Net;

namespace SnipeSharp.Exceptions
{
    /// <summary>
    /// The exception that is thrown when a required field is null when serialization occurs.
    /// </summary>
    /// <typeparam name="T">A class that could be missing a required field.</typeparam>
    /// <seelaso cref="SnipeSharp.Serialization.FieldAttribute.IsRequired"/>
    public sealed class MissingRequiredFieldException<T>: Exception
    {
        /// <summary>
        /// Initializes a new instance of the MissingRequiredAttributeException class with a specified field name.
        /// </summary>
        /// <param name="fieldName">The name of the field or property that is missing.</param>
        public MissingRequiredFieldException(string fieldName): base($"Missing required field \"{fieldName}\" in object of type \"{typeof(T).FullName}\"")
        {
        }
    }
}
