using System.Net.Http;
using System.Text.Json;

namespace SnipeSharp
{
    public interface IPostable<R>
        where R: class
    {
    }

    internal static class IPostableExtensions
    {
        internal static HttpContent AsHttpContent<R>(this IPostable<R> self) where R: class
            => new StringContent(
                content: JsonSerializer.Serialize(self, self.GetType()),
                encoding: Static.UTF8NoBom,
                mediaType: "application/json");
    }
}
