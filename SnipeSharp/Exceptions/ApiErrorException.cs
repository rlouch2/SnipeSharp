using System;
using System.Collections.Generic;
using System.Net;

namespace SnipeSharp.Exceptions
{
    public sealed class ApiErrorException: Exception
    {
        public readonly bool IsHttpError;
        public readonly Dictionary<string, string> Messages;
        public readonly HttpStatusCode HttpStatusCode;

        public ApiErrorException(HttpStatusCode errorCode, string message): base(message)
        {
            IsHttpError = true;
            HttpStatusCode = errorCode;
        }
        public ApiErrorException(string message): base(message)
        {
            IsHttpError = false;
        }
        public ApiErrorException(Dictionary<string, string> messages)
        {
            IsHttpError = false;
            Messages = messages;
        }

        public override string ToString()
        {
            if(IsHttpError)
            {
                var message = Message;
                if(message.Length > 80)
                    message = $"{message.Substring(0,77)}...";
                return $"{HttpStatusCode}: {message}";
            } else if(Messages != null)
            {
                return "Multiple messages; see the Messages property for details.";
            } else
            {
                return base.ToString();
            }
        }
    }
}
