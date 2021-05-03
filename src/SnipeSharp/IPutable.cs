using System.Net.Http;
using System.Text.Json;

namespace SnipeSharp
{
    public interface IPutable<R>
        where R: class
    {
    }

    internal static class IPutableExtensions
    {
        internal static HttpContent AsHttpContent<R>(this IPutable<R> self) where R: class
            => new StringContent(
                content: JsonSerializer.Serialize(self, self.GetType()),
                encoding: Static.UTF8NoBom,
                mediaType: "application/json");
    }
}
