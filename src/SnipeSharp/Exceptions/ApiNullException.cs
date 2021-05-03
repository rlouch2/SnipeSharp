using System;
using SnipeSharp.Models;

namespace SnipeSharp.Exceptions
{
    public sealed class ApiNullException: Exception
    {
        public ApiNullException(): base("Encountered unexpected null response while exeucting query."){}
    }
}
