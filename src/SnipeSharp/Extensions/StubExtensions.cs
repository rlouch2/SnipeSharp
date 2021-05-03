using System.Collections.Generic;
using System.Threading.Tasks;
using SnipeSharp.Models;

namespace SnipeSharp
{
    public static class StubExtensions
    {
        public static Task<T?> ResolveAsync<T>(this Stub<T> item, SnipeItApi api)
            where T: class, IApiObject<T>
            => api.GetEndPoint<T>().GetAsync(item);

        public static async IAsyncEnumerable<T?> ResolveAsync<T>(this IEnumerable<Stub<T>> enumerable, SnipeItApi api)
            where T: class, IApiObject<T>
        {
            foreach(var stub in enumerable)
                yield return await stub.ResolveAsync(api);
        }
    }
}
