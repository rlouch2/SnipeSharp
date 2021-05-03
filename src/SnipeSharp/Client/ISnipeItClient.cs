using System;
using System.Threading.Tasks;
using SnipeSharp.Models;

namespace SnipeSharp.Client
{
    public interface ISnipeItClient
    {
        Uri Uri { get; }

        Task<R?> Get<R>(string route) where R: class;
        Task<ApiResult<R?>?> Post<R>(string route, IPostable<R> body) where R: class;
        Task<ApiResult<R?>?> Patch<R>(string route, IPatchable<R> body, R from) where R: class;
        Task<ApiResult<R?>?> Put<R>(string route, IPutable<R> body) where R: class;
        Task<SimpleApiResult?> Delete(string route);
    }
}
