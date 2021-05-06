using System.Collections.Generic;

namespace SnipeSharp
{
    public sealed class SimpleFilter<T>: IFilter<T>
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string? SearchString { get; set; }

        public IFilter<T> Clone()
            => new SimpleFilter<T>
            {
                Limit = Limit,
                Offset = Offset,
                SearchString = SearchString
            };

        public IReadOnlyDictionary<string, string?> GetParameters()
            => new Dictionary<string, string?>()
                .AddIfNotNull(Static.LIMIT, Limit?.ToString())
                .AddIfNotNull(Static.OFFSET, Offset?.ToString())
                .AddIfNotNull(Static.SEARCH, SearchString);
    }
}
