using System.Collections.Generic;

namespace SnipeSharp
{
    public interface IFilter<T>
    {
        int? Limit { get; set; }
        int? Offset { get; set; }
        // TODO
        IReadOnlyDictionary<string, string?> GetParameters();
        IFilter<T> Clone();
    }

    public enum SortOrder
    {
        Descending = 0,
        Ascending = 1
    }

    public static class SortOrderExtension
    {
        public static string? Serialize(this SortOrder? order)
            => order switch
            {
                SortOrder.Ascending => "asc",
                SortOrder.Descending => "desc",
                _ => null
            };
    }

    internal sealed class BasicFilter<T> : IFilter<T>
    {
        private const string LIMIT_NAME = "limit";
        private const string OFFSET_NAME = "offset";

        public int? Limit { get; set; }
        public int? Offset { get; set; }

        // don't actually clone basic filters; they're used exclusively as a fallback mechanism.
        public IFilter<T> Clone() => this;

        public IReadOnlyDictionary<string, string?> GetParameters()
        {
            var parameters = new Dictionary<string, string?>();
            if(null != Limit)
                parameters[LIMIT_NAME] = Limit.ToString();
            if(null != Offset)
                parameters[OFFSET_NAME] = Offset.ToString();
            return parameters;
        }
    }
}
