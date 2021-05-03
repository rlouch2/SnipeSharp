using System;
using SnipeSharp.Models;

namespace SnipeSharp.Exceptions
{
    public sealed class ApiException<R>: Exception
        where R: class?
    {
        public readonly ApiResult<R> Response;
        public ApiException(ApiResult<R> response): base(response.Messages.Join("{", ",", "}")) => Response = response;
    }
}
