using System.Net.Http;
using System.Text.Json;

namespace SnipeSharp
{
    public interface IPatchable<R>
        where R: class
    {
        IToPatch<R> GetPatchable(R main);
    }

    public interface IToPatch<R>
        where R: class
    {
    }

    internal static class IToPatchExtensions
    {
        internal static HttpContent AsHttpContent<R>(this IToPatch<R> self) where R: class
            => new StringContent(
                content: JsonSerializer.Serialize(self, self.GetType()),
                encoding: Static.UTF8NoBom,
                mediaType: "application/json");
    }
}
