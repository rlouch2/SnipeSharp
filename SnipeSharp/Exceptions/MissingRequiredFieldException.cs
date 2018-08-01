using System;
using System.Collections.Generic;
using System.Net;

namespace SnipeSharp.Exceptions
{
    public sealed class MissingRequiredFieldException<T>: Exception
    {
        public MissingRequiredFieldException(string fieldName): base($"Missing required field \"{fieldName}\" in object of type \"{typeof(T).FullName}\"")
        {
        }
    }
}