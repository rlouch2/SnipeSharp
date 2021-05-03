using System.Text.Json;

namespace SnipeSharp
{
    public static class JsonExtensions
    {
        public static T? ToObject<T>(this JsonElement element, JsonSerializerOptions? options = null)
            // TODO: get rid of this ugly hack.
            => JsonSerializer.Deserialize<T>(element.GetRawText(), options);
    }
}
