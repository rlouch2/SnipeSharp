using System.Text.Json.Serialization;

namespace SnipeSharp.Models
{
    public class CommonModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        // TODO
    }
}
