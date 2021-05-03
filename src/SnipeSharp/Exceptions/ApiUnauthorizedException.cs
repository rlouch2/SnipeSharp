using System.Net;

namespace SnipeSharp.Exceptions
{
    public sealed class ApiUnauthorizedException: ApiHttpException
    {
        public ApiUnauthorizedException(HttpStatusCode status, string message): base(status, message){}
    }
}
